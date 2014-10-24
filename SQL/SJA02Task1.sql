-- cd C:\Program Files\MySQL\MySQL Server 5.6\bin
-- cd C:\xampp\mysql\bin

-- mysql -u root -p < G:\sql\db_setup\create_databases.sql
-- mysql -u root -p < G:\sql\SJA01Task1.sql > G:\mysql\SJA02Task1.out

SELECT '' AS 'STEVEN JOHNSTON';
SELECT '' AS 'PROG2220: Section #1';
SELECT '' AS 'Assignment #02: Task #1';

SELECT SYSDATE() AS 'Current System Date';

USE my_guitar_shop;
SELECT category_name,product_name,list_price 
	FROM products JOIN categories 
	ORDER BY category_name , product_name ASC;
SELECT first_name, last_name, line1, city, state, zip_code 
	FROM customers JOIN addresses 
	WHERE email_address = 'allan.sherwood@yahoo.com' LIMIT 1;
SELECT last_name, first_name,order_date,product_name,item_price,discount_amount,quantity 
	FROM customers JOIN orders on customers.customer_id = orders.customer_id 
	JOIN order_items on orders.order_id = order_items.order_id 
	JOIN products on products.product_id = order_items.product_id
	ORDER BY last_name,order_date,product_name;
SELECT DISTINCT v1.product_name, v1.list_price 
	FROM products v1 JOIN products v2 ON v1.product_name != v2.product_name AND v1.list_price = v2.list_price;
SELECT "Shipped" AS ship_satus,order_id,order_date 
	FROM orders WHERE ship_date IS NOT NULL 
	UNION SELECT "not Shipped" AS ship_status,order_id,order_date 
	FROM orders WHERE ship_date IS NULL ORDER BY order_date;
