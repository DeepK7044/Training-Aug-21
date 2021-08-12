-- Assignment:

-- [4] Write a query to display the length of first name for employees where last name contains character ‘c’ after 2nd position.


  SELECT LEN(FirstName) AS Length_Of_FirstName FROM Employees WHERE LastName LIKE '__C%';

