--DROP TABLE Homework;
--DROP TABLE Grades;
--DROP TABLE Subjects;
--DROP TABLE GradeCategory;
--DROP TABLE Semesters;
--DROP TABLE Teachers;
--DROP TABLE Students;
--DROP TABLE Persons;

CREATE TABLE Persons
(
	PersonID INT IDENTITY(1,1) PRIMARY KEY,
	PersonName VARCHAR(150) NOT NULL,
	PersonEmail VARCHAR(100),
	PersonPhone VARCHAR(100),
	PersonAddress VARCHAR(250)
)

CREATE TABLE Students
(
	StudentID INT IDENTITY(1,1) PRIMARY KEY,
	PersonID INT NOT NULL,
	CONSTRAINT FK_Students_PersonID FOREIGN KEY (PersonID) REFERENCES Persons(PersonID)
)

CREATE TABLE Teachers
(
	TeacherID INT IDENTITY(1,1) PRIMARY KEY,
	PersonID INT NOT NULL,
	CONSTRAINT FK_Teachers_PersonID FOREIGN KEY (PersonID) REFERENCES Persons(PersonID)
)

CREATE TABLE Semesters
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

CREATE TABLE Subjects
(
	SubjectID INT IDENTITY(1,1) PRIMARY KEY,
	SubjectName VARCHAR(200),
	LevelYear INT NOT NULL,
	TeacherID INT,
	CONSTRAINT FK_Subjects_TeacherID FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID)
)

CREATE TABLE Grades
(
	GradeID INT IDENTITY(1,1) PRIMARY KEY,
	StudentID INT NOT NULL,
	SemesterID INT NOT NULL,
	SubjectID INT NOT NULL,
	CategoryID INT NOT NULL,
	Grade NUMERIC(4,2) NOT NULL,
	DateOfGrade DATE,
	Observations VARCHAR(200)
	CONSTRAINT FK_Grades_StudentID FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_Grades_SemesterID FOREIGN KEY (SemesterID) REFERENCES Semesters(SemesterID),
	CONSTRAINT FK_Grades_SubjectID FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID),
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
	CONSTRAINT FK_Homework_StudentID FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_Homework_SubjectID FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
)