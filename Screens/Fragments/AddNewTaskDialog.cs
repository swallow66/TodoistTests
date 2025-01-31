using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using TodoistTest.Core;

namespace TodoistTest.Screens.Fragments
{
    public class AddNewTaskDialog: BaseScreen
    {
        public AddNewTaskDialog(AppiumContext context) : base(context)
        {
        }

        private By taskTitleTextFieldLocator = By.Id("android:id/message");
        private By taskDescriptionTextFieldLocator = By.XPath("//android.widget.EditText[@resource-id='com.todoist:id/description']");
        private By submitButtonLocator = MobileBy.AccessibilityId("Add");

        public AppiumElement GetTaskTitleTextField() => appiumContext.Driver.FindElement(taskTitleTextFieldLocator);
        public AppiumElement GetTaskDescriptionTextField() => appiumContext.Driver.FindElement(taskDescriptionTextFieldLocator);
        public AppiumElement GetSubmitTaskButton() => appiumContext.Driver.FindElement(submitButtonLocator);

    }
}
