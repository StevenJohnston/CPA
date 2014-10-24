-- cd C:\Program Files\MySQL\MySQL Server 5.6\bin
-- cd C:\xampp\mysql\bin

-- mysql -u root -p < G:\sql\db_setup\create_databases.sql
-- mysql -u root -p < G:\sql\SJA01Task1.sql > G:\sql\SJA02Task2.out

SELECT '' AS 'STEVEN JOHNSTON';
SELECT '' AS 'PROG2220: Section #1';
SELECT '' AS 'Assignment #02: Task #2';

SELECT SYSDATE() AS 'Current System Date';

USE my_guitar_shop;
SELECT category_name
 FROM categories v1
 WHERE v1.category_id =(
	SELECT v2.category_id 
	FROM products v2 
	WHERE v1.category_id = v2.category_id 
	LIMIT 1);
SELECT DISTINCT category_name 
	FROM categories v1
	WHERE NOT EXISTS(
		SELECT v2.category_id 
		FROM products v2
		WHERE v1.category_id = v2.category_id 
		LIMIT 1
	);

SELECT v3.email_address,v4.order_id,v4.customer_id 
FROM customers v3
JOIN
(
	SELECT DISTINCT v1.order_id,v1.customer_id 
	FROM (
		SELECT * 
		FROM orders v2 
		ORDER BY v2.order_date
	)v1 
		GROUP BY v1.customer_id
)v4 
ON v3.customer_id = v4.customer_id;