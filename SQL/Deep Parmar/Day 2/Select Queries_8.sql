--Assignment

--Basic Select Queries:

--[8] Write a query to get the names (FirstName, LastName), Salary, PF of all the Employees (PF is calculated as 12% of salary).

SELECT FirstName, LastName, Salary, (Salary * 0.12) AS PF FROM employees;