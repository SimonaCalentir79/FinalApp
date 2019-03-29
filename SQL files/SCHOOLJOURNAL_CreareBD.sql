--DROP TABLE UserAccount;
--DROP TABLE Timetable;
--DROP TABLE TermReport;
--DROP TABLE Homework;
--DROP TABLE Grade;
--DROP TABLE Course;
--DROP TABLE Semester;
--DROP TABLE Student;
--DROP TABLE Teacher;

CREATE TABLE Teacher
(
	TeacherID INT IDENTITY(1,1) PRIMARY KEY,
	TeacherName VARCHAR(150) NOT NULL,
	TeacherEmail VARCHAR(100),
	TeacherPhone VARCHAR(100)
)

CREATE TABLE Student
(
	StudentID INT IDENTITY(1,1) PRIMARY KEY,
	StudentName VARCHAR(150) NOT NULL,
	StudentPhoto VARCHAR(200) NULL,
	Observations VARCHAR(200) NULL
)

CREATE TABLE Semester
(
	SemesterID INT IDENTITY(1,1) PRIMARY KEY,
	SemesterNumber INT NOT NULL,
	SchoolYear CHAR(9) NOT NULL
)

CREATE TABLE Course
(
	CourseID INT IDENTITY(1,1) PRIMARY KEY,
	CourseName VARCHAR(200),
	LevelYear INT NOT NULL,
	TeacherID INT,
	CONSTRAINT FK_Subjects_TeacherID FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID)
)

CREATE TABLE Grade
(
	GradeID INT IDENTITY(1,1) PRIMARY KEY,
	StudentID INT NOT NULL,
	SemesterID INT NOT NULL,
	CourseID INT NOT NULL,
	Mark NUMERIC(4,2) NOT NULL,
	DateOfMark DATE DEFAULT GETDATE(),
	GradingWeight NUMERIC(4,2) NOT NULL,
	Observations VARCHAR(200),
	CONSTRAINT FK_Grades_StudentID FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
	CONSTRAINT FK_Grades_SemesterID FOREIGN KEY (SemesterID) REFERENCES Semester(SemesterID),
	CONSTRAINT FK_Grades_CourseID FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
)

CREATE TABLE Homework
(
	HomeworkID INT IDENTITY(1,1) PRIMARY KEY,
	StudentID INT NOT NULL,
	CourseID INT NOT NULL,
	DateOfHomework DATE DEFAULT GETDATE(),
	DueDate DATE DEFAULT GETDATE()+1,
	Details VARCHAR(500) NOT NULL,
	HomeworkStatus VARCHAR(50) DEFAULT 'TO DO' NOT NULL,
	CONSTRAINT FK_Homework_StudentID FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
	CONSTRAINT FK_Homework_CourseIDD FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
	CONSTRAINT CK_Homework_HWStatus CHECK (HomeworkStatus IN ('TO DO','IN PROGRESS','FINISHED'))
)

CREATE TABLE TermReport
(
	ReportID INT IDENTITY(1,1) PRIMARY KEY,
	StudentID INT NOT NULL,
	SemesterID INT NOT NULL,
	CourseID INT NOT NULL,
	AverageGrade NUMERIC(4,2) DEFAULT 0.00 NOT NULL,
	CONSTRAINT FK_TermReports_StudentID FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
	CONSTRAINT FK_TermReports_SemesterID FOREIGN KEY (SemesterID) REFERENCES Semester(SemesterID),
	CONSTRAINT FK_TermReports_CourseID FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
)

CREATE TABLE Timetable
(
	TimetableID INT IDENTITY(1,1) PRIMARY KEY,
	StudentID INT NOT NULL,
	DayOfTheWeek VARCHAR(50) NOT NULL,
	TimeInterval VARCHAR(50) NOT NULL,
	CourseID INT NOT NULL,
	CONSTRAINT FK_Timetable_StudentID FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
	CONSTRAINT FK_Timetable_CourseID FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
)

CREATE TABLE UserAccount
(
	UserID INT IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR(200) NOT NULL,
	LastName VARCHAR(200) NOT NULL,
	Email VARCHAR(200) NOT NULL,
	Username VARCHAR(200) UNIQUE,
	Password VARCHAR(200) NOT NULL,
	ConfirmPassword VARCHAR(200) NOT NULL
)