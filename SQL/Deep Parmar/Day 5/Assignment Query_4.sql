--Assignment:

--[4] Select EmployeeName, ManagerName from the employee table.

	  SELECT EMP.FIRST_NAME AS EmployeeName,MGR.FIRST_NAME AS ManagerName FROM Employee AS EMP LEFT OUTER JOIN Employee AS MGR
	  ON EMP.MANAGER_ID=MGR.EMPLOYEE_ID

	 --Another Way

	 SELECT EMP.FIRST_NAME AS EmployeeName,MGR.FIRST_NAME AS ManagerName FROM Employee AS EMP JOIN Employee AS MGR
	 ON EMP.MANAGER_ID=MGR.EMPLOYEE_ID
