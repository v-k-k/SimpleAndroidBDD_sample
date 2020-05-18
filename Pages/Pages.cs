using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using NUnit.Framework;

namespace SimpleAndroidBDD_sample.Pages
{
    class MainPage : BasePage
    {
        public MainPage(AndroidDriver<AndroidElement> driver) :
            base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "com.nulltree.roundbell:id/setting_button")]
        private IWebElement settingsButton { get; set; }

        [FindsBy(How = How.Id, Using = "com.nulltree.roundbell:id/favorite_button")]
        public IWebElement favoriteButton { get; set; }

        public void ClickSettingsButton()
        {
            settingsButton.Click();
        }

        public void ClickFavoriteButton()
        {
            wait.Until(driver => favoriteButton.Displayed);
            favoriteButton.Click();
        }
    }

    class SettingsPage : BasePage
    {
        public SettingsPage(AndroidDriver<AndroidElement> driver) :
            base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "com.nulltree.roundbell:id/break_up")]
        private IWebElement moreBreak { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='com.nulltree.roundbell:id/ll_favorite']/android.widget.LinearLayout/android.widget.ImageView")]
        private IWebElement addToFavorites { get; set; }

        [FindsBy(How = How.Id, Using = "com.nulltree.roundbell:id/et_title")]
        private IWebElement placeholder { get; set; }
        
        [FindsBy(How = How.Id, Using = "com.nulltree.roundbell:id/training_time")]
        private IWebElement trainingTime { get; set; }

        [FindsBy(How = How.Id, Using = "com.nulltree.roundbell:id/break_time")]
        private IWebElement breakTime { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='com.nulltree.roundbell:id/ll_app_info']/android.widget.LinearLayout/android.widget.ImageView")]
        private IWebElement aboutApp { get; set; }

        [FindsBy(How = How.Id, Using = "android:id/button1")]
        private IWebElement favoriteTitleLocatorsOK { get; set; }

        [FindsBy(How = How.Id, Using = "com.nulltree.roundbell:id/tv_evaluate")]
        private IWebElement evaluate { get; set; }

        [FindsBy(How = How.Id, Using = "android:id/alertTitle")]
        private IWebElement alertWindowTitle { get; set; }

        [FindsBy(How = How.Id, Using = "com.nulltree.roundbell:id/btn_listen")]
        private IWebElement bellButton { get; set; }


        public void IncreaseBreakTime(int times)
        {
            for (int i = 0; i < times; i++) moreBreak.Click();
        }

        public string getTrainingTime()
        {
            return trainingTime.Text;
        }

        public string getBreakTime()
        {
            return breakTime.Text;
        }

        public void checkSoundLevel()
        {
            Mover(10, 550, 10, 50);
            /*
            var seekBar = driver.FindElement(By.Id("com.nulltree.roundbell:id/sb_volume"));            
            var start = seekBar.Location.X;
            var end = seekBar.Size.Width;
            var ycd = seekBar.Location.Y;
            Mover(start, ycd, end, ycd);
            bellButton.Click();*/

            Mover(10, 850, 10, 30);
        }

        public void checkPlaceholder(string pattern)
        {
            addToFavorites.Click();
            Assert.AreEqual(pattern, placeholder.Text);
        }

        public void sendTitle(string checkTitle)
        {
            addToFavorites.Click(); 
            placeholder.SendKeys(checkTitle);
            favoriteTitleLocatorsOK.Click();
        }

        public void openaboutPage()
        {
            aboutApp.Click();
            evaluate.Click();
        }

        public void getInfoTitle(string pattern)
        {
            string result = "";
            try
            {
                result = result + alertWindowTitle.Text;
            }
            catch
            {
                this.Mover(10, 550, 10, 50);
                this.Mover(10, 850, 10, 30);
                this.openaboutPage();
                result = result + alertWindowTitle.Text;
            }
            Assert.IsTrue(result.Contains(pattern));
        }

    }

    class AdditionalInfoPage : BasePage
    {
        public AdditionalInfoPage(AndroidDriver<AndroidElement> driver) :
            base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "android:id/aerr_app_info")]
        private IWebElement appInfo { get; set; }

        [FindsBy(How = How.Id, Using = "com.android.settings:id/entity_header_title")]
        private IWebElement appTitile { get; set; }


        public void getInfoTitle(string pattern)
        {
            appInfo.Click();
            Assert.AreEqual(pattern, appTitile.Text);
        }
    }

    class FavoritePage : BasePage
    {
        public FavoritePage(AndroidDriver<AndroidElement> driver) :
            base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "com.nulltree.roundbell:id/tv_title")]
        private IWebElement infoTitile { get; set; }

        [FindsBy(How = How.Id, Using = "com.nulltree.roundbell:id/tv_training_time")]
        private IWebElement trainingTime { get; set; }

        [FindsBy(How = How.Id, Using = "com.nulltree.roundbell:id/tv_break_time")]
        private IWebElement breakTime { get; set; }


        public void checkSavedTitle(string pattern)
        {
            Assert.AreEqual(pattern, infoTitile.Text);
        }

        public void checkTrainingTime(string pattern)
        {
            Assert.AreEqual(pattern, trainingTime.Text);
        }

        public void checkBreakTime(string pattern)
        {
            Assert.AreEqual(pattern, breakTime.Text);
        }
    }
}
