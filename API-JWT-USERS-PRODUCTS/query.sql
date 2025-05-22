create database API_JWT_PRODUCTS_USERS;
GO
USE API_JWT_PRODUCTS_USERS;
GO
CREATE TABLE users(
id int primary key identity,
name varchar(50),
email varchar(50),
password varchar(100),
);
GO
CREATE TABLE products(
id int primary key identity,
name varchar(50),
marca varchar(50),
price decimal(10,2),
user_id int foreign key references users(id),
);
GO

