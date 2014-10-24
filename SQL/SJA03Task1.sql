-- cd C:\Program Files\MySQL\MySQL Server 5.6\bin
-- cd C:\xampp\mysql\bin

-- mysql -u root -p < G:\sql\db_setup\create_databases.sql
-- mysql -u root -p < G:\sql\SJA03Task1.sql > G:\sql\SJA03Task1.out

SELECT '' AS 'STEVEN JOHNSTON';
SELECT '' AS 'PROG2220: Section #1';
SELECT '' AS 'Assignment #03: Task #1';

SELECT SYSDATE() AS 'Current System Date';

USE my_guitar_shop;
SELECT COUNT(*) AS "Number of orders", SUM(tax_amount) AS "Tax sum" 
	FROM orders;
SELECT category_name , COUNT(DISTINCT(product_id)) AS "Number of IDs",
	MAX(list_price)
	FROM categories 
	JOIN products 
	ON categories.category_id =products.category_id
	GROUP BY categories.category_id;
SELECT IFNULL(product_name,"Total") AS "product_name", 
	SUM((item_price - discount_amount)*v2.quantity) AS "product total" 
	FROM products v1 
	JOIN  order_items v2 
	ON v1.product_id=v2.product_id 
	GROUP BY v1.product_name 
	WITH ROLLUP;