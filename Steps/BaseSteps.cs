using TodoistTest.Core;
using TodoistTest.Screens;

namespace TodoistTest.Steps
{
    public class BaseSteps 
    {

        protected readonly AppiumContext appiumContext;
        protected readonly HomeScreen homeScreen;
        protected readonly LoginScreen loginScreen;
        protected readonly TodayScreen todayScreen;
        protected readonly UserProfileScreen userProfileScreen;
        protected readonly SettingsScreen settingsScreen;

        public BaseSteps(AppiumContext context)
        {
            this.appiumContext = context;
            this.homeScreen = new HomeScreen(appiumContext);
            this.loginScreen = new LoginScreen(appiumContext);
            this.todayScreen = new TodayScreen(appiumContext);
            this.userProfileScreen = new UserProfileScreen(appiumContext);
            this.settingsScreen = new SettingsScreen(appiumContext);
        }

    }
}
