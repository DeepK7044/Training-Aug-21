--Assignment

--Update Queries:

-- [5] Write a SQL statement to change the Email column of employees table with ‘not available’ for those employees who belongs to the ‘Accouning’ department.

-- UPDATE QUEARY:

UPDATE Employees SET Email='not available' WHERE
DepartmentID=(SELECT DepartmentID FROM Departments WHERE DepartmentName='Accounting');


--SELECT QUEARY:

SELECT * FROM Employees WHERE DepartmentID=(SELECT DepartmentID FROM Departments WHERE DepartmentName='Accounting');