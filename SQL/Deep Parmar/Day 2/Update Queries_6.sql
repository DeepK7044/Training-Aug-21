--Assignment

--Update Queries:

-- [6] Write a SQL statement to change salary of employee to 8000 whose ID is 105, if the existing salary is less than 5000.

-- UPDATE QUEARY:

UPDATE Employees SET Salary = 8000 WHERE EmployeeID = 105 AND Salary < 5000


--SELECT QUEARY:

SELECT * FROM Employees WHERE EmployeeID = 105 AND Salary < 5000

--NO DATA AVAILABLE