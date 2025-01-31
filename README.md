
# Todoist App Automation Tests - Setup & Run Instructions (Windows)

## Prerequisites

- Visual Studio (2019 or later)
- .NET SDK (5.0 or later)
- Appium
- Android Studio including Android SDK
- Node.js
- SpecFlow NuGet Package
- NUnit NuGet Package
- Android Emulator/Device

## Setup Instructions

1. Clone the repository:
   git clone <repository_url>
        
2. Install Appium and it's drivers
        npm install -g appium
        appium driver install uiautomator2
        appium driver install xcuitest

3. Install dependencies in Visual Studio:
   - **Tools > NuGet Package Manager > Restore NuGet Packages**
   - Or use **Package Manager Console**:
     Update-Package -Reinstall

4. Set up the ANDROID_HOME environment variable to point to the SDK location C:\Users\<YourUser>\AppData\Local\Android\Sdk

5. Configure Desired Capabilities in `appsettings.json` file in the root project folder:
    Provide device name and UDID of your Android device or emulator.
    
          "DeviceName": "samsung SM-G781B",
          "Udid": "RFCT417XFPX",

6. Start Appium Server:
   - Open **Appium Desktop** and click **Start Server**.
   - Or use command line:
       appium

7. Ensure Android Emulator/Device is connected:       
       adb devices
   
## Running the Tests

### Option 1: Run in Visual Studio via Test Explorer
1. Open **Test Explorer** (**Test > Windows > Test Explorer**).
2. Right-click tests or project and select **Run**.

### Option 2: Run via NUnit Console Runner
1. Install NUnit Console Runner via NuGet:
   Install-Package NUnit.ConsoleRunner
 
2. Run tests with the following command:
   nunit3-console C:\{Projects_Path}\TodoistTest\bin\Debug\net8.0\TodoistTest.dll
