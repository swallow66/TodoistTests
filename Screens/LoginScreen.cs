using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using TodoistTest.Core;

namespace TodoistTest.Screens
{
    public class LoginScreen : BaseScreen
    {
        public LoginScreen(AppiumContext context) : base(context)
        {
        }

        private By emailTextFieldLocator = By.XPath("//android.widget.EditText[@resource-id='email']");
        private By passwordTextFieldLocator = By.XPath("//android.widget.EditText[@resource-id='password']");
        private By loginButtonLocator = By.XPath("//android.view.View[@resource-id='auth_button_tag']");
        private By loginErrorLocator = By.XPath("//android.widget.Toast");

        public AppiumElement GetEmailTextField() => appiumContext.Driver.FindElement(emailTextFieldLocator);
        public AppiumElement GetPasswordTextField() => appiumContext.Driver.FindElement(passwordTextFieldLocator);
        public AppiumElement GetLoginButton() => appiumContext.Driver.FindElement(loginButtonLocator);
        public AppiumElement GetErrorMessage() => appiumContext.Driver.FindElement(loginErrorLocator);

    }
}
