create database API_JWT_PRODUCTS_USERS;
GO
USE API_JWT_PRODUCTS_USERS;
GO
CREATE TABLE users(
id int primary key identity,
name varchar(50),
email varchar(50),
password varchar(100)
);
GO
CREATE TABLE products(
id int primary key identity,
name varchar(50),
marca varchar(50),
price decimal(10,2)
);
GO
INSERT INTO products (name, marca, price) VALUES
('Laptop', 'Dell', 1200.00),
('Smartphone', 'Samsung', 800.00),
('Tablet', 'Apple', 950.00),
('Monitor', 'LG'	, 300.00),
('Teclado', 'Logitech', 50.00),
('Mouse', 'HP', 35.00),
('Impresora', 'Epson', 200.00),
('Auriculares', 'Sony', 150.00),
('Cámara', 'Canon', 600.00),
('Disco Duro', 'Seagate', 100.00);
