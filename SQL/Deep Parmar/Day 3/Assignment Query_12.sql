-- Assignment:

-- [12] Write a query to get first name, hire date and experience of the employees.

     SELECT FirstName,HireDate,DATEDIFF(YY,HireDate,GETDATE()) AS Experience FROM Employees;

--ANOTHER WAY IF IN PAST JOBHISTORY TABLE IS CONSIDER THEN
		--SELECT FirstName,HireDate,DATEDIFF(YY,StartDate,EndDate) AS Experience FROM Employees AS EMP 
		--LEFT JOIN JobHistory AS JH ON EMP.EmployeeID=JH.EmployeeID
		

		