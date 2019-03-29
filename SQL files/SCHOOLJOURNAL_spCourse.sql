create or alter procedure spGetAllCourses
as begin
	select * from Course c join Teacher t on c.TeacherID=t.TeacherID;
end

create or alter procedure spGetCourseByID
(
	@CourseID integer
)
as begin
	select * from Course c join Teacher t on c.TeacherID=t.TeacherID where CourseID=@CourseID;
end

create or alter procedure spAddCourse
(
	@CourseName varchar(200),
	@LevelYear integer,
	@TeacherID integer
)
as begin
	insert into Course(CourseName, LevelYear, TeacherID) values (@CourseName, @LevelYear, @TeacherID)
end

create or alter procedure spUpdateCourse
(
	@CourseID integer,
	@CourseName varchar(200),
	@LevelYear integer,
	@TeacherID integer
)
as begin
	update Course set CourseName=@CourseName, LevelYear=@LevelYear, TeacherID=@TeacherID where CourseID=@CourseID
end

create or alter procedure spDeleteCourse
(
	@CourseID integer
)
as begin
	delete from Course where CourseID=@CourseID
end