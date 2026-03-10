IF OBJECT_ID ('archived_orders', 'U') IS NULL       -- creates the table only if it does not already exist.
BEGIN
CREATE TABLE archived_orders (
    order_id INT,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    store_id INT,
    staff_id INT
);
END

--1. Archive old rejected orders: -- 
INSERT INTO archived_orders
SELECT *
FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR,-1,GETDATE());

--2. Delete those rejected orders(after archiving): --
DELETE FROM orders
WHERE order_id IN
(
    SELECT order_id
    FROM archived_orders
);

--3.Customers whose all orders are completed:--
SELECT customer_id
FROM customers
WHERE customer_id NOT IN
(
    SELECT customer_id
    FROM orders
    WHERE order_status <> 4
);

--4. Order processing delay --
SELECT 
order_id,
order_date,
shipped_date,
DATEDIFF(DAY, order_date, shipped_date) AS processing_delay
FROM orders;

--5. Mark orders as Delayed/on time --
SELECT 
order_id,
required_date,
shipped_date,

CASE
WHEN shipped_date > required_date THEN 'Delayed'
ELSE 'On Time'
END AS delivery_status

FROM orders;
	
