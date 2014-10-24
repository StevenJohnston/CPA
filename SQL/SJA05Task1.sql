-- cd C:\Program Files\MySQL\MySQL Server 5.6\bin
-- cd C:\xampp\mysql\bin

-- mysql -u root -p < G:\sql\db_setup\create_databases.sql
-- mysql -u root -p < G:\sql\SJA05Task1.sql > G:\mysql\SJA05Task1.out

SELECT '' AS 'your name STEVEN JOHNSTON';
SELECT '' AS 'PROG2220: Section #1';
SELECT '' AS 'Assignment #05: Task #1';

SELECT SYSDATE() AS 'Current System Date';


USE ap;
SELECT invoice_total,
       FORMAT(invoice_total, 1) AS total_format,
       CONVERT(invoice_total, SIGNED) AS total_convert, 
       CAST(invoice_total AS SIGNED) AS total_cast
FROM invoices 
ORDER BY invoice_total DESC
LIMIt 10;

SELECT invoice_date, 
       CAST(invoice_date AS DATETIME) AS invoice_datetime, 
       DATE_FORMAT(invoice_date ,"%m-%d") AS month_day
FROM invoices;