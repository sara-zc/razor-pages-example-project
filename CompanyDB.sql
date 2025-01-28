-------------Database creation-------------
--create database CompanyDB
USE master;
GO
DROP database IF EXISTS COMPANYDB;
GO
Create database COMPANYDB
GO
use COMPANYDB

------------Table Creation-----------------
CREATE TABLE EMPLOYEE
(
Fname		VARCHAR(15) NOT NULL,
Minit		CHAR,
Lname		VARCHAR(15) NOT NULL,
SSN			INT,
Bdate		DATE,
Address		VARCHAR(30),
Sex			CHAR(1),
Salary		INT,
Super_SSN	INT,
Dno			INT,
PRIMARY KEY (SSN),
FOREIGN KEY (Super_SSN) REFERENCES Employee,
)

create table DEPARTMENT
(
Dname varchar(50),
Dnumber int,
primary key (Dnumber),
Mgr_SSN int,
Mgr_Start_Date date,
Foreign key (Mgr_SSN) references Employee,
)

create table DEPT_LOCATIONS
(
Dnumber int,
Dlocation varchar(50),
Primary key (Dnumber,Dlocation),
foreign key (Dnumber) references Department,
)

create table PROJECT
(
Pname varchar(50),
Pnumber int,
primary key(Pnumber),
Plocation varchar(50),
Dnum int,
foreign key (Dnum) references Department
)

create table WORKS_ON
(
Essn int,
Pno int,
primary key (Essn,Pno),
Hours float,
foreign key (Essn) references Employee,
foreign key (Pno) references Project
)

create table DEPENDENT
(
Essn int NOT NULL,
Dependent_name VARCHAR(15) NOT NULL,
Sex CHAR,
Bdate DATE,
Relationship VARCHAR(8),
primary key (Essn, Dependent_name),
foreign key (Essn) references Employee,
)

-----------Inserting Employee Foreign key--------------
ALTER TABLE EMPLOYEE ADD FOREIGN KEY (DNO) REFERENCES DEPARTMENT

---------------Inserting values into tables----------------
INSERT INTO EMPLOYEE 
VALUES
('John',	 'B',	'Smith',	123456789, '1965-01-09','731 Fondren, Houston, TX',	'M', 30000, null, null),
('Franklin', 'T',	'Wong',		333445555, '1955-12-08','638 Voss, Houston, TX',	'M', 40000, null, null),
('Alicia',	 'J',	'Zelaya',	999887777, '1968-01-19','3321 Castle, Spring, TX',	'F', 25000, null, null),
('Jennifer', 'S',	'Wallace',	987654321, '1941-06-20','291 Berry, Bellaire, TX',	'F', 43000, null, null),
('Ramesh',	 'K',	'Narayan',	666884444, '1962-09-15','975 Fire Oak, Humble, TX',	'M', 38000, null, null),
('Joyce',	 'A',	'English',	453453453, '1972-07-31','5631 Rice, Houston, TX',	'F', 25000, null, null),
('Ahmad',	 'V',	'Jabbar',	987987987, '1969-03-29','980 Dallas, Houston, TX',	'M', 25000, null, null),
('James',	 'E',	'Borg',		888665555, '1937-11-10','450 Stone, Houston, TX',	'M', 55000, null, null)

INSERT INTO DEPARTMENT
values
('Headquarters',1,888665555,'1981-06-19'),
('Administration',4,987654321,'1995-01-01'),
('Research',5,333445555,'1988-05-22')

INSERT INTO DEPT_LOCATIONS
values
(1	,'Houston'),
(4	,'Stafford'),
(5	,'Bellaire'),
(5	,'Houston'),
(5	,'Sugarland')

INSERT INTO PROJECT
values
('ProductX',1,'Bellaire',5),
('ProductY',2,'Sugarland',5),
('ProductZ',3,'Houston',5),
('Computerization',10,'Stafford',4),
('Reorganization',20,'Houston',1),
('Newbenefits',30,'Stafford',4)

INSERT INTO WORKS_ON
values
(123456789	,1	,32.5),
(123456789	,2	,7.5),
(666884444	,3	,40),
(453453453	,1	,20),
(453453453	,2	,20),
(333445555	,2	,10),
(333445555	,3	,10),
(333445555	,10	,10),
(333445555	,20	,10),
(999887777	,10	,10),
(999887777	,30	,30),
(987987987	,10	,35),
(987987987	,30	,5),
(987654321	,30	,20),
(987654321	,20	,15),
(888665555	,20	,null)

INSERT INTO DEPENDENT 
values
(333445555,	'Alice',		'F',	'1986-04-05',	'Daughter'),
(333445555,	'Theodore',		'M', 	'1983-10-25',	'Son'),
(333445555,	'Joy',			'F', 	'1958-05-03',	'Spouse'),
(987654321,	'Abner',		'M', 	'1942-02-28',	'Spouse'),
(123456789,	'Michael',		'M', 	'1988-01-04',	'Son'),
(123456789,	'Alice',		'F', 	'1988-12-30',	'Daughter'),
(123456789,	'Elizabeth',	'F',	'1967-05-05',	'Spouse')


UPDATE EMPLOYEE SET Super_SSN = 333445555, Dno = 5	WHERE SSN = 123456789
UPDATE EMPLOYEE SET Super_SSN = 888665555, Dno = 5	WHERE SSN = 333445555
UPDATE EMPLOYEE SET Super_SSN = 987654321, Dno = 4	WHERE SSN = 999887777
UPDATE EMPLOYEE SET Super_SSN = 888665555, Dno = 4	WHERE SSN = 987654321
UPDATE EMPLOYEE SET Super_SSN = 333445555, Dno = 5	WHERE SSN = 666884444
UPDATE EMPLOYEE SET Super_SSN = 333445555, Dno = 5	WHERE SSN = 453453453
UPDATE EMPLOYEE SET Super_SSN = 987654321, Dno = 4	WHERE SSN = 987987987
UPDATE EMPLOYEE SET Super_SSN = NULL,	   Dno = 1	WHERE SSN = 888665555
