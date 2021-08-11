--Assignment

--Update Queries:

-- [4] Write a SQL statement to change the Email column of employees table with ‘not available’ for those employees whose DepartmentID is 80 and gets a commission is less than 20.

-- UPDATE QUEARY:

UPDATE Employees SET Email='not available' WHERE DepartmentID=110 AND CommissionPct < 0.20


--SELECT QUEARY:

SELECT * FROM Employees WHERE DepartmentID=110 AND CommissionPct < 0.20