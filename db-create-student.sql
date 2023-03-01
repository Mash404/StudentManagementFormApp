--MMR-PC-01\MSSQLSERVER2022
DROP DATABASE db_student;
CREATE DATABASE db_student;
USE db_student;

DROP TABLE studentsInfo;
DROP TABLE adminInfo;

CREATE TABLE studentsInfo(
	student_id INT IDENTITY(100,1) PRIMARY KEY,
    full_name VARCHAR(50) NOT NULL,
    date_of_birth DATE NOT NULL,
    gender VARCHAR(10) NOT NULL,
    email VARCHAR(50) NOT NULL,
    department VARCHAR(50) NOT NULL,
    study_year INT NOT NULL,
    semester INT NOT NULL,
    CGPA Float NOT NULL,
    credit_completed FLOAT NOT NULL
);


INSERT INTO studentsInfo(full_name, date_of_birth, gender, email, department, study_year, semester, CGPA, credit_completed)
VALUES
('John Doe', '2001-01-01', 'M', 'johndoe@example.com', 'CSE', 2, 1, 3.50, 30),
('David Smith', '2001-03-03', 'M', 'davidsmith@example.com', 'BBA', 2, 1, 3.20, 30),
('Emily Johnson', '2002-04-04', 'F', 'emilyjohnson@example.com', 'CE', 3, 2, 3.90, 60),
('Sarah Lee', '2000-05-05', 'F', 'sarahlee@example.com', 'TE', 4, 1, 3.60, 90),
('Michael Brown', '1999-06-06', 'M', 'michaelbrown@example.com', 'ME', 4, 2, 3.70, 120),
('Olivia Rodriguez', '2001-07-07', 'F', 'oliviarodriguez@example.com', 'ARC', 2, 1, 3.10, 30),
('Sophia Martinez', '2001-09-09', 'F', 'sophiamartinez@example.com', 'EEE', 4, 1, 3.80, 90),
('Ethan Johnson', '2002-10-10', 'M', 'ethanjohnson@example.com', 'IPE', 4, 2, 3.50, 120),
('Ava Hernandez', '2000-11-11', 'F', 'avahernandez@example.com', 'CSE', 3, 2, 3.90, 60),
('Noah Gonzalez', '1999-12-12', 'M', 'noahgonzalez@example.com', 'CE', 4, 1, 3.70, 90),
('Emma Perez', '2001-01-13', 'F', 'emmaperez@example.com', 'BBA', 3, 2, 3.60, 60),
('Liam Torres', '2002-02-14', 'M', 'liamtorres@example.com', 'EEE', 4, 1, 3.80, 90),
('Mia Flores', '2000-03-15', 'F', 'miaflores@example.com', 'IPE', 2, 2, 3.50, 30),
('Ethan Gomez', '1999-04-16', 'M', 'ethangomez@example.com', 'CE', 2, 1, 3.20, 30),
('Isabella Walker', '2001-05-17', 'F', 'isabellawalker@example.com', 'ARC', 3, 2, 3.10, 60),
('Mason Hall', '2000-06-18', 'M', 'masonhall@example.com', 'ME', 4, 1, 3.40, 90);


SELECT * FROM studentsInfo;




CREATE TABLE adminInfo (
    admin_id INT IDENTITY(100,1) PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL,
    full_name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    phone_number VARCHAR(20) NOT NULL
);

INSERT INTO adminInfo(username, password, full_name, email, phone_number)
VALUES
('Mash', '123', 'Mashfiq Rahman', 'mashfiqrr88@gmail.com','018XXXXXXXX');


SELECT * FROM adminInfo;
Insert into studentsInfo(full_name,date_of_birth,gender,email,department,study_year,semester,CGPA,credit_completed) values
('m','2019-12-11','male','mkj','cse',2,2,3.6,3.0);