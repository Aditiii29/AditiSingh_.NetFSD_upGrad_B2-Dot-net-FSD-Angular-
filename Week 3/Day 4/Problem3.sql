SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold,
    SUM((oi.quantity * oi.list_price) - oi.discount) AS total_revenue
FROM stores s
INNER JOIN orders o 
    ON s.store_id = o.store_id
INNER JOIN order_items oi 
    ON o.order_id = oi.order_id
INNER JOIN products p 
    ON oi.product_id = p.product_id
WHERE EXISTS
(
    SELECT o2.store_id, oi2.product_id
    FROM orders o2
    INNER JOIN order_items oi2 
        ON o2.order_id = oi2.order_id

    INTERSECT

    SELECT store_id, product_id
    FROM stocks
    WHERE quantity = 0
)
GROUP BY 
    s.store_name,
    p.product_name;