# NotepadSpecFlow1

Demonstration of using SpecFlow and TestStack.White  to test Undo feature in windows Notepad

the following tests are implemented(https://github.com/mrag/NotepadSpecFlow1/blob/master/UnitTestProject1/NotepadUndo.feature):

Feature: Notepad Undo
	In order to cancel entered before text
	As advanced Notepad user
	I want to select Undo item from Edit menu

@launch_notepad
Scenario: Undo user input
	Given I have typed 'text to be removed' text
	When I select 'Undo' from 'Edit' menu
	Then entered 'text to be removed' is removed

	Given I have undone 'text to be removed' text
	When I select 'Undo' from 'Edit' menu
	Then entered 'text to be removed' is restored

Test execution have been recorded and availabled by the link: https://youtu.be/Sn9UTcdgQJY 
