# This is a project created for a final year university module.
- The task was to create a basic purchase order stock system.
- This is now a public repo as It is no longer any use to me :) 

# case-studies-basic-implementation
Case studies implementation based on the designs done in task 1.

The application runs on .net core 5.0. To run and test the application you will need to have it installed. 

You will need some form of MySQL databse running.

There is a script inside at /Services/Database/PreDeploymentScript.sql that needs to be ran to scaffold and insert data into a database.

Application Running Instructions:

If you have visual studio installed you will be able to launch it from opening the project. 

To run via command line, do the following:

-> dotnet build 

-> dotnet run --project Application 

Then access the site by going to: https://localhost:5001

Details to log into the internal system:

Email: cb@abc.com

Password: test


Details to log into external system:

Email: fry@pe.com

Password: test
