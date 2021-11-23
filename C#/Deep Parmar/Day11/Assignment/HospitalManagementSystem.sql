--CREATE DATABASE HospitalManagementSystem

USE HospitalManagementSystem

CREATE TABLE Patients
(
PatientID INT PRIMARY KEY IDENTITY(1,1),
PatientName VARCHAR(30) NOT NULL,
Age TINYINT NOT NULL,
Gender TINYINT NOT NULL CONSTRAINT ChkGender CHECK (Gender BETWEEN 1 AND 3),
PhoneNumber VARCHAR(10) NOT NULL CONSTRAINT ChkPatientPhoneNumber CHECK(PhoneNumber LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
Address VARCHAR(30) NOT NULL,
BloodGroup VARCHAR(3)
)

INSERT INTO Patients VALUES('Dinesh Thakkar',35,1,'9995631256','Ahmedabad','A+'),
							('Shikhar Parihar',25,1,'9995631245','Bhavnagar','B+'),
                            ('Smit Kapadiya',35,1,'8155839261','Surat','B-'),
                            ('Darshan Shah',40,1,'8563214578','Amreli','A-'),
                            ('Meena Patel',55,2,'7496853215','Ahmedabad','A+'),
                            ('Urvish Gajjar',64,1,'8985868487','Ahmedabad','A+')

-------------------------------------------------------------------------------------------------------------------------------


CREATE TABLE Doctors
(
DoctorID INT PRIMARY KEY IDENTITY(1,1),
DoctorName VARCHAR(30) NOT NULL,
Age TINYINT NOT NULL,
Gender TINYINT NOT NULL CONSTRAINT ChkDrGender CHECK (Gender BETWEEN 1 AND 3),
PhoneNumber VARCHAR(10) NOT NULL CONSTRAINT ChkDrPhoneNumber CHECK(PhoneNumber LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
Address VARCHAR(30) NOT NULL
)

INSERT INTO Doctors VALUES('Dharna Panchal',22,2,'9985868487','Ahmedabad'),
						  ('Kamlesh Parmar',22,2,'8985868487','Ahmedabad'),
						  ('Dhvani Panchal',22,2,'8586848799','Ahmedabad')

-------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE Departments
(
DeptID INT PRIMARY KEY IDENTITY(1,1),
DeptName VARCHAR(30)
)

INSERT INTO Departments VALUES ('COVID-19'),
							   ('Eye Care'),
							   ('Dental Clinic'),
							   ('Ayurvedic')
-------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE HealthcareAssistants
(
AssistantID INT PRIMARY KEY IDENTITY(1,1),
AssistantName VARCHAR(30) NOT NULL,
Age TINYINT NOT NULL,
Gender TINYINT NOT NULL CONSTRAINT ChkAsstGender CHECK (Gender BETWEEN 1 AND 3),
PhoneNumber VARCHAR(10) NOT NULL CONSTRAINT ChkAsstPhoneNumber CHECK(PhoneNumber LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
Salary DECIMAL(8,2),
DeptNo INT,
CONSTRAINT FK_Dept FOREIGN KEY (DeptNo) REFERENCES Departments(DeptID)
)

INSERT INTO HealthcareAssistants VALUES ('Arjun Reddy',30,2,'8985868487',19000,1),
										('Abhijeet Panchal',24,2,'8586848799',16000,2),
										('Remma Patel',25,2,'8985868487',18000,3),
										('Amitava Khatri',22,2,'8586848799',15000,1)


-------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE Drugs
(
DrugsID INT PRIMARY KEY IDENTITY(1,1),
DrugName VARCHAR(25) NOT NULL,
Price DECIMAL(8,2) NOT NULL,
ExpiryDate DATE NOT NULL,
DrugDescription VARCHAR(100) NOT NULL,
Quantity INT NOT NULL
)

INSERT INTO Drugs VALUES ('Azithromycin',100,'2022-08-26','It is also effective in typhoid fever and some sexually transmitted diseases like gonorrhea',5),
						 ('Dolo 650',80,'2022-08-26',' It works by inhibiting the release of certain chemicals that cause pain and fever',10),
						 ('Lopamide',50,'2022-08-26','It should not be used in patients with dysentery (diarrhea with blood)',7)

-------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE Treatment
(
TrtID INT PRIMARY KEY IDENTITY(1,1),
TrtDate DATE DEFAULT GETDATE() NOT NULL,
DeptID INT NOT NULL,
PatientID INT NOT NULL,
DoctorID INT NOT NULL,
CONSTRAINT FK_DeptID FOREIGN KEY (DeptID) REFERENCES Departments(DeptID),
CONSTRAINT FK_PatientID FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
CONSTRAINT FK_DoctorID FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID)
)

INSERT INTO Treatment (DeptID,PatientID,DoctorID) VALUES (1,1,1),
							 (1,2,1),
							 (2,1,2),
							 (2,2,2),
							 (1,3,1),
							 (1,4,2),
							 (1,5,3),
							 (3,6,2)

-------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Prescription
(
PreID INT PRIMARY KEY IDENTITY(1,1),
PreDate DATE NOT NULL,
PatientID INT NOT NULL,
DoctorID INT NOT NULL,
DrugsID INT NOT NULL,
DayPart TINYINT NOT NULL,
CONSTRAINT FK_DrugId FOREIGN KEY (DrugsID) REFERENCES Drugs(DrugsID),
CONSTRAINT FK_PatID FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
CONSTRAINT FK_DrID FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID)
)

INSERT INTO Prescription VALUES ('2021-10-11',1,2,1,2),
								('2021-10-11',1,2,2,2),
								('2021-10-11',1,1,1,2),
								('2021-10-11',1,3,3,1),
								('2021-10-11',2,2,1,3),
								('2021-10-11',3,1,2,2),
								('2021-10-11',4,2,3,3),
								('2021-10-11',5,3,3,2),
								('2021-10-11',6,2,1,1)
----------------------------------------------------------------------------------------------------------- 

CREATE TABLE ObjectMaster
(
[Type_Id] INT PRIMARY KEY IDENTITY(1,1),
[Type_Name] VARCHAR(20) NOT NULL
)

INSERT INTO ObjectMaster VALUES ('Gender'),
                                 ('DayPart')

----------------------------------------------------------------------------------------------------------- 

CREATE TABLE [Object]
(
Obj_Id INT PRIMARY KEY IDENTITY(1,1),
[Type_Id] INT NOT NULL,
Obj_Name VARCHAR(30) NOT NULL,
CONSTRAINT FK_Type_Id FOREIGN KEY([Type_Id]) REFERENCES ObjectMaster([Type_Id])
)


INSERT INTO [Object] VALUES (1,'Male'),
                            (1,'Female'),
                            (1,'Others'),
							(2,'Morning'),
							(2,'Afternoon'),
							(2,'Night')


CREATE VIEW Patients_Doctor
AS
SELECT P.PatientName AS [Patient Name],DR.DoctorName AS [Doctor Name] FROM Treatment AS T
INNER JOIN Patients AS P ON P.PatientID=T.PatientID
INNER JOIN Doctors AS DR ON DR.DoctorID=T.DoctorID

CREATE VIEW Medicine_list
AS
SELECT P.PatientName,STRING_AGG(DRG.DrugName,',') AS Medicine_list FROM Prescription AS PRE
INNER JOIN Patients AS P ON P.PatientID=PRE.PatientID
INNER JOIN Drugs AS DRG ON DRG.DrugsID=PRE.DrugsID
GROUP BY P.PatientID,P.PatientName

--DROP DATABASE HospitalManagementSystem

SELECT * FROM Patients_Doctor
SELECT * FROM Medicine_list