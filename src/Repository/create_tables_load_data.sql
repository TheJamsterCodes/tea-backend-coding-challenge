-- For use with PostgreSQL only

-- Create the Department table.
DROP TABLE IF EXISTS Department;

CREATE TABLE Department
(
	DepartmentID integer NOT NULL,
	Name character varying(50) NOT NULL,
	Budget money NOT NULL,
	StartDate date NOT NULL,
	Administrator int NULL,
	CONSTRAINT Department_pkey PRIMARY KEY (DepartmentID)
)

TABLESPACE pg_default;
ALTER TABLE Department OWNER to postgres;
    
-- Create the Person table.
DROP TABLE IF EXISTS Person;

CREATE TABLE Person
(
	PersonID integer GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	LastName varchar(50) NOT NULL,
	FirstName varchar(50) NOT NULL,
	HireDate date NULL,
	EnrollmentDate date NULL,
	Discriminator varchar(50) NOT NULL,
	CONSTRAINT Person_pkey PRIMARY KEY (PersonID)
)
							
TABLESPACE pg_default;
ALTER TABLE Person OWNER to postgres;

-- Create the OnsiteCourse table.
DROP TABLE IF EXISTS OnsiteCourse;

CREATE TABLE OnsiteCourse
(
	CourseID integer NOT NULL,
	Location varchar(50) NOT NULL,
	Days varchar(50) NOT NULL,
	Time time NOT NULL,
	CONSTRAINT OnsiteCource_pkey PRIMARY KEY (CourseID)
)

TABLESPACE pg_default;
ALTER TABLE OnsiteCourse OWNER to postgres;

-- Create the OnlineCourse table.
DROP TABLE IF EXISTS OnlineCourse;

CREATE TABLE OnlineCourse
(
	CourseID integer NOT NULL,
	URL varchar(100) NOT NULL,
	CONSTRAINT OnlineCourse_pkey PRIMARY KEY (CourseID)
)

TABLESPACE pg_default;
ALTER TABLE OnlineCourse OWNER to postgres;

--Create the StudentGrade table.
DROP TABLE IF EXISTS StudentGrade;

CREATE TABLE StudentGrade
(
	EnrollmentID integer GENERATED ALWAYS AS IDENTITY(START WITH 1 INCREMENT BY 1) NOT NULL,
	CourseID integer NOT NULL,
	StudentID integer NOT NULL,
	Grade decimal(3, 2) NULL,
	CONSTRAINT StudentGrade_pkey PRIMARY KEY (EnrollmentID)
)

TABLESPACE pg_default;
ALTER TABLE StudentGrade OWNER to postgres;

-- Create the CourseInstructor table.
DROP TABLE IF EXISTS CourseInstructor;

CREATE TABLE CourseInstructor
(
	CourseID integer NOT NULL,
	PersonID integer NOT NULL,
	CONSTRAINT CourseInstructor_pkey PRIMARY KEY (CourseID, PersonID)
)

TABLESPACE pg_default;
ALTER TABLE CourseInstructor OWNER to postgres;

-- Create the Course table.
DROP TABLE IF EXISTS Course;

CREATE TABLE Course
(
	CourseID integer NOT NULL,
	Title varchar(100) NOT NULL,
	Credits integer NOT NULL,
	DepartmentID integer NOT NULL,
	CONSTRAINT Course_pkey PRIMARY KEY (CourseID)
)

TABLESPACE pg_default;
ALTER TABLE Course OWNER to postgres;

-- Create the OfficeAssignment table.
DROP TABLE IF EXISTS OfficeAssignment;

CREATE TABLE OfficeAssignment
(
	InstructorID integer NOT NULL,
	Location varchar(50) NOT NULL,
	Timestamp timestamp NOT NULL,
	CONSTRAINT OfficeAssignment_pkey PRIMARY KEY (InstructorID)
)

TABLESPACE pg_default;
ALTER TABLE OfficeAssignment OWNER to postgres;

-- Define the relationship between OnsiteCourse and Course.
ALTER TABLE OnsiteCourse
ADD CONSTRAINT FK_OnsiteCourse_Course FOREIGN KEY(CourseID)
REFERENCES Course (CourseID);

ALTER TABLE OnsiteCourse 
VALIDATE CONSTRAINT FK_OnsiteCourse_Course;

-- Define the relationship between OnlineCourse and Course.
ALTER TABLE OnlineCourse
ADD CONSTRAINT FK_OnlineCourse_Course FOREIGN KEY(CourseID)
REFERENCES Course (CourseID);

ALTER TABLE OnlineCourse
VALIDATE CONSTRAINT FK_OnlineCourse_Course;

-- Define the relationship between StudentGrade and Course.
ALTER TABLE StudentGrade
ADD CONSTRAINT FK_StudentGrade_Course FOREIGN KEY(CourseID)
REFERENCES Course (CourseID);

ALTER TABLE StudentGrade
VALIDATE CONSTRAINT FK_StudentGrade_Course;

