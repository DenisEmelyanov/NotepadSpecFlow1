using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace UnitTestProject1
{
    [Binding]
    public class NotepadUndoSteps
    {
        private NotepadApp notepadApp;

        [BeforeScenario("launch_notepad")]
        public void BeforeScenario()
        {
            GivenIHaveLaunchedNotepad();
        }

        [Given(@"I just have launched Notepad")]
        public void GivenIHaveLaunchedNotepad()
        {
            notepadApp = new NotepadApp();
            notepadApp.Launch();
        }

        [When(@"I click on '(.*)' menu")]
        public void WhenIClickOnMenu(string menu)
        {
            notepadApp.ClickMenu(menu);
        }

        [Then(@"'(.*)' menu item is (.*)")]
        public void ThenMenuItemIs(string menuItem, string menuItemState)
        {
            switch (menuItemState)
            {
                case "enabled":
                    {
                        Assert.IsTrue(notepadApp.IsMenuItemEnabled(menuItem), "[" + menuItem + "] item is disabled");
                        break;
                    }
                case "disabled":
                    {
                        Assert.IsFalse(notepadApp.IsMenuItemEnabled(menuItem), "[" + menuItem + "] item is enabled");
                        break;
                    }
                default:
                    {
                        throw new Exception("Menu item can be only 'enabled' or 'disabled'");
                    }
            }
        }

        [Given(@"I have typed '(.*)' text")]
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
            //if (notepadApp.IsProcessOpen())
            //{
            //    notepadApp.Exit();
            //    notepadApp = null;
            //}
        }
    }
}
