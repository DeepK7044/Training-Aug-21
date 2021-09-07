------------Store Procedure----------------------
-------------WITHOUT parameter--------------------
CREATE PROCEDURE spEmployeeDepartmentGet
AS
BEGIN
SELECT * FROM Employees AS EMP
JOIN departments AS DEPT ON DEPT.DEPARTMENT_ID=EMP.DepartmentID
END

-----------Executing Store Procedure------------------------
spEmployeeDepartmentGet
EXEC spEmployeeDepartmentGet
EXECUTE spEmployeeDepartmentGet

---------------ALTER Store Procedure-------------------------
ALTER PROCEDURE spEmployeeDepartmentGet
AS
BEGIN
SELECT Employee_Name=(FirstName+SPACE(1)+LastName),DEPT.DEPARTMENT_NAME,Salary FROM Employees AS EMP
JOIN departments AS DEPT ON DEPT.DEPARTMENT_ID=EMP.DepartmentID
END

---------------DROP Store Procedure------------------------------
DROP PROCEDURE spEmployeeDepartmentGet

-------------Creating Store Procedure with input parameter------------------------

CREATE PROCEDURE spEmployeeGetName
@Job_Id varchar(10),
@Salary DECIMAL(8,2)
AS 
BEGIN

	SELECT Employee_Name=(FirstName+SPACE(1)+LastName) FROM Employees 
	WHERE JobId=@Job_Id AND Salary > @Salary
END

EXECUTE spEmployeeGetName 'SH_CLERK',3000

-------------------------------------------------------------

CREATE PROCEDURE HumanResources.uspGetEmployeesTest2   
    @LastName nvarchar(50),   
    @FirstName nvarchar(50)   
AS   
BEGIN
    SET NOCOUNT ON  
    SELECT FirstName, LastName, Department  
    FROM HumanResources.vEmployeeDepartmentHistory  
    WHERE FirstName = @FirstName AND LastName = @LastName  
END

EXEC HumanResources.uspGetEmployeesTest2 @FirstName='Terri',@LastName='Duffy'

SELECT * FROM HumanResources.vEmployeeDepartmentHistory


----------------Creating Store Procedure with output parameter----------------------
CREATE PROCEDURE spEmployeeGetCount
@Department_Name VARCHAR(15),
@Count INT OUTPUT
AS 
BEGIN
	
	SELECT @Count=COUNT(EMP.EmployeeID) FROM Employees AS EMP
	JOIN departments AS DEPT ON EMP.DepartmentID=DEPT.DEPARTMENT_ID
	WHERE DEPT.DEPARTMENT_NAME=@Department_Name 
END

DECLARE @Count_No INT
EXECUTE spEmployeeGetCount 'IT',@Count_No OUTPUT
PRINT 'Total Employee In IT Department is: '+CAST(@Count_No AS VARCHAR(5))

SELECT * FROM Employees WHERE DepartmentID=60
-------------------------------------------------------------
CREATE PROCEDURE spGetEmployeeDetail 
@Emp_Id INT OUTPUT,
@Emp_Name VARCHAR(20) OUTPUT,
@Dept_Id INT
AS
BEGIN
	SELECT @Emp_Id=EmployeeID,@Emp_Name=(FirstName+SPACE(1)+LastName) FROM Employees
	WHERE DepartmentID=@Dept_Id
END

DECLARE @EmpId INT,@EmpName VARCHAR(20)
EXEC spGetEmployeeDetail @EmpId OUTPUT,@EmpName OUTPUT,50
PRINT ('Employee ID '+CAST(@EmpId AS VARCHAR(5))+SPACE(1)+'Employee_Name '  + @EmpName)

---------------------------------------------------------------
CREATE PROCEDURE prcGetEmployeeDetail 
@Business_ID INT, 
@DepName CHAR(30) OUTPUT,
@ShiftID INT OUTPUT
AS
BEGIN
    IF EXISTS(SELECT * FROM HumanResources.Employee WHERE BusinessEntityID = @Business_ID)
BEGIN
    SELECT @DepName = d.Name , @ShiftID = h.ShiftID
    FROM HumanResources.Department AS d
    INNER JOIN HumanResources.EmployeeDepartmentHistory AS h
    ON d.DepartmentID = h.DepartmentID
    WHERE BusinessEntityID = @Business_ID AND EndDate IS NULL
