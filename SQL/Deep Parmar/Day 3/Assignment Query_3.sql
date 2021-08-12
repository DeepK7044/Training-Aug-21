-- Assignment:

-- [3] Write a query to display the employees with their code, first name, last name and hire date 
--     who hired either on seventh day of any month or seventh month in any year.


SELECT EmployeeID,FirstName,LastName,HireDate FROM Employees WHERE HireDate LIKE '%07' OR HireDate LIKE '%07%';


