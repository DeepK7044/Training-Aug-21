--Assignment

--[5] Get department wise maximum salary from employee table order by salary ascending

		SELECT DepartmentID,MAX(Salary) AS SALARY FROM Employees GROUP BY DepartmentID ORDER BY SALARY ASC
