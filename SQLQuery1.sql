create table movies
(
	id int primary key identity(1,1),
	movie_id varchar(max) null,
	movie_name varchar(max) null,
	gener varchar(max) null,
	price float null,
	capacity int null,
	movie_image varchar(max) null,
	status varchar(max) null,
	create_at datetime null,
	update_date date null,
	delete_date date null
)
drop table movies
select * from movies
select * from taikhoan
SELECT * FROM MOVIES WHERE status = 'Available' and DELETE_DATE IS NULL
CREATE TABLE customers(

id INT PRIMARY KEY IDENTITY(1,1),
movie_id VARCHAR(MAX) NULL,
seat_type VARCHAR(MAX) NULL,
available_seat INT NULL,
totalPrice FLOAT NULL,
foods VARCHAR (MAX) NULL,
drinks VARCHAR(MAX) NULL,
amount FLOAT NULL,
change FLOAT NULL,
status VARCHAR(MAX) NULL,
date_buy DATETIME NULL

)

SELECT * FROM customers

CREATE TABLE buy_tickets (
    id INT PRIMARY KEY IDENTITY(1,1),
    movie_id VARCHAR(MAX) NULL,
    seat_number INT NULL, 
	price float,
	amount float,
	charge float,
    status VARCHAR(MAX) NULL,
    create_at DATETIME NULL
);
drop table buy_tickets

SELECT *
FROM movies
LEFT JOIN buy_tickets ON movies.movie_id = buy_tickets.movie_id;
SELECT capacity FROM  MOVIES WHERE DELETE_DATE is NULL AND STATUS != 'DELETED'
SELECT SEAT_NUMBER 
FROM buy_tickes 
WHERE MOVIE_ID = 'ab';
SELECT capacity FROM MOVIES WHERE DELETE_DATE IS NULL AND STATUS != 'Deleted' AND movie_id = 'ab';
SELECT SEAT_NUMBER FROM BUY_TICKETS WHERE MOVIE_ID = 'ab';
SELECT * FROM buy_tickets
SELECT MOVIE_ID ,PRICE FROM MOVIES
SELECT count(MATAIKHOAN) as totalstaff FROM TAIKHOAN WHERE LOAITAIKHOAN = 'STAFF' AND TRANGTHAI = 'ACTIVE'
SELECT COUNT(ID) AS TOTALBUY FROM buy_tickets WHERE STATUS = 'paid'
SELECT sum(price) AS TOTALBUY FROM buy_tickets WHERE STATUS = 'paid'
SELECT MOVIE_ID, MOVIE_NAME, GENER, PRICE, CAPACITY, MOVIE_IMAGE, STATUS
FROM MOVIES
WHERE DELETE_DATE IS NULL;


