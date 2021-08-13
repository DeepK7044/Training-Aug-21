--Assignment

--[6] Get department wise minimum salary from employee table order by salary ascending

		SELECT DepartmentID,MIN(Salary) AS SALARY FROM Employees GROUP BY DepartmentID ORDER BY SALARY ASC
