using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using TodoistTest.Core;
using TodoistTest.Core.Models;
using TodoistTest.Screens.Fragments;

namespace TodoistTest.Screens
{
    public class TodayScreen : BaseScreen
    {
        public TodayScreen(AppiumContext context) : base(context)
        {
            addNewTaskDialog = new AddNewTaskDialog(context);
        }
        
        private By todayScreenContainerLocator = By.Id("com.todoist:id/content_container");
        private By quickAddTaskButtonLocator = By.Id("com.todoist:id/fab");
        private By browseBottomMenuItemLocator = By.XPath("//android.widget.TextView[@text='Browse']");

        private String taskNameIdentifier =
            "//android.widget.RelativeLayout[@resource-id='com.todoist:id/item'][.//android.widget.TextView[@text='{0}']]";

        private By taskDescriptionLocator =
            By.XPath(".//android.widget.TextView[@resource-id='com.todoist:id/description']");
        
        private By completeTaskCheckboxLocator =
            By.XPath(".//android.widget.CheckBox[@resource-id='com.todoist:id/checkmark']");

        private AddNewTaskDialog addNewTaskDialog;
        public AppiumElement GetTodayScreenContainer() => appiumContext.Driver.FindElement(todayScreenContainerLocator);
        public AppiumElement GetQuickAddTaskButton() => appiumContext.Driver.FindElement(quickAddTaskButtonLocator);
        public AppiumElement GetBrowseBottomMenuItem() => appiumContext.Driver.FindElement(browseBottomMenuItemLocator);
        public AddNewTaskDialog GetAddNewTaskDialog() => addNewTaskDialog;

        public AppiumElement GetTask(TodoistTask task)
        {
            string taskXpath = String.Format(taskNameIdentifier, task.Title);
            return appiumContext.Driver.FindElement(By.XPath(taskXpath));
        }

        public AppiumElement GetTaskDescription(TodoistTask task)
        {
            return GetTask(task).FindElement(taskDescriptionLocator);
        }

        public AppiumElement GetCompleteTaskCheckbox(TodoistTask task)
        {
            return GetTask(task).FindElement(completeTaskCheckboxLocator);
        }

        public bool IsBottomMenuDisplayed()
        {
            try
            {
                return appiumContext.Driver.FindElement(browseBottomMenuItemLocator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
