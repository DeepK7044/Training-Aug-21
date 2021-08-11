--Alter statement

-- (1) Write a SQL statement to add a foreign key constraint named fk_job_id on JobId column of JobHistory table referencing to the primary key JobId of jobs table.


  --ALTER Queary

  ALTER TABLE JobHistory
  ADD CONSTRAINT fk_job_id FOREIGN KEY (Job_Id) REFERENCES jobs(JobId)