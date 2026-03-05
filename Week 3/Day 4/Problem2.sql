SELECT 
    c.first_name + ' ' + c.last_name AS full_name,

    ISNULL(SUM(oi.quantity * oi.list_price),0) AS total_order_value,

    CASE 
        WHEN ISNULL(SUM(oi.quantity * oi.list_price),0) > 10000 THEN 'Premium'
        WHEN ISNULL(SUM(oi.quantity * oi.list_price),0) BETWEEN 5000 AND 10000 THEN 'Regular'
        WHEN ISNULL(SUM(oi.quantity * oi.list_price),0) < 5000 THEN 'Basic'
    END AS customer_category

FROM customers c
LEFT JOIN orders o 
    ON c.customer_id = o.customer_id
LEFT JOIN order_items oi 
    ON o.order_id = oi.order_id

GROUP BY 
    c.first_name,
    c.last_name

ORDER BY full_name;