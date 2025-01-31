using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;

namespace TodoistTest.Core;

public class AppiumContext
{
    public AppiumDriver Driver { get; private set; }
    private static IConfiguration? configuration;

    public AppiumContext()
    {
        // Build configuration
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true); // Add the JSON file

        configuration = builder.Build();

        var appiumOptions = new AppiumOptions();

        var platform = Environment.GetEnvironmentVariable("Platform") ?? "Android";
        var capabilities = configuration.GetSection(platform).GetChildren()
            .ToDictionary(x => x.Key, x => x.Value);

        appiumOptions.AutomationName = "UiAutomator2";
        foreach (var capability in capabilities)
        {
            appiumOptions.AddAdditionalAppiumOption(capability.Key, capability.Value);
        }

        // Initialize the driver
        if (platform.Equals("Android", StringComparison.OrdinalIgnoreCase))
        {
            Driver = new AndroidDriver(new Uri("http://localhost:4723/"), appiumOptions);
        }
        else if (platform.Equals("iOS", StringComparison.OrdinalIgnoreCase))
        {
            Driver = new IOSDriver(new Uri("http://localhost:4723/"), appiumOptions);
        }

        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

}