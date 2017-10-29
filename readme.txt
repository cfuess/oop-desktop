Assignment 

Week 7 - Object Oriented Desktop App

Note this repository has three different solutions in it.  

Concept - Solution
--------------------
Classes - Grades.sln
Inheritance - InheritanceDemo.sln
Desktop Application - EmployeeTracker.sln

Note: After class I added the FileManager class but didn't hook it up, we'll do it next week.  Also I added a results label to the EmployeeForm and an event to show when you click saved.  The last thing I did was add a View Employees button to the EmployeeListForm so you could see that it was adding to the collection of employees properly.  

Assignment - Add a Project Form to the Employee Tracker: 

 - Create a new Form for creating projects, call it ProjectForm
 
 - Add a new button to the EmployeeList screen to show it.
	
 - In the code-behind for the button click pass in the datastore.projects to the form constructor the way we did with employees, you will need to modify ProjectForm constructor so it will accept a List<project> object.  
	
 - Add textboxes to ProjectForm for all the properties on the Projects class except the Technologies property 
	
 - Make a save button to add the project to the collection.

