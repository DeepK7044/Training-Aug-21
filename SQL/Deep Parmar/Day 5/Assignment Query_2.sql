--Assignment:

--[2] Select first_name, incentive amount from employee and incentives table for those employees who have incentives and incentive amount greater than 3000

	SELECT EMP.FIRST_NAME,INS.INCENTIVE_AMOUNT FROM Employee AS EMP INNER JOIN Incentives AS INS 
    ON EMP.EMPLOYEE_ID=INS.EMPLOYEE_REF_ID WHERE INCENTIVE_AMOUNT > 3000

