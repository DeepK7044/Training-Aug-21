--Assignment:

--[3] Select first_name, incentive amount from employee and incentives table for all employees even if they didn’t get incentives.

		SELECT EMP.FIRST_NAME,INS.INCENTIVE_AMOUNT FROM Employee AS EMP LEFT OUTER JOIN Incentives AS INS 
		ON EMP.EMPLOYEE_ID=INS.EMPLOYEE_REF_ID