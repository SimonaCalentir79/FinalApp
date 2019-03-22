INSERT INTO Teacher(TeacherName,TeacherEmail) VALUES ('Teacher01','teacher01@email.com');
INSERT INTO Teacher(TeacherName,TeacherEmail) VALUES ('Teacher02','teacher02@email.com');
INSERT INTO Teacher(TeacherName,TeacherEmail) VALUES ('Teacher03','teacher03@email.com');
INSERT INTO Teacher(TeacherName,TeacherEmail) VALUES ('Teacher04','teacher04@email.com');
INSERT INTO Teacher(TeacherName,TeacherEmail) VALUES ('Teacher05','teacher05@email.com');
INSERT INTO Teacher(TeacherName,TeacherEmail) VALUES ('Teacher06','teacher06@email.com');
INSERT INTO Teacher(TeacherName,TeacherEmail) VALUES ('Teacher07','teacher07@email.com');
INSERT INTO Teacher(TeacherName,TeacherEmail) VALUES ('Teacher08','teacher08@email.com');
INSERT INTO Teacher(TeacherName,TeacherEmail) VALUES ('Teacher09','teacher09@email.com');
INSERT INTO Teacher(TeacherName,TeacherEmail) VALUES ('Teacher10','teacher10@email.com');

INSERT INTO Student(StudentName) VALUES ('Luca-Bogdan');
INSERT INTO Student(StudentName) VALUES ('Matei-Calin');

INSERT INTO Semester(SemesterNumber,SchoolYear) VALUES (1,'2017-2018');
INSERT INTO Semester(SemesterNumber,SchoolYear) VALUES (2,'2017-2018');
INSERT INTO Semester(SemesterNumber,SchoolYear) VALUES (1,'2018-2019');
INSERT INTO Semester(SemesterNumber,SchoolYear) VALUES (2,'2018-2019');

INSERT INTO Course(CourseName,LevelYear,TeacherID) VALUES ('Matematica',3,4);
INSERT INTO Course(CourseName,LevelYear,TeacherID) VALUES ('Limba Romana',3,4);
INSERT INTO Course(CourseName,LevelYear,TeacherID) VALUES ('Limba Engleza',3,7);
INSERT INTO Course(CourseName,LevelYear,TeacherID) VALUES ('Informatica',3,5);
INSERT INTO Course(CourseName,LevelYear,TeacherID) VALUES ('Arte vizuale',3,4);
INSERT INTO Course(CourseName,LevelYear,TeacherID) VALUES ('Educatie fizica',3,4);
INSERT INTO Course(CourseName,LevelYear,TeacherID) VALUES ('Educatie sociala',3,4);
INSERT INTO Course(CourseName,LevelYear,TeacherID) VALUES ('Matematica',5,5);
INSERT INTO Course(CourseName,LevelYear,TeacherID) VALUES ('Limba Romana',5,6);
INSERT INTO Course(CourseName,LevelYear,TeacherID) VALUES ('Limba Engleza',5,7);
INSERT INTO Course(CourseName,LevelYear,TeacherID) VALUES ('Limba germana',5,8);
INSERT INTO Course(CourseName,LevelYear,TeacherID) VALUES ('Biologie',5,1);
INSERT INTO Course(CourseName,LevelYear,TeacherID) VALUES ('Istorie',5,2);
INSERT INTO Course(CourseName,LevelYear,TeacherID) VALUES ('Georgrafie',5,6);
INSERT INTO Course(CourseName,LevelYear,TeacherID) VALUES ('Informatica',5,5);

INSERT INTO Grade(StudentID,SemesterID,CourseID,Mark,GradingWeight) VALUES (1,1,1,10,1.00);
INSERT INTO Grade(StudentID,SemesterID,CourseID,Mark,GradingWeight) VALUES (1,1,1,6,1.00);
INSERT INTO Grade(StudentID,SemesterID,CourseID,Mark,GradingWeight) VALUES (1,1,2,10,0.6);
INSERT INTO Grade(StudentID,SemesterID,CourseID,Mark,GradingWeight) VALUES (1,1,2,10,0.6);
INSERT INTO Grade(StudentID,SemesterID,CourseID,Mark,GradingWeight) VALUES (1,1,2,10,0.4);

INSERT INTO Homework(StudentID,CourseID,Details) VALUES (2,9,'details about homework');

INSERT INTO Timetable(StudentID,DayOfTheWeek,TimeInterval,CourseID) VALUES (1,'LUNI','08:00 - 08:50',8);


