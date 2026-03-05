SELECT 
    p.product_name,
    s.store_name,
    st.quantity AS available_stock,
    SUM(oi.quantity) AS total_quantity_sold
FROM stocks st, products p, stores s, order_items oi
WHERE st.product_id = p.product_id
AND st.store_id = s.store_id
AND st.product_id = oi.product_id
GROUP BY 
    p.product_name,
    s.store_name,
    st.quantity
ORDER BY p.product_name;