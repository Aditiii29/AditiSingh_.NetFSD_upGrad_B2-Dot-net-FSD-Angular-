SELECT 
    c.first_name,
    c.last_name,
    o.order_id,
    o.order_date,
    o.order_status
FROM customers c, orders o
WHERE c.customer_id = o.customer_id
AND (o.order_status = 1 OR o.order_status = 4)
ORDER BY o.order_date DESC;