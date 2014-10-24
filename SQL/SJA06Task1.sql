-- cd C:\Program Files\MySQL\MySQL Server 5.6\bin
-- cd C:\xampp\mysql\bin

-- mysql -u root -p < G:\sql\db_setup\create_databases.sql
-- mysql -u root -p < G:\sql\SJA06Task1.sql > G:\mysql\SJA06Task1.out
SELECT '' AS 'your name STEVEN JOHNSTON';
SELECT '' AS 'PROG2220: Section #1';
SELECT '' AS 'Assignment #06: Task #1';

SELECT SYSDATE() AS 'Current System Date';

use ap;
CREATE OR REPLACE VIEW open_items_summary
AS
SELECT vendor_name, COUNT(*) AS open_item_count,
       SUM(invoice_total - credit_total - payment_total) AS open_item_total
FROM vendors JOIN invoices
  ON vendors.vendor_id = invoices.vendor_id
WHERE invoice_total - credit_total - payment_total > 0
GROUP BY vendor_name
ORDER BY open_item_total DESC;

SELECT *
FROM open_items_summary
LIMIT 5