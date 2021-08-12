-- Assignment:

-- [5] Write a query to extract the last 4 character of PhoneNumber.

--The RIGHT() function extracts a number of characters from a string (starting from right).
--Syntax :- RIGHT(string, number_of_chars)

-- Note- Here PhoneNumber datatype is varchar(20)


	SELECT RIGHT(PhoneNumber,4) AS PhoneNumber FROM Employees; 

	