--Define the relationship between StudentGrade and Student.
ALTER TABLE StudentGrade
ADD CONSTRAINT FK_StudentGrade_Student FOREIGN KEY(StudentID)
REFERENCES Person (PersonID);

ALTER TABLE StudentGrade 
VALIDATE CONSTRAINT FK_StudentGrade_Student;

-- Define the relationship between CourseInstructor and Course.
ALTER TABLE CourseInstructor
ADD CONSTRAINT FK_CourseInstructor_Course FOREIGN KEY(CourseID)
REFERENCES Course (CourseID);

ALTER TABLE CourseInstructor 
VALIDATE CONSTRAINT FK_CourseInstructor_Course;

-- Define the relationship between CourseInstructor and Person.
ALTER TABLE CourseInstructor
ADD CONSTRAINT FK_CourseInstructor_Person FOREIGN KEY(PersonID)
REFERENCES Person (PersonID);

ALTER TABLE CourseInstructor
VALIDATE CONSTRAINT FK_CourseInstructor_Person;

-- Define the relationship between Course and Department.
ALTER TABLE Course
ADD CONSTRAINT FK_Course_Department FOREIGN KEY(DepartmentID)
REFERENCES Department (DepartmentID);

ALTER TABLE Course
VALIDATE CONSTRAINT FK_Course_Department;

--Define the relationship between OfficeAssignment and Person.
ALTER TABLE OfficeAssignment
ADD CONSTRAINT FK_OfficeAssignment_Person FOREIGN KEY(InstructorID)
REFERENCES Person (PersonID);

ALTER TABLE OfficeAssignment
VALIDATE CONSTRAINT FK_OfficeAssignment_Person;

-- Insert into Person table
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Abercrombie', 'Kim', '1995-03-11', null, 'Instructor');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Barzdukas', 'Gytis', null, '2005-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Justice', 'Peggy', null, '2001-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Fakhouri', 'Fadi', '2002-08-06', null, 'Instructor');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Harui', 'Roger', '1998-07-01', null, 'Instructor');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Li', 'Yan', null, '2002-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Norman', 'Laura', null, '2003-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Olivotto', 'Nino', null, '2005-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Tang', 'Wayne', null, '2005-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Alonso', 'Meredith', null, '2002-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Lopez', 'Sophia', null, '2004-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Browning', 'Meredith', null, '2000-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Anand', 'Arturo', null, '2003-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Walker', 'Alexandra', null, '2000-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Powell', 'Carson', null, '2004-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Jai', 'Damien', null, '2001-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Carlson', 'Robyn', null, '2005-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Zheng', 'Roger', '2004-02-12', null, 'Instructor');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Bryant', 'Carson', null, '2001-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Suarez', 'Robyn', null, '2004-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Holt', 'Roger', null, '2004-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Alexander', 'Carson', null, '2005-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Morgan', 'Isaiah', null, '2001-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Martin', 'Randall', null, '2005-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Kapoor', 'Candace', '2001-01-15', null, 'Instructor');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Rogers', 'Cody', null, '2002-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Serrano', 'Stacy', '1999-06-01', null, 'Instructor');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('White', 'Anthony', null, '2001-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Griffin', 'Rachel', null, '2004-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Shan', 'Alicia', null, '2003-09-01', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Stewart', 'Jasmine', '1997-10-12', null, 'Instructor');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Xu', 'Kristen', '2001-7-23', null, 'Instructor');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Gao', 'Erica', null, '2003-01-30', 'Student');
INSERT INTO Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator)
VALUES ('Van Houten', 'Roger', '2000-12-07', null, 'Instructor');

-- Insert data into the Department table.
INSERT INTO Department (DepartmentID, Name, Budget, StartDate, Administrator)
VALUES (1, 'Engineering', 350000.00, '2007-09-01', 2);
INSERT INTO Department (DepartmentID, Name, Budget, StartDate, Administrator)
VALUES (2, 'English', 120000.00, '2007-09-01', 6);
INSERT INTO Department (DepartmentID, Name, Budget, StartDate, Administrator)
VALUES (4, 'Economics', 200000.00, '2007-09-01', 4);
INSERT INTO Department (DepartmentID, Name, Budget, StartDate, Administrator)
VALUES (7, 'Mathematics', 250000.00, '2007-09-01', 3);

-- Insert data into the Course table.
INSERT INTO Course (CourseID, Title, Credits, DepartmentID)
VALUES (1050, 'Chemistry', 4, 1);
INSERT INTO Course (CourseID, Title, Credits, DepartmentID)
VALUES (1061, 'Physics', 4, 1);
INSERT INTO Course (CourseID, Title, Credits, DepartmentID)
VALUES (1045, 'Calculus', 4, 7);
INSERT INTO Course (CourseID, Title, Credits, DepartmentID)
VALUES (2030, 'Poetry', 2, 2);
INSERT INTO Course (CourseID, Title, Credits, DepartmentID)
VALUES (2021, 'Composition', 3, 2);
INSERT INTO Course (CourseID, Title, Credits, DepartmentID)
VALUES (2042, 'Literature', 4, 2);
INSERT INTO Course (CourseID, Title, Credits, DepartmentID)
VALUES (4022, 'Microeconomics', 3, 4);
INSERT INTO Course (CourseID, Title, Credits, DepartmentID)
VALUES (4041, 'Macroeconomics', 3, 4);
INSERT INTO Course (CourseID, Title, Credits, DepartmentID)
VALUES (4061, 'Quantitative', 2, 4);
INSERT INTO Course (CourseID, Title, Credits, DepartmentID)
VALUES (3141, 'Trigonometry', 4, 7);

