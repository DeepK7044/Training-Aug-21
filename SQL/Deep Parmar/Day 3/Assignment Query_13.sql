-- Assignment:

-- [13] Write a query to get first name of employees who joined in 1987.

	SELECT FirstName FROM Employees WHERE YEAR(HireDate)=1987;

	
	--ANOTHER WAY :-

		--SELECT FirstName FROM Employees WHERE HireDate LIKE '1987%';