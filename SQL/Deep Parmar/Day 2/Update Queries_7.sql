--Assignment

--Update Queries:

-- [7] Write a SQL statement to change job ID of employee which ID is 118, to SH_CLERK if the employee belongs to department, which ID is 30 and the existing job ID does not start with SH.

-- UPDATE QUEARY:

UPDATE Employees SET JobId= 'SH_CLERK' WHERE EmployeeID=118 AND DepartmentID=30 AND NOT JobId LIKE 'SH%'


--SELECT QUEARY:

SELECT * FROM Employees WHERE EmployeeID=118 