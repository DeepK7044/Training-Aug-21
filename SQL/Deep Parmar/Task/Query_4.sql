--Q4: List Names of Borrowers Having Deposit Amount Greater than 1000 and Loan Amount Greater than 2000

SELECT BW.CNAME FROM BORROW AS BW WHERE BW.CNAME IN(SELECT DP.Cname FROM Deposit AS DP WHERE DP.Amount >1000)  AND  BW.AMOUNT>2000