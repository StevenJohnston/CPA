-- cd C:\Program Files\MySQL\MySQL Server 5.6\bin
-- cd C:\xampp\mysql\bin

-- mysql -u root -p < G:\sql\swexpert\swexpert\swexpert.sql
-- mysql -u root -p < G:\sql\SJA05Task3.sql > G:\sql\SJA05Task3.out

SELECT '' AS 'your name STEVEN JOHNSTON';
SELECT '' AS 'PROG2220: Section #1';
SELECT '' AS 'Assignment #05: Task #3';

SELECT SYSDATE() AS 'Current System Date';

USE swexpert;

SELECT 
    ROUND(AVG(score), 2) AS average_score
FROM
    evaluation
WHERE
    evaluatee_id IN (SELECT 
            c_id
        FROM
            consultant
        WHERE
            CONCAT_WS(' ', c_first, c_last) = 'Janet Park');

SELECT 
    LPAD(p_id, 7, ' ') AS 'p_id',
    LPAD(c_id, 5, ' ') AS c_id,
    LPAD(ROUND(DATEDIFF(roll_off_date, roll_on_date) / 30.4),24,' ') AS date_difference
FROM
    project_consultant;

SELECT 
    CONCAT_WS(', ', c_first, c_last) AS c_full,
    CONCAT_WS('-',
            LEFT(c_phone, 3),
            MID(c_phone, 3, 3),
            RIGHT(c_phone, 4)) AS c_phone
FROM
    consultant
WHERE
    c_id IN (SELECT 
            c_id
        FROM
            project_consultant
        WHERE
            p_id IN (SELECT 
                    p_id
                FROM
                    project
                WHERE
                    client_id IN (SELECT 
                            client_id
                        FROM
                            client
                        WHERE
                            client_name = 'Morningstar Bank')));
DELETE FROM consultant_skill 
WHERE
    c_id = 100 AND skill_id = 4;

SELECT ROW_COUNT() AS "DELET: rows affected";

INSERT INTO consultant_skill (c_id,skill_id) VALUES (100,4);

SELECT ROW_COUNT() AS "INSERT: rows affected";

SELECT 
    LPAD(c_id, 5, ' ') AS 'c_id',
    CASE
        WHEN certification IS NULL THEN LPAD('Unknown', 11, ' ')
        WHEN certification = 'N' THEN LPAD('Not Certified', 13, ' ')
        ELSE LPAD('Certified', 15, ' ')
    END AS certification
FROM
    consultant_skill
WHERE
    skill_id = 4;