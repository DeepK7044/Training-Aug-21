-- Assignment:

-- [2] Write a query to display the FirstName and Salary for all employees. 
--     Format the salary to be 10 characters long, left-padded with the $ symbol. Label the column SALARY.


--The REPLICATE() function repeats a string a specified number of times.
--Syntax:- REPLICATE(string, integer)

--Solution:

    SELECT FirstName, REPLICATE('$',10-LEN(Salary))+CAST(Salary AS varchar(10)) AS SALARY FROM Employees;