-- Insert data into the OnlineCourse table.
INSERT INTO OnlineCourse (CourseID, URL)
VALUES (2030, 'http://www.fineartschool.net/Poetry');
INSERT INTO OnlineCourse (CourseID, URL)
VALUES (2021, 'http://www.fineartschool.net/Composition');
INSERT INTO OnlineCourse (CourseID, URL)
VALUES (4041, 'http://www.fineartschool.net/Macroeconomics');
INSERT INTO OnlineCourse (CourseID, URL)
VALUES (3141, 'http://www.fineartschool.net/Trigonometry');

--Insert data into OnsiteCourse table.
INSERT INTO OnsiteCourse (CourseID, Location, Days, Time)
VALUES (1050, '123 Smith', 'MTWH', '11:30');
INSERT INTO OnsiteCourse (CourseID, Location, Days, Time)
VALUES (1061, '234 Smith', 'TWHF', '13:15');
INSERT INTO OnsiteCourse (CourseID, Location, Days, Time)
VALUES (1045, '121 Smith','MWHF', '15:30');
INSERT INTO OnsiteCourse (CourseID, Location, Days, Time)
VALUES (4061, '22 Williams', 'TH', '11:15');
INSERT INTO OnsiteCourse (CourseID, Location, Days, Time)
VALUES (2042, '225 Adams', 'MTWH', '11:00');
INSERT INTO OnsiteCourse (CourseID, Location, Days, Time)
VALUES (4022, '23 Williams', 'MWF', '9:00');

-- Insert data into the CourseInstructor table.
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (1050, 1);
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (1061, 31);
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (1045, 5);
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (2030, 4);
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (2021, 27);
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (2042, 25);
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (4022, 18);
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (4041, 32);
INSERT INTO CourseInstructor(CourseID, PersonID)
VALUES (4061, 34);

--Insert data into the OfficeAssignment table.
INSERT INTO OfficeAssignment(InstructorID, Location, Timestamp)
VALUES (1, '17 Smith', current_timestamp);
INSERT INTO OfficeAssignment(InstructorID, Location, Timestamp)
VALUES (4, '29 Adams', current_timestamp);
INSERT INTO OfficeAssignment(InstructorID, Location, Timestamp)
VALUES (5, '37 Williams', current_timestamp);
INSERT INTO OfficeAssignment(InstructorID, Location, Timestamp)
VALUES (18, '143 Smith', current_timestamp);
INSERT INTO OfficeAssignment(InstructorID, Location, Timestamp)
VALUES (25, '57 Adams', current_timestamp);
INSERT INTO OfficeAssignment(InstructorID, Location, Timestamp)
VALUES (27, '271 Williams', current_timestamp);
INSERT INTO OfficeAssignment(InstructorID, Location, Timestamp)
VALUES (31, '131 Smith', current_timestamp);
INSERT INTO OfficeAssignment(InstructorID, Location, Timestamp)
VALUES (32, '203 Williams', current_timestamp);
INSERT INTO OfficeAssignment(InstructorID, Location, Timestamp)
VALUES (34, '213 Smith', current_timestamp);

-- Insert data into the StudentGrade table.
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (2021, 2, 4);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (2030, 2, 3.5);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (2021, 3, 3);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (2030, 3, 4);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (2021, 6, 2.5);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (2042, 6, 3.5);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (2021, 7, 3.5);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (2042, 7, 4);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (2021, 8, 3);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (2042, 8, 3);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4041, 9, 3.5);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4041, 10, null);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4041, 11, 2.5);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4041, 12, null);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4061, 12, null);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4022, 14, 3);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4022, 13, 4);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4061, 13, 4);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4041, 14, 3);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4022, 15, 2.5);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4022, 16, 2);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4022, 17, null);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4022, 19, 3.5);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4061, 20, 4);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4061, 21, 2);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4022, 22, 3);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4041, 22, 3.5);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4061, 22, 2.5);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (4022, 23, 3);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (1045, 23, 1.5);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (1061, 24, 4);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (1061, 25, 3);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (1050, 26, 3.5);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (1061, 26, 3);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (1061, 27, 3);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (1045, 28, 2.5);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (1050, 28, 3.5);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (1061, 29, 4);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (1050, 30, 3.5);
INSERT INTO StudentGrade (CourseID, StudentID, Grade)
VALUES (1061, 30, 4);

select
	 StudentID
	,Firstname
	,Lastname
	,Title
	,Grade
	,Credits
from Person p
	join StudentGrade g on p.PersonID = g.StudentID
	join Course c on g.CourseID = c.CourseID
--limit 15
;	