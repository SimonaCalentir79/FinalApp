create or alter procedure spGetAllStudents
as
begin
	select * from Student
end

create or alter procedure spAddStudent
(
	@StudentName varchar(150),
	@StudentPhoto varchar(200),
	@Observations varchar(100)
)
as
begin
	insert into Student(StudentName,StudentPhoto,Observations)
	values (@StudentName,@StudentPhoto,@Observations)
end


create or alter procedure spUpdateStudent
(
	@StudentID INTEGER,
	@StudentName varchar(150),
	@StudentPhoto varchar(200),
	@Observations varchar(100)
)
as
begin
	update Student set StudentName=@StudentName,StudentPhoto=@StudentPhoto,Observations=@Observations 
	where StudentID=@StudentID
end

create or alter procedure spDeleteStudent
(
	@StudentID INTEGER
)
as
begin
	delete from Student where StudentID=@StudentID
end