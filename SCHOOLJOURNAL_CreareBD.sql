--DROP TABLE Homework;
--DROP TABLE Grade;
--DROP TABLE Subject;
--DROP TABLE GradeCategory;
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
	StudentName VARCHAR(150) NOT NULL
)

CREATE TABLE Semester
(
	SemesterID INT IDENTITY(1,1) PRIMARY KEY,
	SemesterNumber INT NOT NULL,
	SchoolYear CHAR(9) NOT NULL
)

CREATE TABLE GradeCategory
(
	CategoryID INT IDENTITY(1,1) PRIMARY KEY,
	CategoryName VARCHAR(100) NOT NULL,
	Share NUMERIC(4,2) NOT NULL
)

CREATE TABLE Subject
(
	SubjectID INT IDENTITY(1,1) PRIMARY KEY,
	SubjectName VARCHAR(200),
	LevelYear INT NOT NULL,
	TeacherID INT,
	CONSTRAINT FK_Subjects_TeacherID FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID)
)

CREATE TABLE Grade
(
	GradeID INT IDENTITY(1,1) PRIMARY KEY,
	StudentID INT NOT NULL,
	SemesterID INT NOT NULL,
	SubjectID INT NOT NULL,
	CategoryID INT NOT NULL,
	Mark NUMERIC(4,2) NOT NULL,
	DateOfGrade DATE,
	Observations VARCHAR(200)
	CONSTRAINT FK_Grades_StudentID FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
	CONSTRAINT FK_Grades_SemesterID FOREIGN KEY (SemesterID) REFERENCES Semester(SemesterID),
	CONSTRAINT FK_Grades_SubjectID FOREIGN KEY (SubjectID) REFERENCES Subject(SubjectID),
	CONSTRAINT FK_Grades_CategoryID FOREIGN KEY (CategoryID) REFERENCES GradeCategory(CategoryID)
)

CREATE TABLE Homework
(
	HomeworkID INT IDENTITY(1,1) PRIMARY KEY,
	StudentID INT NOT NULL,
	SubjectID INT NOT NULL,
	DateOfHomework DATE,
	DueDate DATE,
	Details VARCHAR(500) NOT NULL,
	CONSTRAINT FK_Homework_StudentID FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
	CONSTRAINT FK_Homework_SubjectID FOREIGN KEY (SubjectID) REFERENCES Subject(SubjectID)
)