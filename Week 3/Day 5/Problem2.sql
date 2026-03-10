USE EcommAppDb
GO

-----------------------------------------------------
-- 1️ Create View : Product Details
-----------------------------------------------------
DROP VIEW IF EXISTS vw_ProductDetails
GO

CREATE VIEW vw_ProductDetails AS
SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
INNER JOIN brands b
    ON p.brand_id = b.brand_id
INNER JOIN categories c
    ON p.category_id = c.category_id
GO


-----------------------------------------------------
-- 2️⃣ Create View : Order Summary
-----------------------------------------------------
DROP VIEW IF EXISTS vw_OrderSummary
GO

CREATE VIEW vw_OrderSummary AS
SELECT
    o.order_id,
    c.first_name + ' ' + c.last_name AS customer_name,
    s.store_name,
    st.first_name + ' ' + st.last_name AS staff_name,
    o.order_date
FROM orders o
INNER JOIN customers c
    ON o.customer_id = c.customer_id
INNER JOIN stores s
    ON o.store_id = s.store_id
INNER JOIN staffs st
    ON o.staff_id = st.staff_id
GO


-----------------------------------------------------
-- 3️ Create Indexes on Foreign Key Columns
-----------------------------------------------------
CREATE INDEX idx_products_brand
ON products(brand_id)

CREATE INDEX idx_products_category
ON products(category_id)

CREATE INDEX idx_orders_customer
ON orders(customer_id)

CREATE INDEX idx_orders_store
ON orders(store_id)

CREATE INDEX idx_orders_staff
ON orders(staff_id)
GO


-----------------------------------------------------
-- 4️ Test the Views
-----------------------------------------------------
SELECT * FROM vw_ProductDetails

SELECT * FROM vw_OrderSummary
GO


-----------------------------------------------------
-- 5️ Test Performance using Execution Plan
-----------------------------------------------------
SET STATISTICS TIME ON
SET STATISTICS IO ON

SELECT 
    p.product_name,
    b.brand_name,
    c.category_name
FROM products p
INNER JOIN brands b
    ON p.brand_id = b.brand_id
INNER JOIN categories c
    ON p.category_id = c.category_id

SET STATISTICS TIME OFF
SET STATISTICS IO OFF
GO