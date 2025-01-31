using TodoistTest.Core;

namespace TodoistTest.Screens
{
    public abstract class BaseScreen
    {
        protected readonly AppiumContext appiumContext;

        protected BaseScreen(AppiumContext context)
        {
            this.appiumContext = context;
        }

    }
}
