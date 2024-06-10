Feature: As a customer I can add edit and delete skills 


Background: Login and navigate to languages tab
	Given I navigate to skills 

@cleanupSkillAfterTest
Scenario Outline: TC1 Add new skill

	When I add a new skill '<skill>' with level '<level>'
	Then I expect skill add success message as '<successMessage>'

	Examples: 
	| skill | level  | successMessage                           |
		| Java  | Beginner | Java has been added to your skills |
		| Testing  | Intermediate | Testing has been added to your skills |
		| Automation  | Expert | Automation has been added to your skills |

@addSkillAsPreSetup @cleanupSkillAfterTest
Scenario: TC2 Edit skill

	When I edit 'Java' skill to 'Python' with level 'Intermediate'
	Then I expect skill update success message as 'Python has been updated to your skills'

@addSkillAsPreSetup
Scenario: TC3 Delete skill

	When I delete an existing skill 'Java'
	Then I expect skill delete success message as 'Java has been deleted'

@cleanupSkillAfterTest
Scenario: TC4 - Negative Valid - Add same skill twice and verify error message 

	When I add a new skill 'Java' with level 'Beginner'
	Then I expect skill add success message as 'Java has been added to your skills'
	When I add a new skill 'Java' with level 'Beginner'
	Then I expect skill error message as 'This skill is already exist in your skill list.'


Scenario: TC5 - Negative Invalid - Add same skill twice and verify error message 

	When I click skill Add New button
	And I click skill Add button
	Then I expect skill error message as 'Please enter skill and experience level'