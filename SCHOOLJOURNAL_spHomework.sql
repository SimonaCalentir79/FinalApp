create or alter procedure spGetAllHomeworks
as begin
	select * from Homework h 
		join Student s on h.StudentID=s.StudentID 
		join Course c on h.CourseID=c.CourseID;
end

create or alter procedure spAddHomework
(
	@StudentID integer,
	@CourseID integer,
	@DateOfHomework date,
	@DueDate date,
	@Details varchar(500),
	@HomeworkStatus varchar(50)
)
as begin
	insert into Homework(StudentID, CourseID, DateOfHomework, DueDate, Details, HomeworkStatus) 
	values (@StudentID, @CourseID, @DateOfHomework, @DueDate, @Details, @HomeworkStatus)
end

create or alter procedure spUpdateHomework
(
	@HomeworkID integer,
	@StudentID integer,
	@CourseID integer,
	@DateOfHomework date,
	@DueDate date,
	@Details varchar(500),
	@HomeworkStatus varchar(50)
)
as begin
	update Homework 
	set StudentID=@StudentID, CourseID=@CourseID, DateOfHomework=@DateOfHomework, DueDate=@DueDate, Details=@Details, HomeworkStatus=@HomeworkStatus 
	where HomeworkID=@HomeworkID
end

create or alter procedure spDeleteHomework
(
	@HomeworkID integer
)
as begin
	delete from Homework where HomeworkID=@HomeworkID
end