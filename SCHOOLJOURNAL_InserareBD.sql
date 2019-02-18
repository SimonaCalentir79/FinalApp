INSERT INTO Persons(PersonName,PersonEmail) VALUES ('Person01','person01@email.com');
INSERT INTO Persons(PersonName,PersonEmail) VALUES ('Person02','person02@email.com');
INSERT INTO Persons(PersonName,PersonEmail) VALUES ('Person03','person03@email.com');
INSERT INTO Persons(PersonName,PersonEmail) VALUES ('Person04','person04@email.com');
INSERT INTO Persons(PersonName,PersonEmail) VALUES ('Person05','person05@email.com');
INSERT INTO Persons(PersonName,PersonEmail) VALUES ('Person06','person06@email.com');
INSERT INTO Persons(PersonName,PersonEmail) VALUES ('Person07','person07@email.com');
INSERT INTO Persons(PersonName,PersonEmail) VALUES ('Person08','person08@email.com');
INSERT INTO Persons(PersonName,PersonEmail) VALUES ('Person09','person09@email.com');
INSERT INTO Persons(PersonName,PersonEmail) VALUES ('Person10','person10@email.com');

INSERT INTO Students(PersonID) VALUES (1);
INSERT INTO Students(PersonID) VALUES (2);

INSERT INTO Teachers(PersonID) VALUES (3);
INSERT INTO Teachers(PersonID) VALUES (4);
INSERT INTO Teachers(PersonID) VALUES (5);
INSERT INTO Teachers(PersonID) VALUES (6);
INSERT INTO Teachers(PersonID) VALUES (7);
INSERT INTO Teachers(PersonID) VALUES (8);
INSERT INTO Teachers(PersonID) VALUES (9);
INSERT INTO Teachers(PersonID) VALUES (10);

INSERT INTO Semesters(SemesterNumber,SchoolYear) VALUES (1,'2017-2018');
INSERT INTO Semesters(SemesterNumber,SchoolYear) VALUES (2,'2017-2018');
INSERT INTO Semesters(SemesterNumber,SchoolYear) VALUES (1,'2018-2019');
INSERT INTO Semesters(SemesterNumber,SchoolYear) VALUES (2,'2018-2019');

INSERT INTO GradeCategory(CategoryName,Share) VALUES ('Nota',0.75);
INSERT INTO GradeCategory(CategoryName,Share) VALUES ('Nota',1.00);
INSERT INTO GradeCategory(CategoryName,Share) VALUES ('Teza',0.25);

INSERT INTO Subjects(SubjectName,LevelYear,TeacherID) VALUES ('Matematica',3,4);
INSERT INTO Subjects(SubjectName,LevelYear,TeacherID) VALUES ('Limba Romana',3,4);
INSERT INTO Subjects(SubjectName,LevelYear,TeacherID) VALUES ('Limba Engleza',3,7);
INSERT INTO Subjects(SubjectName,LevelYear,TeacherID) VALUES ('Informatica',3,5);
INSERT INTO Subjects(SubjectName,LevelYear,TeacherID) VALUES ('Arte vizuale',3,4);
INSERT INTO Subjects(SubjectName,LevelYear,TeacherID) VALUES ('Educatie fizica',3,4);
INSERT INTO Subjects(SubjectName,LevelYear,TeacherID) VALUES ('Educatie sociala',3,4);
INSERT INTO Subjects(SubjectName,LevelYear,TeacherID) VALUES ('Matematica',5,5);
INSERT INTO Subjects(SubjectName,LevelYear,TeacherID) VALUES ('Limba Romana',5,6);
INSERT INTO Subjects(SubjectName,LevelYear,TeacherID) VALUES ('Limba Engleza',5,7);
INSERT INTO Subjects(SubjectName,LevelYear,TeacherID) VALUES ('Limba germana',5,8);
INSERT INTO Subjects(SubjectName,LevelYear,TeacherID) VALUES ('Biologie',5,1);
INSERT INTO Subjects(SubjectName,LevelYear,TeacherID) VALUES ('Istorie',5,2);
INSERT INTO Subjects(SubjectName,LevelYear,TeacherID) VALUES ('Georgrafie',5,6);
INSERT INTO Subjects(SubjectName,LevelYear,TeacherID) VALUES ('Informatica',5,5);

INSERT INTO Grades(StudentID,SemesterID,SubjectID,CategoryID,Grade) VALUES (1,1,1,1,10);
INSERT INTO Grades(StudentID,SemesterID,SubjectID,CategoryID,Grade) VALUES (1,1,3,1,10);
INSERT INTO Grades(StudentID,SemesterID,SubjectID,CategoryID,Grade) VALUES (1,2,5,1,10);
INSERT INTO Grades(StudentID,SemesterID,SubjectID,CategoryID,Grade) VALUES (1,2,7,1,10);
INSERT INTO Grades(StudentID,SemesterID,SubjectID,CategoryID,Grade) VALUES (2,1,8,1,10);
INSERT INTO Grades(StudentID,SemesterID,SubjectID,CategoryID,Grade) VALUES (2,1,10,1,10);
INSERT INTO Grades(StudentID,SemesterID,SubjectID,CategoryID,Grade) VALUES (2,2,9,1,10);
INSERT INTO Grades(StudentID,SemesterID,SubjectID,CategoryID,Grade) VALUES (2,2,9,1,8);
INSERT INTO Grades(StudentID,SemesterID,SubjectID,CategoryID,Grade) VALUES (2,2,9,1,6);
INSERT INTO Grades(StudentID,SemesterID,SubjectID,CategoryID,Grade) VALUES (2,2,9,3,10);

INSERT INTO Homework(StudentID,SubjectID,Details) VALUES (2,9,'details about homework');