END
END
GO
--------------Result of Output Parameter-----------------------
DECLARE @Dep_Name CHAR(30), @ShiftId INT
EXEC prcGetEmployeeDetail  32, @Dep_Name OUTPUT, @ShiftID OUTPUT
SELECT @Dep_Name AS 'DepartmentName', @ShiftID AS 'ShiftID'

------------Built in Store Procedure----------------------
EXEC sp_help spEmployeeGetCount
EXEC sp_helptext spEmployeeGetCount   


-----------Returning multiple resultset-------------------
CREATE PROCEDURE spMultipleResultset
AS
BEGIN
SELECT * FROM Employees
SELECT * FROM departments
END

EXEC spMultipleResultset

--------------------------RETURN------------------------------------

CREATE PROCEDURE spEmployeeCountReturn
@Department_Name VARCHAR(15)
AS 
BEGIN
	
	RETURN (SELECT COUNT(EMP.EmployeeID) FROM Employees AS EMP
	JOIN departments AS DEPT ON EMP.DepartmentID=DEPT.DEPARTMENT_ID
	WHERE DEPT.DEPARTMENT_NAME=@Department_Name)
END

DECLARE @COUNT INT
EXECUTE @COUNT=spEmployeeCountReturn 'IT'
PRINT 'Total Employee In IT Department is: '+CAST(@COUNT AS VARCHAR(5))

---------Return JSON output from Store Procedure--------------
CREATE PROCEDURE spEmployeeDepartmentjson
@Json NVARCHAR(MAX) OUTPUT
AS
BEGIN
SET @Json=(SELECT TOP (10) Employee_Name=(FirstName+SPACE(1)+LastName),DEPT.DEPARTMENT_NAME,Salary FROM Employees AS EMP
		JOIN departments AS DEPT ON DEPT.DEPARTMENT_ID=EMP.DepartmentID 
		FOR JSON PATH,WITHOUT_ARRAY_WRAPPER)
END

DECLARE @json NVARCHAR(MAX)
EXEC spEmployeeDepartmentjson @json OUTPUT
PRINT(@json)

------------------JSON INPUT Parameter-------------------------------

CREATE PROCEDURE spEmployeeDetails
@Emp_Details NVARCHAR(MAX)
AS 
BEGIN
INSERT INTO Employee_Detail
SELECT * FROM OPENJSON(@Emp_Details)
WITH
(
	FirstName VARCHAR(15) '$.FirstName',
	LastName VARCHAR(15) '$.LastName',
	Salary DECIMAL(8,2) '$.Salary',
	JobId VARCHAR(10) '$.JobId'
)
END

DECLARE @EmpDetails NVARCHAR(MAX)=(SELECT TOP(3) FirstName,LastName,Salary,JobId FROM Employees FOR JSON PATH)
EXECUTE spEmployeeDetails @EmpDetails

SELECT * FROM Employee_Detail
-----------Use the SET NOCOUNT ON--------------------------
CREATE PROCEDURE spEmployeeDetailsUsingCity
@CITY VARCHAR(10)
AS 
BEGIN
	SET NOCOUNT ON
	SELECT Employee_Name=(FirstName+SPACE(1)+LastName),DEPT.DEPARTMENT_NAME,EMP.Salary,LOC.City FROM Employees AS EMP
	JOIN departments AS DEPT ON DEPT.DEPARTMENT_ID=EMP.DepartmentID
	JOIN Locations AS LOC ON DEPT.LOCATION_ID=LOC.LocationID
	WHERE LOC.City=@CITY
END

EXECUTE spEmployeeDetailsUsingCity 'Seattle'


-----------------WITH ENCRYPTION----------------------------------------
CREATE PROCEDURE spEmployeeDetailsUsingCityDept
@CITY VARCHAR(10),
@DEPARTMENT_Name VARCHAR(10) 
WITH ENCRYPTION
AS 
BEGIN
	SET NOCOUNT ON
	SELECT Employee_Name=(FirstName+SPACE(1)+LastName),DEPT.DEPARTMENT_NAME,EMP.Salary,LOC.City FROM Employees AS EMP
	JOIN departments AS DEPT ON DEPT.DEPARTMENT_ID=EMP.DepartmentID
	JOIN Locations AS LOC ON DEPT.LOCATION_ID=LOC.LocationID
	WHERE LOC.City=@CITY
END

EXECUTE spEmployeeDetailsUsingCityDept 'Seattle','Finance'

sp_helptext spEmployeeDetailsUsingCityDept


