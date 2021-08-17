--Assignment:

--[5] Select first_name, incentive amount from employee and incentives table for all employees even if they didn’t get incentives 
--    and set incentive amount as 0 for those employees who didn’t get incentives.

	  SELECT EMP.FIRST_NAME,ISNULL(INS.INCENTIVE_AMOUNT,0) FROM Employee AS EMP LEFT OUTER JOIN Incentives AS INS 
	  ON EMP.EMPLOYEE_ID=INS.EMPLOYEE_REF_ID