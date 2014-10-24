-- cd C:\Program Files\MySQL\MySQL Server 5.6\bin
-- cd C:\xampp\mysql\bin

-- mysql -u root -p < G:\mgs_ex_starts\create_my_guitar_shop.sql
-- mysql -u root -p < G:\sql\SJA04Task2.sql > G:\mysql\SJA04Task2.out

SELECT '' AS 'your name STEVEN JOHNSTON';
SELECT '' AS 'PROG2220: Section #1';
SELECT '' AS 'Assignment #04: Task #2';

SELECT SYSDATE() AS 'Current System Date';

USE my_guitar_shop;

INSERT INTO categories (category_name)
values ("Brass");
UPDATE categories set category_name ="Woodwinds" WHERE category_id = LAST_INSERT_ID();
DELETE FROM categories WHERE category_id = LAST_INSERT_ID();

SELECT ROW_COUNT() AS "INSERT: rows affected";

INSERT INTO products (category_id,product_code,product_name,description,list_price,discount_percent,date_added)
VALUES (4,"dgx_640","Yamaha DGX 640 88-Key Digital Piano","Long description to come.",799.99,0,SYSDATE());
UPDATE products set discount_percent = 36.00 WHERE product_id = LAST_INSERT_ID();

SELECT ROW_COUNT() AS "INSERT: rows affected";

INSERT INTO customers (email_address,password,first_name,last_name)
VALUES ("rick@raven.com","","Rick","Raven");
UPDATE customers set password ="secret" WHERE email_address = "rick@raven.com";