create or alter procedure spGetAllTimetables
as begin
	select * from Timetable t 
		join Student s on t.StudentID=s.StudentID 
		join Course c on t.CourseID=c.CourseID;
end

create or alter procedure spGetTimetableByID
(
	@TimetableID integer
)
as begin
	select * from Timetable t 
		join Student s on t.StudentID=s.StudentID 
		join Course c on t.CourseID=c.CourseID
	where t.TimetableID=@TimetableID;
end

create or alter procedure spGetTimetableByStudentID
(
	@StudentID integer
)
as begin
	select * from Timetable t 
		join Student s on t.StudentID=s.StudentID 
		join Course c on T.CourseID=c.CourseID
	where s.StudentID=@StudentID;
end

create or alter procedure spAddTimetable
(
	@StudentID integer,
	@DayOfTheWeek varchar(50),
	@TimeInterval varchar(50),
	@CourseID integer
)
as begin
	insert into Timetable(StudentID,DayOfTheWeek,TimeInterval,CourseID) 
	values (@StudentID,@DayOfTheWeek,@TimeInterval,@CourseID)
end

create or alter procedure spUpdateTimetable
(
	@TimetableID integer,
	@StudentID integer,
	@DayOfTheWeek varchar(50),
	@TimeInterval varchar(50),
	@CourseID integer
)
as begin
	update Timetable 
	set StudentID=@StudentID,DayOfTheWeek=@DayOfTheWeek,TimeInterval=@TimeInterval,CourseID=@CourseID
	where TimetableID=@TimetableID
end

create or alter procedure spDeleteTimetable
(
	@TimetableID integer
)
as begin
	delete from Timetable where TimetableID=@TimetableID
end