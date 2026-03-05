SELECT 
    p.product_name + ' (' + CAST(p.model_year AS VARCHAR) + ')' AS product_info,
    p.model_year,
    p.list_price,
    
    p.list_price - (
        SELECT AVG(p2.list_price)
        FROM products p2
        WHERE p2.category_id = p.category_id
    ) AS price_difference

FROM products p

WHERE p.list_price > (
    SELECT AVG(p2.list_price)
    FROM products p2
    WHERE p2.category_id = p.category_id
);