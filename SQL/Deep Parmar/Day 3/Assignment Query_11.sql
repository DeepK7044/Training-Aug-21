-- Assignment:

-- [11] Write a query to get the FirstName, LastName who joined in the month of June.

	SELECT FirstName,LastName FROM Employees WHERE MONTH(HireDate)=6;

