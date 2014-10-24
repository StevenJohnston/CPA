-- cd C:\Program Files\MySQL\MySQL Server 5.6\bin
-- cd C:\xampp\mysql\bin

-- mysql -u root -p < G:\sql\db_setup\create_databases.sql
-- mysql -u root -p < G:\sql\SJA04Task1.sql > G:\mysql\SJA04Task1.out

SELECT '' AS 'your name STEVEN JOHNSTON';
SELECT '' AS 'PROG2220: Section #1';
SELECT '' AS 'Assignment #04: Task #1';

SELECT SYSDATE() AS 'Current System Date';

USE ap;
INSERT INTO invoices
VALUES (DEFAULT, 32, 'AX-014-027', '2011-08-01', 434.58, 0, 0,
        2, '2011-08-31', NULL);
		
SELECT ROW_COUNT() AS "INSERT: rows affected";

INSERT INTO invoice_line_items VALUES
    (115, 1, 160, 180.23, 'Hard drive'),
    (115, 2, 527, 254.35, 'Exchange Server update');

SELECT ROW_COUNT() AS "INSERT: rows affected";
	
UPDATE invoices
SET credit_total = invoice_total * .1,
    payment_total = invoice_total - credit_total
WHERE invoice_id = 115;

SELECT ROW_COUNT() AS "INSERT: rows affected";

DELETE FROM invoice_line_items
WHERE invoice_id = 115;

SELECT ROW_COUNT() AS "INSERT: rows affected";

DELETE FROM invoices
WHERE invoice_id = 115;
