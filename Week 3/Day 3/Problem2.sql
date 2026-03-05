SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p, brands b, categories c
WHERE p.brand_id = b.brand_id
AND p.category_id = c.category_id
AND p.list_price > 500
ORDER BY p.list_price ASC;