-- cd C:\Program Files\MySQL\MySQL Server 5.6\bin
-- cd C:\xampp\mysql\bin

-- mysql -u root -p < G:\sql\db_setup\create_databases.sql
-- mysql -u root -p < G:\sql\SJA06Task2.sql > G:\mysql\SJA06Task2.out

SELECT '' AS 'your name STEVEN JOHNSTON';
SELECT '' AS 'PROG2220: Section #1';
SELECT '' AS 'Assignment #06: Task #2';

SELECT SYSDATE() AS 'Current System Date';

USE ap;

DROP PROCEDURE IF EXISTS test;

DELIMITER //

CREATE PROCEDURE test()
BEGIN
  DECLARE sql_error INT DEFAULT FALSE;
  
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    SET sql_error = TRUE;

  START TRANSACTION;
  
  UPDATE invoices
  SET vendor_id = 123
  WHERE vendor_id = 122
  AND payment_total IS NOT NULL;
	
	SELECT ROW_COUNT() AS "UPDATE: rows affected";

  DELETE FROM vendors
  WHERE vendor_id = 122;

SELECT ROW_COUNT() AS "DELET: rows affected";

  UPDATE vendors
  SET vendor_name = 'FedUP'
  WHERE vendor_id = 123;

SELECT ROW_COUNT() AS "UPDATE: rows affected";

  IF sql_error = FALSE THEN
    COMMIT;
    SELECT 'The transaction was committed.';
  ELSE
    ROLLBACK;
    SELECT 'The transaction was rolled back.';
  END IF;
END//

DELIMITER ;

CALL test();


DROP PROCEDURE IF EXISTS test;

DELIMITER //

CREATE PROCEDURE test()
BEGIN
  DECLARE sql_error INT DEFAULT FALSE;
  
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    SET sql_error = TRUE;

  START TRANSACTION;
  
  DELETE FROM invoice_line_items
  WHERE invoice_id = 114;

SELECT ROW_COUNT() AS "DELET: rows affected";

  DELETE FROM invoices
  WHERE invoice_id = 114;

SELECT ROW_COUNT() AS "DELET: rows affected";

  COMMIT;
  
  IF sql_error = FALSE THEN
    COMMIT;
    SELECT 'The transaction was committed.';
  ELSE
    ROLLBACK;
    SELECT 'The transaction was rolled back.';
  END IF;
END//

DELIMITER ;

CALL test();