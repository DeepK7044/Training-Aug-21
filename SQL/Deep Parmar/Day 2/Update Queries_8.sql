--Assignment

--Update Queries:

-- [8] Write a SQL statement to increase the salary of employees under the department 40, 90 and 110 according to the company rules that, salary will be increased by 25% for the department 40,
--     15% for department 90 and 10% for the department 110 and the rest of the departments will remain same.

-- UPDATE QUEARY:

UPDATE Employees SET Salary= 

				CASE DepartmentID 
                          WHEN 40 THEN Salary+(Salary*0.25) 
                          WHEN 90 THEN Salary+(Salary*0.15)
                          WHEN 110 THEN Salary+(Salary*0.10)
                          ELSE Salary
                        END
             


--SELECT QUEARY:

SELECT * FROM Employees WHERE DepartmentID IN (40,90,110);