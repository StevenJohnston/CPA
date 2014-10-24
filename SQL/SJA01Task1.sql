-- cd C:\Program Files\MySQL\MySQL Server 5.6\bin
-- cd C:\xampp\mysql\bin

-- mysql -u root -p < G:\sql\db_setup\create_databases.sql
-- mysql -u root -p < G:\sql\SJA01Task1.sql > G:\mysql\SJA01Task1.out

SELECT '' AS 'your name STEVEN JOHNSTON';
SELECT '' AS 'PROG2220: Section #1';
SELECT '' AS 'Assignment #01: Task #1';

SELECT SYSDATE() AS 'Current System Date';

use ap;

SELECT vendor_name,vendor_contact_last_name,vendor_contact_first_name from vendors ORDER BY vendor_contact_last_name,vendor_contact_first_name;

SELECT CONCAT(vendor_contact_last_name, ',' , vendor_contact_first_name) AS full_name from vendors WHERE vendor_contact_last_name REGEXP '^[A-C ,E]' ORDER BY vendor_contact_last_name,vendor_contact_first_name ;

SELECT invoice_due_date as 'Due Date',invoice_total as 'InvoiceTotal',invoice_total*0.1 as '10%', invoice_total*1.1 as 'Plus 10%' from invoices WHERE invoice_total >= 500 AND invoice_total<=1000 ORDER BY invoice_due_date DESC;

SELECT invoice_number,invoice_total,payment_total+ credit_total as 'payment_credit_total', invoice_total-payment_total-credit_total as 'balance_due' FROM invoices WHERE invoice_total - payment_total - credit_total >50 ORDER BY balance_due DESC LIMIT 5;

SELECT invoice_number, invoice_date, invoice_total - payment_total - credit_total as 'balence_due', payment_date FROM invoices WHERE payment_date IS NULL;

SELECT DATE_FORMAT(CURRENT_DATE, '%m-%d-%Y') as 'current_date';

SELECT 50000 as 'starting_principal', .065 * 50000 as 'interest',50000 *1.065 as 'principal_plus_interest';