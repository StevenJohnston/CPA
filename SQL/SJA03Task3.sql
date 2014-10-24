-- cd C:\Program Files\MySQL\MySQL Server 5.6\bin
-- cd C:\xampp\mysql\bin

-- mysql -u root -p < G:\sql\db_setup\create_databases.sql
-- mysql -u root -p < G:\sql\SJA03Task2.sql > G:\sql\SJA03Task2.out

SELECT '' AS 'STEVEN JOHNSTON';
SELECT '' AS 'PROG2220: Section #1';
SELECT '' AS 'Assignment #02: Task #2';

SELECT SYSDATE() AS 'Current System Date';

USE swexpert;
SELECT e_id, ROUND(AVG(score),1) AS "average_score" 
 FROM evaluation 
 GROUP BY evaluatee_id;

SELECT COUNT(c_id) AS "number_of_skill_1"
 FROM consultant_skill 
 WHERE skill_id = 1;

SELECT c_first,c_last FROM consultant v4
JOIN(
	SELECT DISTINCT c_id 
	FROM project_consultant v1 JOIN(
		SELECT p_id 
		FROM project_consultant
		WHERE c_id = (
			SELECT c_id 
			FROM consultant 
			WHERE c_last = "Myers" AND c_first= "Mark")
		)v2
	ON v1.p_id = v2.p_id
	)v3
ON v4.c_id = v3.c_id
WHERE c_first != "Mark";

SELECT DISTINCT v1.p_id,v1.project_name 
FROM project v1
JOIN
(
	SELECT v2.p_id 
	FROM evaluation v2
	JOIN 
	(
		SELECT v3.p_id
		FROM project v3
		WHERE v3.mgr_id=
		(
			SELECT v4.c_id 
			FROM consultant v4 
			WHERE LEFT(v4.c_last , 1) = "Z"
		)
	) v5
	ON v2.p_id = v5.p_id
) v6
ON v1.p_id = v6.p_id;