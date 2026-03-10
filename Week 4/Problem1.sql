USE EcommAppDb
GO


-- 1. Stored Procedure : Total Sales per Store --

DROP PROCEDURE IF EXISTS sp_TotalSalesPerStore
GO

CREATE PROCEDURE sp_TotalSalesPerStore
AS
BEGIN
    SELECT 
        s.store_name,
        SUM((oi.quantity * oi.list_price) - oi.discount) AS total_sales
    FROM orders o
    INNER JOIN stores s
        ON o.store_id = s.store_id
    INNER JOIN order_items oi
        ON o.order_id = oi.order_id
    GROUP BY s.store_name
END
GO

-- Test Procedure
EXEC sp_TotalSalesPerStore
GO




-- 2️. Stored Procedure : Orders by Date Range --

DROP PROCEDURE IF EXISTS sp_GetOrdersByDateRange
GO

CREATE PROCEDURE sp_GetOrdersByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        order_id,
        customer_id,
        order_date,
        order_status
    FROM orders
    WHERE order_date BETWEEN @StartDate AND @EndDate
END
GO

-- Test Procedure
EXEC sp_GetOrdersByDateRange '2018-01-01','2018-12-31'
GO



-- 3. Scalar Function : Calculate Price After Discount --

DROP FUNCTION IF EXISTS fn_TotalPriceAfterDiscount
GO

CREATE FUNCTION fn_TotalPriceAfterDiscount
(
    @price DECIMAL(10,2),
    @discount DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @finalPrice DECIMAL(10,2)

    SET @finalPrice = @price - ISNULL(@discount,0)

    RETURN @finalPrice
END
GO

-- Test Function
SELECT dbo.fn_TotalPriceAfterDiscount(1000,100) AS FinalPrice
GO




-- 4️. Table-Valued Function : Top 5 Selling Products --
DROP FUNCTION IF EXISTS fn_TopSellingProducts
GO

CREATE FUNCTION fn_TopSellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_name,
        SUM(oi.quantity) AS total_quantity_sold
    FROM order_items oi
    INNER JOIN products p
        ON oi.product_id = p.product_id
    GROUP BY p.product_name
    ORDER BY total_quantity_sold DESC
)
GO

-- Test Function --
SELECT * FROM fn_TopSellingProducts()
GO