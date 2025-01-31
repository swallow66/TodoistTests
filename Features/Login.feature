Feature: Feature1

A short summary of the feature

@Login
Scenario: Happy login with email flow
	Given I am on the login screen
	Then I should be able to continue with Google or Email option
	When I choose 'Continue with email' option
	Then I should be able to sign up or login with email
	When I choose 'Login with email' option 
	And I enter my username and password
		| email                    | password |
		| elena.petrusha@gmail.com | Qw12!!!! |
	And I click the login button
	Then I should see the Today screen

@Login
Scenario: Login with wrong credentials - email
	Given I am on the login screen
	When I choose 'Continue with email' option
	And I choose 'Login with email' option 
	And I enter my username and password
		| email                  | password |
		| non-existing@gmail.com | Qw12!!!! |
	And I click the login button
	Then I should see the login error message
	And I should see the Login screen

@Login	
Scenario: Login with wrong credentials - password
	Given I am on the login screen
	When I choose 'Continue with email' option
	And I choose 'Login with email' option 
	And I enter my username and password
		| email						| password		 |
		| elena.petrusha@gmail.com	| WrongPassword! |
	And I click the login button
	Then I should see the login error message
	And I should see the Login screen

@Logout
Scenario: User logged out from the application
	Given I am logged in using the following credentials
		| email                    | password |
		| elena.petrusha@gmail.com | Qw12!!!! |
	When I perform logout action
	Then I should see the Home screen

	

