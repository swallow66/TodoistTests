using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using TodoistTest.Core;

namespace TodoistTest.Screens;

public class UserProfileScreen : BaseScreen
{
    public UserProfileScreen(AppiumContext context) : base(context)
    {
    }

    private By SettingsMenuButtonLocator = By.XPath("//android.view.View[@content-desc='Settings']");

    public AppiumElement GetSettingsMenuButton() => appiumContext.Driver.FindElement(SettingsMenuButtonLocator);
}