--Assignment

--Basic Select Queries:

--[11] Write a query to get the EmployeeID, names (FirstName, LastName), salary in ascending order of salary.

SELECT EmployeeID,(FirstName +' ' + LastName),Salary AS names FROM Employees ORDER BY Salary ASC