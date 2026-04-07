USE EcommAppDb
GO

-- Temporary table to store revenue
IF OBJECT_ID('tempdb..#StoreRevenue') IS NOT NULL
DROP TABLE #StoreRevenue

CREATE TABLE #StoreRevenue
(
    store_id INT,
    order_id INT,
    revenue DECIMAL(12,2)
)

BEGIN TRY

BEGIN TRANSACTION

-- Declare variables
DECLARE @order_id INT
DECLARE @store_id INT
DECLARE @revenue DECIMAL(12,2)

-- Declare cursor for completed orders
DECLARE order_cursor CURSOR FOR
SELECT order_id, store_id
FROM orders
WHERE order_status = 4

OPEN order_cursor

FETCH NEXT FROM order_cursor INTO @order_id, @store_id

WHILE @@FETCH_STATUS = 0
BEGIN

    -- Calculate revenue for the order
    SELECT @revenue = SUM((quantity * list_price) - discount)
    FROM order_items
    WHERE order_id = @order_id

    -- Insert into temporary table
    INSERT INTO #StoreRevenue
    VALUES (@store_id, @order_id, ISNULL(@revenue,0))

    FETCH NEXT FROM order_cursor INTO @order_id, @store_id

END

CLOSE order_cursor
DEALLOCATE order_cursor


-- Display store-wise revenue summary
SELECT store_id,
SUM(revenue) AS total_store_revenue
FROM #StoreRevenue
GROUP BY store_id


COMMIT TRANSACTION

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION

PRINT 'Error occurred: ' + ERROR_MESSAGE()

END CATCH