#region Usings

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

#endregion

namespace KneatAutomationTestChallenge.Tests
{
    [TestFixture]
    public class TestsTemplate
    {
        #region Fields

        /// <summary>
        /// The Hotel to find String.
        /// </summary>
        protected string HotelToFind = string.Empty;

        /// <summary>
        /// The Hotel unable to find on page.
        /// </summary>
        protected string HotelUnableToFind = string.Empty;

        /// <summary>
        /// The only results string.
        /// </summary>
        protected string TakeOnlyResult = string.Empty;

        /// <summary>
        /// The Element needed to find attribiute
        /// </summary>
        protected IWebElement ElementToFind;

        /// <summary>
        /// The Webdriver
        /// </summary>
        IWebDriver driver;

        /// <summary>
        /// The name string.
        /// </summary>
        protected string name = "name";

        /// <summary>
        /// The class name string.
        /// </summary>
        protected string ClassName = "classname";

        /// <summary>
        /// The xpath string.
        /// </summary>
        protected string xpath = "xpath";

        /// <summary>
        /// The value string.
        /// </summary>
        protected string value = "value";

        #endregion

        #region xpaths

        /// <summary>
        /// The month switch xpath.
        /// </summary>
        protected string MonthSwitchXpath = "//*[@id=\"frm\"]/div[1]/div[2]/div[2]/div/div/div[2]";
        
        /// <summary>
        /// The calendar xpath.
        /// </summary>
        protected string CalendarXpath = "//span[@class= 'sb-date-field__icon sb-date-field__icon-btn bk-svg-wrapper calendar-restructure-sb']";
        
        /// <summary>
        /// The hotel list xpath.
        /// </summary>
        protected string HotelListXpath = "//*[@id=\"hotellist_inner\"]";
        
        /// <summary>
        /// The cookies warining xpath.
        /// </summary>
        protected string CookiesWarningXpath = "//*[@id=\"cookie_warning\"]";
        
        /// <summary>
        /// The Accept cookies button xpath.
        /// </summary>
        protected string AcceptTheCookiesXpath = "//*[@id=\"cookie_warning\"]/div/div/div[2]/button";
        
        /// <summary>
        /// The change language xpath.
        /// </summary>
        protected string ChangeLangugeXpath = "//*[@id=\"user_form\"]/ul/li[2]";
        
        /// <summary>
        /// The Choose UK language xpath.
        /// </summary>
        protected string ChooseUKLanguageXpath = "//*[@id=\"current_language_foldout\"]/div[2]/div/ul[1]/li[1]/a";
        
        #endregion

        #region PrepareWebsite
        /// <summary>
        /// Prepare Website to Tests(Cookies killer, Language Change,
        /// Wait fo elemnts definition)
        /// </summary>
        [SetUp]
        public void startBrowserAndNavigateToTestingSite()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.booking.com";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            CookiesChecker();
            ChangeLeangueToUK();
        }
        #endregion

        #region CleanUp
        /// <summary>
        /// Close Browser and clean up.
        /// </summary>
        [TearDown]
        public void CloseBrowserAndCleanUp()
        {
            driver.Close();
        }
        #endregion

        #region Methods
        /// <summary>
        /// This method taking the data, choosen by user and fill all fields.
        /// </summary>
        /// <param name="Info">
        /// The data needed to fill all informations
        /// </param>
        public void FillWithSampleData(InformationAboutBook Info)
        {
            driver.FindElement(By.Name("ss")).SendKeys(Info.Destination);
            CantTouchThisCalendar2(Info.CheckInDate.Day, Info.CheckOutDate.Day, Info.HowManyMonthsFromTodayDate);
            SetValueOfParameter("no_rooms", value, Info.Room.ToString());
            SetValueOfParameter("group_adults", value, Info.Adults.ToString());
            SetValueOfParameter("group_children", value, Info.Children.ToString());
            FindAndNavigate(true, "sb-searchbox__button", ClassName);              
        }

        /// <summary>
        /// Set the data.
        /// </summary>
        /// <param name="Destination">
        /// The destination.
        /// </param>
        /// <param name="Room">
        /// The number of rooms.
        /// </param>
        /// <param name="Adults">
        /// The number of adults.
        /// </param>
        /// <param name="Children">
        /// The number of childrens.
        /// </param>
        /// <param name="HowManyMonthsFromTodayDate">
        /// The number of months untill we would travel.
        /// </param>
        /// <param name="HowManyDaysToCheckOut">
        /// The number of days, that we would like to book a hotel.
        /// </param>
        /// <param name="Spa">
        /// The fun things to do
        /// </param>
        /// <param name="HowManyStars">
        /// The number of stars.
        /// </param>
        /// <returns>
        /// The data
        /// </returns>
        public InformationAboutBook SetData(string Destination, int Room, int Adults, int Children,
                                            int HowManyMonthsFromTodayDate, int HowManyDaysToCheckOut,
                                            string Spa, int HowManyStars = 0)
        {
            InformationAboutBook Data = new InformationAboutBook();
            Data.Destination = Destination;
            Data.Room = Room;
            Data.Adults = Adults;
            Data.Children = Children;
            Data.HowManyMonthsFromTodayDate = HowManyMonthsFromTodayDate;
            Data.HowManyDaysToCheckOut = HowManyDaysToCheckOut;
            Data.Spa = Spa;
            Data.HowManyStars = HowManyStars;

            return Data;
        }

