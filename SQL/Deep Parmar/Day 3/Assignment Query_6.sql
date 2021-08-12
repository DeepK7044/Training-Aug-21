-- Assignment:

-- [6] Write a query to update the portion of the PhoneNumber in the employees table, within the phone number the substring ‘124’ will be replaced by ‘999’.

	
	UPDATE Employees SET PhoneNumber=REPLACE(PhoneNumber,'124','999') WHERE PhoneNumber LIKE '%124%'; 

	--SELECT QUERY

	SELECT PhoneNumber FROM Employees WHERE PhoneNumber LIKE '%999%';