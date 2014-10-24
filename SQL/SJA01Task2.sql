-- cd C:\Program Files\MySQL\MySQL Server 5.6\bin
-- cd C:\xampp\mysql\bin

-- mysql -u root -p < G:\sql\db_setup\create_databases.sql
-- mysql -u root -p < G:\sql\SJA01Task2.sql > G:\mysql\SJA01Task2.out

SELECT '' AS 'your name STEVEN JOHNSTON';
SELECT '' AS 'PROG2220: Section #1';
SELECT '' AS 'Assignment #01: Task #2';

SELECT SYSDATE() AS 'Current System Date';

use my_guitar_shop;

SELECT product_code, product_name, list_price, discount_percent FROM products ORDER BY list_price DESC;

SELECT product_name, list_price, date_added FROM products WHERE list_price>500 and list_price <2000 ORDER BY date_added DESC;

SELECT item_id, item_price, discount_amount, quantity, item_price * quantity as price_total, discount_amount*quantity as discount_total, item_price - discount_amount  as item_total FROM order_items WHERE item_price - discount_amount > 500;

SELECT order_id, order_date, ship_date FROM orders WHERE ship_date is null;

SELECT '100' as price, '0.7'as tax_rate, 100 * 0.7 as tax_amount, 100 * 1.7 as total;