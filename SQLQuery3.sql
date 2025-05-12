create table maintenance
(
	id int primary key identity(1,1),
	ename nvarchar(max) null,
	date date null ,
	describe nvarchar(max) null,
	movie_image varchar(max) null,
	ecurrent varchar(max) null default 'wait'
)
drop table maintenance