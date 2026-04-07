-- Transaction to Place Order
SELECT * FROM Products
BEGIN TRY
BEGIN TRANSACTION;

INSERT INTO Orders(customer_id, order_date)
VALUES (101, GETDATE());

DECLARE @OrderId INT = SCOPE_IDENTITY();

INSERT INTO Order_Items(order_id, product_id, quantity)
VALUES (@OrderId,1,5),(@OrderId,2,3);

-- Check stock availability
IF EXISTS (
SELECT 1
FROM Order_Items oi
JOIN Products p ON oi.product_id = p.product_id
JOIN Stocks s ON oi.product_id = s.product_id
WHERE oi.order_id = @OrderId
AND oi.quantity > s.quantity
)
BEGIN
RAISERROR('Insufficient Stock',16,1);
ROLLBACK TRANSACTION;
END
ELSE
COMMIT TRANSACTION;

END TRY
BEGIN CATCH
ROLLBACK TRANSACTION;
PRINT ERROR_MESSAGE();
END CATCH;
GO

-- Trigger to Reduce Stock
DROP TRIGGER IF EXISTS trg_UpdateStock;
GO
CREATE TRIGGER trg_UpdateStock
ON Order_Items
AFTER INSERT
AS
BEGIN

IF EXISTS(
SELECT 1
FROM inserted i
JOIN Stocks s ON i.product_id = s.product_id
WHERE s.quantity - i.quantity < 0
)
BEGIN
RAISERROR('Stock cannot be negative',16,1);
ROLLBACK TRANSACTION;
RETURN;
END

UPDATE s
SET s.quantity = s.quantity - i.quantity
FROM Stocks s
JOIN inserted i
ON s.product_id = i.product_id;

END;