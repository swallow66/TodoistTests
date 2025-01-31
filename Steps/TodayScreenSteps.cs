using NUnit.Framework;
using TechTalk.SpecFlow;
using TodoistTest.Core;

namespace TodoistTest.Steps;

[Binding]
public class TodayScreenSteps : BaseSteps
{
    public TodayScreenSteps(AppiumContext context) : base(context)
    {
    }


    [Then(@"I should see the Today screen")]
    public void ThenIShouldSeeTheTodayScreen()
    {
        Assert.That(todayScreen.GetTodayScreenContainer().Displayed);
    }

    [When(@"I perform logout action")]
    public void WhenIPerformLogoutAction()
    {
        todayScreen.GetBrowseBottomMenuItem().Click();
        userProfileScreen.GetSettingsMenuButton().Click();
        settingsScreen.GetLogoutButton().Click();
        settingsScreen.GetLogoutDialogYesButton().Click();
    }

}