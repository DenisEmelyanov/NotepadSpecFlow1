using System.Diagnostics;
using System;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;

namespace UnitTestProject1
{
    public class NotepadApp
    {
        private Application app;
        private Window window;

        private const string APP_NAME = "Notepad.exe";
        private string fileName;

        public NotepadApp(string fileName)
        {
            this.fileName = fileName;
        } 
        public NotepadApp() : this("") { }

        /// <summary>
        /// Launch Notepad app
        /// </summary>
        public void Launch()
        {
            app = Application.Launch(APP_NAME);
            window = app.GetWindow("Untitled - Notepad");
        }

        /// <summary>
        /// Type text in NotePad app
        /// </summary>
        /// <param name="text"></param>
        public void TypeText(string text)
        {
            Keyboard.Instance.Send(text, window);
        }

        /// <summary>
        /// Get text typed in Notepad
        /// </summary>
        /// <returns>text as string</returns>
        public string GetText()
        {
            return window.Get(SearchCriteria.ByControlType(ControlType.Document)).Name;
        }

        /// <summary>
        /// Click on specific item of menu
        /// </summary>
        /// <param name="menu">menu name</param>
        /// <param name="item">item name</param>
        public void ClickMenuItem(string menu, string item)
        {
            window.MenuBar.MenuItem(menu, item).Click();
        }

        /// <summary>
        /// Check if notepad process is running
        /// </summary>
        /// <returns></returns>
        public bool IsProcessOpen()
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains("notepad"))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Exit from Notepad app
        /// </summary>
        public void Exit()
        {
            app.Kill();
        }
    }
}
