--Assignment

--[1] Write a query to rank employees based on their salary for a month

	--RANKING on their Lowest salary
	SELECT RANK() OVER (ORDER BY Salary) AS [Rank],* FROM Employees 

	--RANKING on their Highest salary
	SELECT RANK() OVER (ORDER BY Salary DESC) AS [Rank],* FROM Employees ORDER BY Salary DESC 


	--Another Ways:-		

		--SELECT DENSE_RANK() OVER (ORDER BY Salary DESC) AS [RANK] ,Salary FROM Employees  

		--SELECT ROW_NUMBER() OVER (ORDER BY Salary) "Rank",* FROM Employees 

		--SELECT [RANK]= NTILE(107) OVER (ORDER BY Salary DESC),* FROM Employees ORDER BY Salary DESC