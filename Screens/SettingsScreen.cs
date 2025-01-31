using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using TodoistTest.Core;

namespace TodoistTest.Screens
{
    public class SettingsScreen : BaseScreen
    {
        public SettingsScreen(AppiumContext context) : base(context)
        {
        }

        private By logOutButtonLocator = By.XPath("//android.widget.TextView[@text='Log out']");
        private By logoutDialogYesButtonLocator = By.Id("android:id/button1");
        private By logoutDialogNoButtonLocator = By.Id("android:id/button2");

        public AppiumElement GetLogoutButton()
        {

            appiumContext.Driver
                .FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector()"
                                                         + ".resourceId(\"android:id/content\")).scrollIntoView("
                                                         + "new UiSelector().text(\"Log out\"));"));
            Thread.Sleep(500);
            return appiumContext.Driver.FindElement(logOutButtonLocator);
        }

        
        public AppiumElement GetLogoutDialogYesButton() => appiumContext.Driver.FindElement(logoutDialogYesButtonLocator);
        public AppiumElement GetLogoutDialogNoButton() => appiumContext.Driver.FindElement(logoutDialogNoButtonLocator);
    }
}
