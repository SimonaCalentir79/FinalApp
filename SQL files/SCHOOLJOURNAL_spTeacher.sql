create or alter procedure spGetAllTeachers
as
begin
	select * from Teacher
end

create or alter procedure spGetTeacherByID
(
	@TeacherID integer
)
as begin
	select * from Teacher where TeacherID=@TeacherID
end

create or alter procedure spAddTeacher
(
	@TeacherName varchar(150),
	@TeacherEmail varchar(100) null,
	@TeacherPhone varchar(100) null
)
as
begin
	insert into Teacher(TeacherName,TeacherEmail,TeacherPhone)
	values (@TeacherName,@TeacherEmail,@TeacherPhone)
end


create or alter procedure spUpdateTeacher
(
	@TeacherID INTEGER,
	@TeacherName varchar(150),
	@TeacherEmail varchar(100) null,
	@TeacherPhone varchar(100) null
)
as
begin
	update Teacher set TeacherName=@TeacherName,TeacherEmail=@TeacherEmail,TeacherPhone=@TeacherPhone 
	where TeacherID=@TeacherID
end

create or alter procedure spDeleteTeacher
(
	@TeacherID INTEGER
)
as
begin
	delete from Teacher where TeacherID=@TeacherID
end