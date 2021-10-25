using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Satish_Assignment.TestScripts
{
    class Test_1
    {
        public static string url = "https://www.kurtosys.com/";
        public static IWebDriver driver;
      //  [Test]
        [Obsolete]
        public static void Tc_01()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);


            //STep 1 - Mouse Hover on Resourse_drpdn
            IWebElement Resourse_drpdn = driver.FindElement(By.XPath("((//span[normalize-space(@class)='menu-image-title' and normalize-space(text())='Resources']))"));
             Actions act = new Actions(driver);
             act.MoveToElement(Resourse_drpdn).Perform();
           
            //Step - 2 Click on White Papers & eBooks
            IWebElement White_Papers_eBooks = driver.FindElement(By.XPath("/html/body/div[1]/div/div/section/div/div/div[2]/div/div/div/div/div/div/div/ul/li[3]/div/div/div/div/section/div/div/div[2]/div/div/div[2]/div/ul/li[4]/a/span[2]"));
            White_Papers_eBooks.Click();

            //Tittle Verification
            string Given_Titl = "White Papers | Kurtosys";
            string PageTitle = driver.Title;
            Console.WriteLine(PageTitle);
            Assert.That(Given_Titl, Is.EqualTo(PageTitle));

            //clicking on Click_Any_White_Papers_eBooks1
            IWebElement Click_Any_White_Papers_eBooks1 = driver.FindElement(By.XPath("/html/body/div[2]/div/div/section[2]/div/div/div/div/div/div/div/div"));
            Click_Any_White_Papers_eBooks1.Click();
            IWebElement Click_Any_White_Papers_eBooks2 = driver.FindElement(By.XPath("/html/body/div[2]/div/div/section[2]/div/div/div/div/div/div/div/div/article[2]/div/div[1]/p/a"));
            Click_Any_White_Papers_eBooks2.Click();

            //Handling Form using Iframes 
             IWebElement iframe_Form = driver.FindElement(By.XPath("/html/body/div[2]/div/div/section/div/div/div/div/div/div/div/div/div/div/section[4]/div/div/div[2]/div/div/div[2]/div/iframe"));
             driver.SwitchTo().Frame(iframe_Form);

            //FirstName Text Field
            IWebElement FirstName = driver.FindElement(By.Id("18882_241306pi_18882_241306"));
            FirstName.SendKeys("Jade");

            //LastName Text Field
            IWebElement LastName = driver.FindElement(By.Id("18882_241308pi_18882_241308"));
            LastName.SendKeys("kone");

            //Email Text Field
            IWebElement email = driver.FindElement(By.Id("18882_241310pi_18882_241310"));
            email.SendKeys("jadekone@xyz.com");

            //Company Text Field
            IWebElement company = driver.FindElement(By.Id("18882_241312pi_18882_241312"));
            company.SendKeys("xyz.com");

            //Industry Drop down
            IWebElement industry = driver.FindElement(By.Id("18882_241314pi_18882_241314"));
            SelectElement industrys = new SelectElement(industry);
            industrys.SelectByText("Asset and Investment Management");

            //Click on Submit Button
            IWebElement submit_form = driver.FindElement(By.XPath("/html/body/form/p[2]"));
            submit_form.Submit();
            //driver.Quit(); 

        }
    }
}
