Feature: As a customer I can add edit and delete language 


Scenario: Add new Language

Given I navigate to Language
When I add a new langauge English with level Fluent
Then I expect add success message



Scenario: Edit Language

Given I navigate to Language 
When I edit language to German with level Conversational
Then I expect update success message


Scenario: Delete Language

Given I navigate to Language
When I delete an existing language German
Then I expect delete success message