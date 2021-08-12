-- Assignment:

-- [7] Write a query to calculate the age in year.
-- Note:- i Born in year 2000 that's why i write here directly, If any database Present insted of '2000' i write that perticular column Name



    SELECT DATEDIFF(YY,'2000',CAST(YEAR(GETDATE()) AS VARCHAR(4))) AS Age;





