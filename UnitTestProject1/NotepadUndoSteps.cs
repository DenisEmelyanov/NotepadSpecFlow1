using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace UnitTestProject1
{
    [Binding]
    public class NotepadUndoSteps
    {
        private NotepadApp notepadApp;

        [Given(@"I have launched Notepad")]
        public void GivenIHaveLaunchedNotepad()
        {
            notepadApp = new NotepadApp();
            notepadApp.Launch();
        }

        [Given(@"I have typed '(.*)'")]
        public void GivenIHaveTyped(string typedText)
        {
            notepadApp.TypeText(typedText);
        }

        [When(@"I select '(.*)' from '(.*)' menu")]
        public void WhenISelectFromMenu(string menuItem, string menu)
        {
            notepadApp.ClickMenuItem(menu, menuItem);
        }

        [Then(@"entered '(.*)' is removed")]
        public void ThenEnteredIsRemoved(string typedText)
        {
            string text = notepadApp.GetText();
            bool isFound = text.Contains(typedText);
            Assert.IsFalse(isFound, "Notepad textbox contains '" + typedText + "'");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (notepadApp.IsProcessOpen())
            {
                //notepadApp.Exit();
            }
        }
    }
}
