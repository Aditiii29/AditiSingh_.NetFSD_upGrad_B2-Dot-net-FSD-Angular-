CREATE DATABASE EcommDb;
GO

USE EcommDb;
GO

-- 1. create Tables --
CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50)
);

CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(50)
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    city VARCHAR(50),
    phone VARCHAR(20)
);

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(50)
);

-- 2. Insert Sample Data --
-- Categories --
INSERT INTO categories VALUES
(1,'Mountain Bikes'),
(2,'Road Bikes'),
(3,'Electric Bikes'),
(4,'Cruisers'),
(5,'Kids Bikes');

-- Brands --
INSERT INTO brands VALUES
(1,'Trek'),
(2,'Giant'),
(3,'Specialized'),
(4,'Cannondale'),
(5,'Scott');

-- Products --
INSERT INTO products VALUES
(1,'Trek 820',1,1,2018,500),
(2,'Giant Escape 3',2,2,2019,650),
(3,'Specialized Turbo',3,3,2020,1200),
(4,'Cannondale Trail 5',4,1,2018,700),
(5,'Scott Voltage',5,5,2017,400);

-- Customers --
INSERT INTO customers VALUES
(1,'John','Smith','New York','9876543210'),
(2,'David','Miller','Chicago','9876543211'),
(3,'Emma','Watson','New York','9876543212'),
(4,'Olivia','Brown','Dallas','9876543213'),
(5,'Liam','Taylor','Chicago','9876543214');

-- Stores --
INSERT INTO stores VALUES
(1,'Central Bikes','New York'),
(2,'City Cycles','Chicago'),
(3,'Bike World','Dallas'),
(4,'Urban Bikes','Houston'),
(5,'Speed Wheels','Phoenix');

-- 3. Retrieve all products with brand and category --
SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
INNER JOIN brands b
ON p.brand_id = b.brand_id
INNER JOIN categories c
ON p.category_id = c.category_id;

-- 4. Retrieve customers from a specific city --
SELECT *
FROM customers
WHERE city = 'New York';

-- 5. Total products in each category --
SELECT 
c.category_name,
COUNT(p.product_id) AS total_products
FROM categories c
LEFT JOIN products p
ON c.category_id = p.category_id
GROUP BY c.category_name;