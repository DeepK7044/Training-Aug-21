-- Q1: List Names of Customers who are Depositors and have Same Branch City as that of SUNIL

SELECT Cname FROM Deposit AS DP
WHERE Bname IN (SELECT BR.BNAME FROM BRANCH AS BR WHERE BR.CITY = 
(SELECT CITY FROM BRANCH WHERE BNAME=(SELECT Bname FROM Deposit WHERE Cname='SUNIL')))