-- cd C:\Program Files\MySQL\MySQL Server 5.6\bin
-- cd C:\xampp\mysql\bin

-- mysql -u root -p < G:\sql\db_setup\create_databases.sql
-- mysql -u root -p < G:\sql\SJA01Task1.sql > G:\mysql\SJA02Task2.out

SELECT '' AS 'STEVEN JOHNSTON';
SELECT '' AS 'PROG2220: Section #1';
SELECT '' AS 'Assignment #02: Task #2';

SELECT SYSDATE() AS 'Current System Date';

use swexpert;
SELECT DISTINCT c_city as "city"
	FROM consultant ORDER BY c_city asc;
SELECT p_id,project_name 
	FROM project WHERE parent_p_id IS NOT null;
SELECT v1.p_id,v1.project_name,v1.parent_p_id, v1.project_name 
	FROM project v1 join project v2;
SELECT c_id, skill_id,certification 
	from consultant_skill where certification="Y" 
	ORDER BY skill_id,c_id;
SELECT consultant.c_id,c_last,c_first,skill.skill_id,skill_description 
	from consultant_skill join consultant join skill
	WHERE certification = "y" 
	GROUP BY consultant.c_id
	ORDER BY skill.skill_id,consultant.c_id;