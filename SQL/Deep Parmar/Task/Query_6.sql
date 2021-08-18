--Q6: Count the Number of Customers Living in the City where Branch is Located

SELECT COUNT(CUS.CNAME) AS Total_Customers FROM CUSTOMER AS CUS WHERE CUS.CITY IN (SELECT BR.CITY FROM BRANCH AS BR WHERE CUS.CITY=BR.CITY)