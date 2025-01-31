using NUnit.Framework;
using TechTalk.SpecFlow;
using TodoistTest.Core;

namespace TodoistTest.Steps
{
    [Binding]
    public class LoginSteps : BaseSteps
    {
        public LoginSteps(AppiumContext context) : base(context)
        {
        }
        
        [Given(@"I am on the login screen")]
        public void GivenIAmOnTheLoginScreen()
        {
            appiumContext.Driver.ActivateApp(appiumContext.Driver.Capabilities["AppPackage"].ToString());
            if (todayScreen.IsBottomMenuDisplayed())
            {
                todayScreen.GetBrowseBottomMenuItem().Click();
                userProfileScreen.GetSettingsMenuButton().Click();
                settingsScreen.GetLogoutButton().Click();
                settingsScreen.GetLogoutDialogYesButton().Click();
            }
        }

        [Then(@"I should be able to continue with Google or Email option")]
        public void ThenIShouldSeeTwoLoginOptions()
        {
            Assert.That(homeScreen.GetContinueWithGoogleButton().Displayed);
            Assert.That(homeScreen.GetContinueWithEmailButton().Displayed);
        }

        [When(@"I choose '(Continue with email|Continue with Google)' option")]
        public void WhenIChooseLoginOption(String option)
        {
            if (option.Equals("Continue with email"))
            {
                homeScreen.GetContinueWithEmailButton().Click();
            }
            else
            {
                homeScreen.GetContinueWithGoogleButton().Click();
            }
        }


        [Then(@"I should be able to sign up or login with email")]
        public void ThenIShouldSeeTwoContinueWithEmailOptions()
        {
            Assert.That(homeScreen.GetLoginWithEmailButton().Displayed);
            Assert.That(homeScreen.GetSignupWithEmailButton().Displayed);
        }

        [When(@"I choose '(Login|Sign up) with email' option")]
        public void WhenIChooseSignupLoginWithEmailOption(String option)
        {
            if (option.Equals("Login"))
            {
                homeScreen.GetLoginWithEmailButton().Click();
            }
            else
            {
                homeScreen.GetSignupWithEmailButton().Click();
            }
        }

        [When(@"I enter my username and password")]
        public void WhenIEnterMyUsernameAndPassword(Table table)
        {
            var credentials = table.Rows[0]; 
            loginScreen.GetEmailTextField().SendKeys(credentials["email"]);
            loginScreen.GetPasswordTextField().SendKeys(credentials["password"]);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            loginScreen.GetLoginButton().Click();
        }

        [Then(@"I should see the Login screen")]
        public void ThenIShouldSeeTheLoginScreen()
        {
            Assert.That(loginScreen.GetLoginButton().Displayed);
        }

        [Then(@"I should see the login error message")]
        public void ThenIShouldSeeTheLoginError()
        {
            Assert.That(loginScreen.GetErrorMessage().Displayed);
        }

        [Given(@"I am logged in using the following credentials")]
        public void GivenIAmLoggedInUsingTheFollowingCredentials(Table table)
        {
            var credentials = table.Rows[0];

            appiumContext.Driver.ActivateApp(appiumContext.Driver.Capabilities["AppPackage"].ToString());

            homeScreen.GetContinueWithEmailButton().Click();
            homeScreen.GetLoginWithEmailButton().Click();

            loginScreen.GetEmailTextField().SendKeys(credentials["email"]);
            loginScreen.GetPasswordTextField().SendKeys(credentials["password"]);
            loginScreen.GetLoginButton().Click();
            Assert.That(todayScreen.GetTodayScreenContainer().Displayed);
        }       
        
        [Given(@"I am logged in as default user")]
        public void GivenIAmLoggedInUsingDefaultUser()
        {
            appiumContext.Driver.ActivateApp(appiumContext.Driver.Capabilities["AppPackage"].ToString());
            if (!todayScreen.IsBottomMenuDisplayed())
            {
                homeScreen.GetContinueWithEmailButton().Click();
                homeScreen.GetLoginWithEmailButton().Click();

                loginScreen.GetEmailTextField().SendKeys("elena.petrusha@gmail.com");
                loginScreen.GetPasswordTextField().SendKeys("Qw12!!!!");
                loginScreen.GetLoginButton().Click();
            }

            Assert.That(todayScreen.GetTodayScreenContainer().Displayed);
        }


        [Then(@"I should see the Home screen")]
        public void ThenIShouldSeeTheHomeScreen()
        {
            Assert.That(homeScreen.GetContinueWithEmailButton().Displayed);
        }
    }
}