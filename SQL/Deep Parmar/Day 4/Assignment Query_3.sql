--Assignment

--[3] Get department, total salary with respect to a department from employee table.

		SELECT DepartmentID,SUM(Salary) AS Total_Salary FROM Employees GROUP BY DepartmentID
		