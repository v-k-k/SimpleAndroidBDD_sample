using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using SimpleAndroidBDD_sample.Pages;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SimpleAndroidBDD_sample.StepDefinitions
{
    [Binding]
    public class TestMainFunctionsSteps : IDisposable
    {
        private AndroidDriver<AndroidElement> _driver;
        private MainPage mainPage;
        private SettingsPage settingsPage;
        private AdditionalInfoPage additionalInfoPage;
        private FavoritePage favoritePage;
        private AppiumOptions desiredCaps = new AppiumOptions();
        private string testAppPath;
        //private readonly ScenarioContext _scenarioContext;

        public TestMainFunctionsSteps(ScenarioContext scenarioContext)
        {
            //_scenarioContext = scenarioContext;
            testAppPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "BoxingTimer.apk");
            desiredCaps.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Android_Accelerated_x86_Oreo");
            desiredCaps.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.nulltree.roundbell");
            desiredCaps.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            desiredCaps.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "9");
            desiredCaps.AddAdditionalCapability(MobileCapabilityType.App, testAppPath);
            _driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), desiredCaps);
            mainPage = new MainPage(_driver);
            settingsPage = new SettingsPage(_driver);
            favoritePage = new FavoritePage(_driver);
            additionalInfoPage = new AdditionalInfoPage(_driver);
        }                     


        [Given(@"Tap on 'Settings' button, make sound louder and check if it was really done")]
        public void GivenTapOnButtonMakeSoundLouderAndCheckIfItWasReallyDone()
        {
            //_scenarioContext.Pending();
            mainPage.driver.LaunchApp();
            mainPage.ClickSettingsButton();
        }
        
        [When(@"click (.*) times on break seconds tap on 'Add to favorites'")]
        public void WhenClickTimesOnBreakSecondsTapOn(int p0)
        {
            //_scenarioContext.Pending();
            settingsPage.IncreaseBreakTime(p0);
            settingsPage.checkSoundLevel();
        }
        
        [Then(@"New window contains the (.*) placeholder")]
        public void ThenNewWindowContainsThePleaseEnterTheTitle_Placeholder(string p0)
        {
            //_scenarioContext.Pending();
            settingsPage.checkPlaceholder(p0);
        }
        
        [Then(@"Send (.*) and check if app info contains (.*) in window title")]
        public void ThenAppInfoContainsBoxingTimerInWindowTitle(string p0, string p1)
        {
            //_scenarioContext.Pending();
            settingsPage.sendTitle(p0);
            settingsPage.openaboutPage();
            settingsPage.getInfoTitle(p1);
        }
        
        [Then(@"System info contains (.*) in app title")]
        public void ThenSystemInfoContainsBoxingTimerInAppTitle(string p0)
        {
            //_scenarioContext.Pending();
            additionalInfoPage.getInfoTitle(p0);
        }
        
        [Then(@"Saved settings contains (.*) in title")]
        public void ThenSavedSettingsContainsHeyHelloInTitle(string p0)
        {
            //_scenarioContext.Pending();
            settingsPage.sendTitle(p0);
            settingsPage.BackToMain();
            mainPage.ClickFavoriteButton();
            favoritePage.checkSavedTitle(p0);
        }
        
        [Then(@"training time is (.*)")]
        public void ThenTrainingTimeIs(string p0)
        {
            //_scenarioContext.Pending();
            favoritePage.checkTrainingTime(p0);
        }
        
        [Then(@"break time is (.*) after 3 clicks")]
        public void ThenBreakTimeIsAfterClicks(string p0)
        {
            //_scenarioContext.Pending();
            favoritePage.checkBreakTime(p0);
        }
        
        public void Dispose()
        {
            if (_driver != null)
            {
                _driver.Dispose();
                _driver = null;
            }
        }
    }
}
