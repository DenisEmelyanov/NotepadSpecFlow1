Feature: Notepad
	In order to cancel entered text
	As advanced Notepad user
	I want to select Undo item from Edit menu

@simpleSpecFlowScenarioForDemo
Scenario: Undo input
	Given I have launched Notepad
	And I have typed 'it works ;)'
	When I select 'Undo' from 'Edit' menu
	Then entered 'it works ;)' is removed
