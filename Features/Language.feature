Feature: As a customer I can add edit and delete language 


Background: Login and navigate to languages tab
	Given I navigate to Language 

@cleanupLanguageAfterTest
Scenario Outline: TC1 - Positive - Add new Language

	When I add a new langauge '<language>' with level '<level>'
	Then I expect language add success message as '<successMessage>'

	Examples: 
	| language | level  | successMessage                           |
	| English  | Fluent | English has been added to your languages |
	| French  | Basic | French has been added to your languages |
	| German  | Conversational | German has been added to your languages |
	| Hindi  | Native/Bilingual | Hindi has been added to your languages |

@addLanguageAsPreSetup @cleanupLanguageAfterTest
Scenario: TC2 - Positive - Edit Language
	
	When I edit 'English' language to 'German' with level 'Conversational'
	Then I expect language update success message as 'German has been updated to your languages'

@addLanguageAsPreSetup
Scenario: TC3 - Positive - Delete Language

	When I delete an existing language 'English'
	Then I expect language delete success message as 'English has been deleted from your languages'

@cleanupLanguageAfterTest
Scenario: TC4 - Negative Valid - Add same language twice and verify error message 

	When I add a new langauge 'English' with level 'Conversational'
	Then I expect language add success message as 'English has been added to your languages'
	When I add a new langauge 'English' with level 'Conversational'
	Then I expect language error message as 'This language is already exist in your language list.'


Scenario: TC5 - Negative Invalid - Add same language twice and verify error message 

	When I click language Add New button
	And I click language Add button
	Then I expect language error message as 'Please enter language and level'

