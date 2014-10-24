-- cd C:\Program Files\MySQL\MySQL Server 5.6\bin
-- cd C:\xampp\mysql\bin

-- mysql -u root -p < G:\mgs_ex_starts\create_my_guitar_shop.sql
-- mysql -u root -p < G:\sql\SJA06Task3.sql > G:\mysql\SJA06Task3.out

SELECT '' AS 'your name STEVEN JOHNSTON';
SELECT '' AS 'PROG2220: Section #1';
SELECT '' AS 'Assignment #06: Task #3';

SELECT SYSDATE() AS 'Current System Date';

USE my_guitar_shop;
CREATE OR REPLACE VIEW customer_addresses AS
    SELECT 
        c.customer_id,
        c.email_address,
        c.last_name,
        c.first_name,
        a.line1,
        a.line2,
        a.city,
        a.state,
        a.zip_code
    FROM
        addresses a
            JOIN
        customers c ON a.customer_id = c.customer_id
    ORDER BY c.last_name , c.first_name;

SELECT 
    customer_id, last_name, first_name, line1
FROM
    customer_addresses;

CREATE OR REPLACE VIEW order_item_products AS
    SELECT 
        o.order_id,
        o.order_date,
        o.tax_amount,
        o.ship_date,
        oi.item_price,
        oi.discount_amount,
        oi.item_price - oi.discount_amount AS 'item_total',
        oi.quantity,
        oi.quantity * (oi.item_price - oi.discount_amount) AS 'item_total',
        p.product_name
    FROM
        orders o
            JOIN
        order_items oi
            JOIN
        products p ON o.order_id = oi.order_id
            AND p.product_id = oi.product_id;

SELECT 
    order_id, product_name, item_total
FROM
    order_item_products
ORDER BY item_total DESC;

CREATE OR REPLACE VIEW product_summary AS
    SELECT DISTINCT
        oip1.product_name,
        (SELECT 
                COUNT(*)
            FROM
                order_item_products oip2
            WHERE
                oip2.product_name = oip1.product_name) AS 'order_count',
        (SELECT 
                SUM(item_total)
            FROM
                order_item_products oip3
            WHERE
                oip1.product_name = oip3.product_name) AS 'order_total'
    FROM
        order_item_products oip1;

SELECT 
    product_name
FROM
    product_summary
ORDER BY order_total DESC
LIMIT 5;