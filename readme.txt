Assignment 

Week 8 - Object Oriented Desktop App - Part 2

Note: After class I added the Edit Employee feature.  I ended up not having the edit form appear just on a click of the listbox control.  Instead it would be useful to just set a class scope variable that is tracking what one was selected then we can use that for editing and deleting.  Take a look at the lstEmployees_SelectedIndexChanged function.  It was necessary to wrap that in a try block because in the loadEmployeeList function it sets the datasource to null and that will causse the SelectedIndexChanged function to fire and then trying to get the selected item will throw an error.  

Assignment - Add a Delete Employee, Update Project, and Delete Project feature to the Projgram:
 
 - Implement a Delete Employee method and call it on the button click, ask the user if they are sure first.

 - Create buttons for Edit Project and Delete Project on the EmployeeListForm
 
 - Create a new constructor on the ProjectForm class to be called for edit
 
 - Load the form with the existing project data
 
 - When you click save on the ProjectForm, update the project, update the projectlist control, and save to the file (you'll need to use the event and the subscription in the 
 EmployeeListForm to do it).
	
 - Implement a delete project feature, ask the user if they are sure first.