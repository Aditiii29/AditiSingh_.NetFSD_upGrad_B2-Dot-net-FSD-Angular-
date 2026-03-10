USE EcommAppDb
GO


-- Trigger: Validate order completion status --


DROP TRIGGER IF EXISTS trg_OrderStatusValidation
GO

CREATE TRIGGER trg_OrderStatusValidation
ON orders
AFTER UPDATE
AS
BEGIN
    BEGIN TRY

        -- Check if order_status is set to Completed (4)
        -- but shipped_date is NULL
        IF EXISTS
        (
            SELECT 1
            FROM inserted
            WHERE order_status = 4
            AND shipped_date IS NULL
        )
        BEGIN
            THROW 50002, 'Cannot set order status to Completed when shipped_date is NULL.', 1;

            ROLLBACK TRANSACTION;
            RETURN;
        END

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();

        RAISERROR (@ErrorMessage,16,1);
    END CATCH
END
GO

-- TEST --
UPDATE orders
SET shipped_date = GETDATE(),
    order_status = 4
WHERE order_id = 1;