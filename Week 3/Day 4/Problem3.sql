SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold,
    SUM((oi.quantity * oi.list_price) - oi.discount) AS total_revenue
FROM order_items oi
INNER JOIN orders o 
    ON oi.order_id = o.order_id
INNER JOIN stores s 
    ON o.store_id = s.store_id
INNER JOIN products p 
    ON oi.product_id = p.product_id
WHERE EXISTS
(
    SELECT 1
    FROM
    (
        SELECT o.store_id, oi.product_id
        FROM order_items oi
        INNER JOIN orders o 
            ON oi.order_id = o.order_id

        INTERSECT

        SELECT store_id, product_id
        FROM stocks
        WHERE quantity = 0
    ) AS t
    WHERE t.store_id = o.store_id 
    AND t.product_id = oi.product_id
)
GROUP BY 
    s.store_name,
    p.product_name;