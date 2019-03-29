create or alter procedure spGetAllGrades
as begin
	select * from Grade g 
		join Student s on g.StudentID=s.StudentID 
		join Course c on g.CourseID=c.CourseID
		join Semester m on g.SemesterID=m.SemesterID
end

create or alter procedure spGetGradeByID
(
	@GradeID integer
)
as begin
	select * from Grade g 
		join Student s on g.StudentID=s.StudentID 
		join Course c on g.CourseID=c.CourseID
		join Semester m on g.SemesterID=m.SemesterID 
	where GradeID=@GradeID;
end

create or alter procedure spGetGradeByStudentID
(
	@StudentID integer
)
as begin
	select * from Grade g 
		join Student s on g.StudentID=s.StudentID 
		join Course c on g.CourseID=c.CourseID
		join Semester m on g.SemesterID=m.SemesterID
	where g.StudentID=@StudentID;
end

create or alter procedure spAddGrade
(
	@StudentID integer,
	@SemesterID integer,
	@CourseID integer,
	@Mark numeric(4,2),
	@DateOfMark date,
	@GradingWeight numeric(4,2),
	@Observations varchar(200) null
)
as begin
	insert into Grade(StudentID, SemesterID, CourseID, Mark, DateOfMark, GradingWeight, Observations) 
	values (@StudentID, @SemesterID, @CourseID, @Mark, @DateOfMark, @GradingWeight, @Observations)
end

create or alter procedure spUpdateGrade
(
	@GradeID integer,
	@StudentID integer,
	@SemesterID integer,
	@CourseID integer,
	@Mark numeric(4,2),
	@DateOfMark date,
	@GradingWeight numeric(4,2),
	@Observations varchar(200) null
)
as begin
	update Grade 
	set StudentID=@StudentID, SemesterID=@SemesterID, CourseID=@CourseID, Mark=@Mark, DateOfMark=@DateOfMark, GradingWeight=@GradingWeight, Observations=@Observations 
	where GradeID=@GradeID
end

create or alter procedure spDeleteGrade
(
	@GradeID integer
)
as begin
	delete from Grade where GradeID=@GradeID
end