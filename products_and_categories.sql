CREATE TABLE products (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(100) NOT NULL
);

CREATE TABLE categories (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(30) NOT NULL
);

CREATE TABLE product_category (
    product_id INT NOT NULL,
    category_id INT NOT NULL,
    PRIMARY KEY (product_id, category_id),
    FOREIGN KEY (product_id) REFERENCES products(id),
    FOREIGN KEY (category_id) REFERENCES categories(id)
);

INSERT INTO products (name) VALUES 
('Product 1'),
('Product 2'),
('Product 3');

INSERT INTO categories (name) VALUES 
('Category A'),
('Category B'),
('Category C');

INSERT INTO product_category (product_id, category_id) VALUES 
(1, 1),
(1, 2),
(2, 3);

SELECT 
    p.name AS product_name,
    c.name AS category_name
FROM 
    products p
LEFT JOIN 
    product_category pc ON p.id = pc.product_id
LEFT JOIN 
    categories c ON pc.category_id = c.id;
