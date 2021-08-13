--Assignment

--[2] Select 4th Highest salary from employee table using ranking function

		SELECT * FROM (SELECT RANK() OVER (ORDER BY Salary DESC) AS [Rank],* FROM Employees)EMP WHERE [Rank]=4
