BEGIN TRY
BEGIN TRANSACTION;

DECLARE @OrderId INT = 1;   -- Order to cancel

-- Savepoint before restoring stock
SAVE TRANSACTION BeforeStockRestore;

-- Restore stock quantities
UPDATE s
SET s.quantity = s.quantity + oi.quantity
FROM Stocks s
JOIN Order_Items oi ON s.product_id = oi.product_id
WHERE oi.order_id = @OrderId;

-- Check if restoration failed (example condition)
IF @@ERROR <> 0
BEGIN
    RAISERROR('Stock restoration failed',16,1);
    ROLLBACK TRANSACTION BeforeStockRestore;
END

-- Update order status to Rejected (3)
UPDATE Orders
SET order_status = 3
WHERE order_id = @OrderId;

-- Commit if everything succeeded
COMMIT TRANSACTION;

END TRY

BEGIN CATCH
ROLLBACK TRANSACTION;
PRINT ERROR_MESSAGE();
END CATCH;