        /// <summary>
        /// This function supports the Calendar.
        /// </summary>
        /// <param name="CheckInDay">
        /// The check in day.
        /// </param>
        /// <param name="CheckOutDay">
        /// The check out day.
        /// </param>
        /// <param name="HowManyMonthsFromToday">
        /// The number of months from today.
        /// </param>
        public void CantTouchThisCalendar2(int CheckInDay, int CheckOutDay, int HowManyMonthsFromToday)
        {
            FindAndNavigate(true, CalendarXpath, xpath);
            for (int i = 0; i < HowManyMonthsFromToday; i++)
            {
                FindAndNavigate(true, MonthSwitchXpath, xpath);
            }
            FindAndNavigate(true, "//*[@id=\"frm\"]/div[1]/div[2]/div[2]/div/div/div[3]/div[1]/table//*[contains(text(),'" + CheckInDay.ToString() + "')]", xpath);
            FindAndNavigate(true, "//*[@id=\"frm\"]/div[1]/div[2]/div[2]/div/div/div[3]/div[1]/table//*[contains(text(),'" + CheckOutDay.ToString() + "')]", xpath);
        }

        /// <summary>
        /// This function navigate and finding an element. 
        /// </summary>
        /// <param name="Clickable">
        /// The info about clicking an element.
        /// </param>
        /// <param name="StringToFind">
        /// The string of param to find.
        /// </param>
        /// <param name="FindBy">
        /// The info about chosen way to find param.
        /// </param>
        public void FindAndNavigate(Boolean Clickable, string StringToFind, string FindBy)
        {
            if(FindBy == xpath)
            {
                ElementToFind = driver.FindElement(By.XPath("" + StringToFind + ""));
            }
            else if(FindBy == ClassName)
            {
                ElementToFind = driver.FindElement(By.ClassName("" + StringToFind + ""));
            }
            else if(FindBy == name)
            {
                ElementToFind = driver.FindElement(By.Name("" + StringToFind + ""));
            }
            Navigate(ElementToFind);
            if (Clickable)
            {
                ElementToFind.Click();
            }
        }

        /// <summary>
        /// This function navigate to element.
        /// </summary>
        /// <param name="NavigateTo">
        /// The element to navigate
        /// </param>
        public void Navigate(IWebElement NavigateTo)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", NavigateTo);
        }

        /// <summary>
        /// The change of leangue.
        /// </summary>
        public void ChangeLeangueToUK()
        {
            driver.FindElement(By.XPath(ChangeLangugeXpath)).Click();
            driver.FindElement(By.XPath(ChooseUKLanguageXpath)).Click();
        }

        /// <summary>
        /// The cookies killer.
        /// </summary>
        public void CookiesChecker()
        {
            if (driver.FindElements(By.XPath(CookiesWarningXpath)).Count() > 0)
            {
                FindAndNavigate(true, AcceptTheCookiesXpath, xpath);
            }
        }

        /// <summary>
        /// The Setter value of parrameter without clicking.
        /// </summary>
        /// <param name="ElementToFind">
        /// The element to find string.
        /// </param>
        /// <param name="Atributte">
        /// The atrribute value to change
        /// </param>
        /// <param name="Value">
        /// The new value.
        /// </param>
        public void SetValueOfParameter(String ElementToFind, String Atributte, String Value)
        {
            IWebElement WebElement = driver.FindElement(By.Name(ElementToFind));
            setAttribute(WebElement, Atributte, Value);
        }

        /// <summary>
        /// The functiong setting of new value.
        /// </summary>
        /// <param name="element">
        /// The element
        /// </param>
        /// <param name="attName">
        /// The attribute name.
        /// </param>
        /// <param name="attValue">
        /// The new value.
        /// </param>
        public void setAttribute(IWebElement element, String attName, String attValue)
        {
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);",
                    element, attName, attValue);
        }

        /// <summary>
        /// This method looking for a deffined hotel.
        /// </summary>
        /// <param name="HotelToFind">
        /// The name of hotel to find.
        /// </param>
        /// <param name="ExpectedResult">
        /// The expected result
        /// </param>
        public void VerifyIfHotelIsVisible(string HotelToFind, Boolean ExpectedResult)
        {
        var FoundHostels = driver.FindElements(By.XPath(HotelListXpath)).First();
            
        //Remove all proposes from website.
        if (FoundHostels.Text.Contains("No properties left"))
        {
            TakeOnlyResult = FoundHostels.Text.Remove(FoundHostels.Text.LastIndexOf("No properties left") + 1);
        }
        else if(FoundHostels.Text.Contains("Missing filters"))
        {
            TakeOnlyResult = FoundHostels.Text.Remove(FoundHostels.Text.LastIndexOf("Missing filters") + 1);

        }
        else
        {
            TakeOnlyResult = FoundHostels.Text;
        }
        if (ExpectedResult)
            {
                if (TakeOnlyResult.Contains(HotelToFind))
                {
                    Assert.That(true, Is.True);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else
            {
                if (TakeOnlyResult.Contains(HotelToFind))
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    Assert.That(true, Is.True);
                }
            }
        }
        #endregion
    }
}
