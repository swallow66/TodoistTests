Feature: Tasks

A short summary of the feature

@tag1
Scenario: Add Task
	Given I am logged in as default user
	When I click Quick Add button
	Then I can see Add New Task Dialog
	When I enter task details
		| title        | description          |
		| NewTaskTitle | New Task Description |
	And I click SubmitTask button
	Then the new task is created with correct name and description

Scenario: Complete Task
	Given I am logged in as default user
	When I create a task 
		| title				| description				 |
		| CompleteTaskTitle | Completed Task Description |
	And I click Complete checkbox
	Then newly created task is not displayed in Today screen