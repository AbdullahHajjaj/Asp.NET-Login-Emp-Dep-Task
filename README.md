# Asp.NET-Login-Emp-Dep-Task


  *To Configure the Connection with the Database 
  
    	we should change the server name in "appsettings.json" file.
    	The Server name I used: localhost;
    
  *In This Project I made Two Databases:
  
  	one for the Admin Accounts of the website (Register & Login)
  	and one for the Empolyees and Departments' Tables. 
  
  *I Created the migrations of the two Databases using these Console APIs:
  
  	EntityFrameworkCore\Add-Migration AddEmployeeToDb -Context ApplicationDbContext 
	EntityFrameworkCore\Add-Migration AddEmployeeToDb -Context EmpDepTaskContext
    
  *And I pushed them to database using:
  
    	EntityFrameworkCore\update-database -Context ApplicationDbContext
	EntityFrameworkCore\update-database -Context EmpDepTaskContext
    
    
  
  
