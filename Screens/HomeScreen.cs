using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using TodoistTest.Core;

namespace TodoistTest.Screens
{
    public class HomeScreen : BaseScreen
    {        
        public HomeScreen(AppiumContext context) : base(context) {}

        private By continueWithGoogleButtonLocator = By.Id("com.todoist:id/btn_google");
        private By continueWithEmailButtonLocator = By.Id("com.todoist:id/btn_email");
        private By emailLoginButtonLocator = By.Id("com.todoist:id/email_login");
        private By emailSignupButtonLocator = By.Id("com.todoist:id/email_signup");

        public AppiumElement GetContinueWithGoogleButton() => appiumContext.Driver.FindElement(continueWithGoogleButtonLocator);
        public AppiumElement GetContinueWithEmailButton() => appiumContext.Driver.FindElement(continueWithEmailButtonLocator);
        public AppiumElement GetLoginWithEmailButton() => appiumContext.Driver.FindElement(emailLoginButtonLocator);
        public AppiumElement GetSignupWithEmailButton() => appiumContext.Driver.FindElement(emailSignupButtonLocator);
        
    }
}
