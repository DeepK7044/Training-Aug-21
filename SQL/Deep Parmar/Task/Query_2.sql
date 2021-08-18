--Q2: List All the Depositors Having Depositors Having Deposit in All the Branches where SUNIL is Having Account

	SELECT Cname FROM Deposit WHERE Bname IN (SELECT Bname FROM Deposit WHERE Cname='SUNIL')