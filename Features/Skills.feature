Feature: As a customer I can add edit and delete skills 


Scenario: Add new skill

Given I navigate to skills
When I add a new skill English with level Fluent
Then I expect add success message


Scenario: Edit skill

Given I navigate to skills
When I edit skill to German with level Conversational
Then I expect update success message


Scenario: Delete skill

Given I navigate to skills
When I delete an existing skill German
Then I expect delete success message