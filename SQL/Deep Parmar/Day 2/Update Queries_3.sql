--Assignment

--Update Queries:

-- [3] Write a SQL statement to change the Email and CommissionPct column of employees table with ‘not available’ and 0.10 for those employees whose DepartmentID is 110.

-- UPDATE QUEARY:

UPDATE Employees SET Email='not available',CommissionPct=0.10 WHERE DepartmentID=110


--SELECT QUEARY:

SELECT * FROM Employees WHERE DepartmentID=110
