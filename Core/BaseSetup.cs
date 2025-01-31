using BoDi;
using TechTalk.SpecFlow;

namespace TodoistTest.Core
{
    [Binding]
    public class BaseSetup
    {        
        private readonly IObjectContainer _objectContainer;
        private static AppiumContext _appiumContext;

        public BaseSetup(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _appiumContext = new AppiumContext();
            _objectContainer.RegisterInstanceAs<AppiumContext>(_appiumContext);
            _appiumContext.Driver.TerminateApp("com.todoist");
        }

        [AfterScenario]
        public void Cleanup()
        {
            _appiumContext?.Driver?.Quit();
        }
    }
}