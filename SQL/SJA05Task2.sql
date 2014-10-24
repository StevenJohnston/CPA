-- cd C:\Program Files\MySQL\MySQL Server 5.6\bin
-- cd C:\xampp\mysql\bin

-- mysql -u root -p < G:\mgs_ex_starts\create_my_guitar_shop.sql
-- mysql -u root -p < G:\sql\SJA05Task2.sql > G:\sql\SJA05Task2.out

SELECT '' AS 'your name STEVEN JOHNSTON';
SELECT '' AS 'PROG2220: Section #1';
SELECT '' AS 'Assignment #05: Task #2';

SELECT SYSDATE() AS 'Current System Date';

USE my_guitar_shop;

SELECT 
    list_price,
    discount_percent,
    ROUND(SUM(list_price * discount_percent / 100),2) as discount_amount
FROM
    products
GROUP BY product_id;

SELECT 
	order_date,
    DATE_FORMAT(order_date, '%Y') as "year",
    DATE_FORMAT(order_date, '%b-%d-%Y') as "mmm-dd-yyyy",
    DATE_FORMAT(order_date, '%h:%i %p') as "time",
    DATE_FORMAT(order_date, '%m/%d/%y %H:%i') as "data_time"
FROM
    orders;

SELECT 
    card_number,
    LENGTH(card_number) as string_legth,
    RIGHT(card_number, 4) as last_4_digits,
    CONCAT('XXXX-XXXX-XXXX-', RIGHT(card_number, 4)) AS 'Secret'
FROM
    orders;

SELECT 
    order_id,
    order_date,
    DATE_ADD(order_date, INTERVAL 2 DAY) AS '2 more days',
    CASE
        WHEN ship_date IS NULL THEN 'Not shipped'
        ELSE ship_date
    END as ship_status,
    DATEDIFF(ship_date, order_date) as date_gap
FROM
    orders
WHERE
    DATE_FORMAT(order_date, '%m%y') = '0412';