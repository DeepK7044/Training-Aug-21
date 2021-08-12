-- Assignment:

-- [8] Write a query to get the distinct Mondays from HireDate in employees tables.

		SELECT DISTINCT HireDate FROM Employees WHERE DATENAME(WEEKDAY,HireDate)='MONDAY';


-- ANOTHER WAY:-
		
		--SELECT DISTINCT HireDate FROM Employees WHERE DATEPART(DW,HireDate)=2;