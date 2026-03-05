SELECT 
    s.store_name,
    SUM(oi.quantity * oi.list_price) AS total_sales
FROM stores s, orders o, order_items oi
WHERE s.store_id = o.store_id
AND o.order_id = oi.order_id
AND o.order_status = 4
GROUP BY s.store_name
ORDER BY total_sales DESC;