-- Customers who have placed orders
SELECT 
    c.first_name + ' ' + c.last_name AS full_name,

    (SELECT SUM(oi.quantity * oi.list_price)
     FROM orders o
     INNER JOIN order_items oi
        ON o.order_id = oi.order_id
     WHERE o.customer_id = c.customer_id) AS total_order_value,

    CASE
        WHEN (SELECT SUM(oi.quantity * oi.list_price)
              FROM orders o
              INNER JOIN order_items oi
                 ON o.order_id = oi.order_id
              WHERE o.customer_id = c.customer_id) > 10000 THEN 'Premium'

        WHEN (SELECT SUM(oi.quantity * oi.list_price)
              FROM orders o
              INNER JOIN order_items oi
                 ON o.order_id = oi.order_id
              WHERE o.customer_id = c.customer_id) BETWEEN 5000 AND 10000 THEN 'Regular'

        ELSE 'Basic'
    END AS customer_category

FROM customers c
WHERE c.customer_id IN (SELECT customer_id FROM orders)

UNION

-- Customers who have not placed any orders
SELECT 
    c.first_name + ' ' + c.last_name AS full_name,
    0 AS total_order_value,
    'No Orders' AS customer_category
FROM customers c
WHERE c.customer_id NOT IN (SELECT customer_id FROM orders);