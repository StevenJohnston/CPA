-- cd C:\Program Files\MySQL\MySQL Server 5.6\bin
-- cd C:\xampp\mysql\bin

-- mysql -u root -p < G:\sql\swexpert\swexpert\swexpert.sql
-- mysql -u root -p < G:\sql\SJA04Task3.sql > G:\mysql\SJA04Task3.out

SELECT '' AS 'your name STEVEN JOHNSTON';
SELECT '' AS 'PROG2220: Section #1';
SELECT '' AS 'Assignment #04: Task #3';

SELECT SYSDATE() AS 'Current System Date';

USE swexpert;

INSERT INTO consultant (c_id,c_last,c_first,c_mi,c_add,c_city,c_state,c_zip,c_phone,c_email)
VALUES(106,"Johnston","Steven","D","123street","Kitchener","WS",55555,5195555555,"steven@Postcloset.com");

SELECT ROW_COUNT() AS "INSERT: rows affected";

INSERT INTO client (client_id,client_name,contact_last,contact_first,contact_phone)
VALUES (7,"City of Kitchener","Zehr","Carl",5197778888);

SELECT ROW_COUNT() AS "INSERT: rows affected";

INSERT INTO project (p_id,project_name,client_id)
VALUES(99,"New Business",106);

SELECT ROW_COUNT() AS "INSERT: rows affected";

UPDATE project p SET p.parent_p_id = (
	SELECT parent_p_id FROM (SELECT * FROM project) 
	AS p2 WHERE p2.p_id = LAST_INSERT_ID()) 
WHERE p.parent_p_id IS NULL;

