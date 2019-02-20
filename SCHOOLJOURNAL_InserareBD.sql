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

INSERT INTO Student(StudentName) VALUES ('Student01');
INSERT INTO Student(StudentName) VALUES ('Student02');

INSERT INTO Semester(SemesterNumber,SchoolYear) VALUES (1,'2017-2018');
INSERT INTO Semester(SemesterNumber,SchoolYear) VALUES (2,'2017-2018');
INSERT INTO Semester(SemesterNumber,SchoolYear) VALUES (1,'2018-2019');
INSERT INTO Semester(SemesterNumber,SchoolYear) VALUES (2,'2018-2019');

INSERT INTO GradeCategory(CategoryName,Share) VALUES ('Nota',0.75);
INSERT INTO GradeCategory(CategoryName,Share) VALUES ('Nota',1.00);
INSERT INTO GradeCategory(CategoryName,Share) VALUES ('Teza',0.25);

INSERT INTO Subject(SubjectName,LevelYear,TeacherID) VALUES ('Matematica',3,4);
INSERT INTO Subject(SubjectName,LevelYear,TeacherID) VALUES ('Limba Romana',3,4);
INSERT INTO Subject(SubjectName,LevelYear,TeacherID) VALUES ('Limba Engleza',3,7);
INSERT INTO Subject(SubjectName,LevelYear,TeacherID) VALUES ('Informatica',3,5);
INSERT INTO Subject(SubjectName,LevelYear,TeacherID) VALUES ('Arte vizuale',3,4);
INSERT INTO Subject(SubjectName,LevelYear,TeacherID) VALUES ('Educatie fizica',3,4);
INSERT INTO Subject(SubjectName,LevelYear,TeacherID) VALUES ('Educatie sociala',3,4);
INSERT INTO Subject(SubjectName,LevelYear,TeacherID) VALUES ('Matematica',5,5);
INSERT INTO Subject(SubjectName,LevelYear,TeacherID) VALUES ('Limba Romana',5,6);
INSERT INTO Subject(SubjectName,LevelYear,TeacherID) VALUES ('Limba Engleza',5,7);
INSERT INTO Subject(SubjectName,LevelYear,TeacherID) VALUES ('Limba germana',5,8);
INSERT INTO Subject(SubjectName,LevelYear,TeacherID) VALUES ('Biologie',5,1);
INSERT INTO Subject(SubjectName,LevelYear,TeacherID) VALUES ('Istorie',5,2);
INSERT INTO Subject(SubjectName,LevelYear,TeacherID) VALUES ('Georgrafie',5,6);
INSERT INTO Subject(SubjectName,LevelYear,TeacherID) VALUES ('Informatica',5,5);

INSERT INTO Grade(StudentID,SemesterID,SubjectID,CategoryID,Mark) VALUES (1,1,1,1,10);
INSERT INTO Grade(StudentID,SemesterID,SubjectID,CategoryID,Mark) VALUES (1,1,3,1,10);
INSERT INTO Grade(StudentID,SemesterID,SubjectID,CategoryID,Mark) VALUES (1,2,5,1,10);
INSERT INTO Grade(StudentID,SemesterID,SubjectID,CategoryID,Mark) VALUES (1,2,7,1,10);
INSERT INTO Grade(StudentID,SemesterID,SubjectID,CategoryID,Mark) VALUES (2,1,8,1,10);
INSERT INTO Grade(StudentID,SemesterID,SubjectID,CategoryID,Mark) VALUES (2,1,10,1,10);
INSERT INTO Grade(StudentID,SemesterID,SubjectID,CategoryID,Mark) VALUES (2,2,9,1,10);
INSERT INTO Grade(StudentID,SemesterID,SubjectID,CategoryID,Mark) VALUES (2,2,9,1,8);
INSERT INTO Grade(StudentID,SemesterID,SubjectID,CategoryID,Mark) VALUES (2,2,9,1,6);
INSERT INTO Grade(StudentID,SemesterID,SubjectID,CategoryID,Mark) VALUES (2,2,9,3,10);

INSERT INTO Homework(StudentID,SubjectID,Details) VALUES (2,9,'details about homework');
