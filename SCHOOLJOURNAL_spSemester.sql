create or alter procedure spGetAllSemesters
as begin
	select * from Semester
end

create or alter procedure spAddSemester
(
	@SemesterNumber integer,
	@SchoolYear char(9)
)
as begin
	insert into Semester (SemesterNumber, SchoolYear) values (@SemesterNumber, @SchoolYear)
end

create or alter procedure spUpdateSemester
(
	@SemesterID integer,
	@SemesterNumber integer,
	@SchoolYear char(9)
)
as begin
	update Semester set SemesterNumber=@SemesterNumber, SchoolYear=@SchoolYear where SemesterID=@SemesterID
end

create or alter procedure spDeleteSemester
(
	@SemesterID integer
)
as begin
	delete from Semester where SemesterID=@SemesterID
end