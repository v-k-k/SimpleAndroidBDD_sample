using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.UI;
using System;

namespace SimpleAndroidBDD_sample.Pages
{
    abstract class BasePage
    {
        public TouchAction tap;
        public AndroidDriver<AndroidElement> driver;
        public WebDriverWait wait;

        public BasePage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            tap = new TouchAction(driver);
        }

        public void Mover(int x1, int y1, int x2, int y2)
        {
            tap.Press(x1, y1).MoveTo(x2, y2).Release().Perform();
        }

        public void BackToMain()
        {
            for (int i = 0; i < 2; i++) driver.PressKeyCode(4);
        }
    }
}
