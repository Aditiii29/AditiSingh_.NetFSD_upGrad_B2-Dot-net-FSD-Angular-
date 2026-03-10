USE EcommAppDb
GO


-- Trigger : Reduce stock when a new order item is added --


DROP TRIGGER IF EXISTS trg_UpdateStock
GO

CREATE TRIGGER trg_UpdateStock
ON order_items
AFTER INSERT
AS
BEGIN
BEGIN TRY

    -- Check stock availability
    IF EXISTS (
        SELECT 1
        FROM stocks s
        JOIN inserted i
            ON s.product_id = i.product_id
        JOIN orders o
            ON i.order_id = o.order_id
        WHERE s.store_id = o.store_id
        AND s.quantity < i.quantity
    )
    BEGIN
        THROW 50001, 'Stock is insufficient for this order.', 1;
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Reduce stock
    UPDATE s
    SET s.quantity = s.quantity - i.quantity
    FROM stocks s
    JOIN inserted i
        ON s.product_id = i.product_id
    JOIN orders o
        ON i.order_id = o.order_id
    WHERE s.store_id = o.store_id;

END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION;
    DECLARE @ErrorMessage NVARCHAR(4000);
    SET @ErrorMessage = ERROR_MESSAGE();
    RAISERROR (@ErrorMessage,16,1);
END CATCH
END
GO