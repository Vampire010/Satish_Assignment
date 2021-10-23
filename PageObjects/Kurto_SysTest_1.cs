using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Satish_Assignment.Browser_SetUp;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace Satish_Assignment.PageObjects
{
    class Kurto_SysTest_1 : Browser_Launcher
    {
        private WebDriverWait wait;
        public IWebDriver driver;

        private By Resourse_drpdn_loc = By.XPath("/html/body/div[1]/div/div/section/div/div/div[2]/div/div/div/div/div/div/div/ul/li[3]/a/div/div/span");

        private By White_Papers_eBooks_loc = By.XPath("/html/body/div[1]/div/div/section/div/div/div[2]/div/div/div/div/div/div/div/ul/li[3]/div/div/div/div/section/div/div/div[2]/div/div/div[2]/div/ul/li[4]/a/span[2]");

        private By Click_Any_White_Papers_eBooks1_loc = By.XPath("/html/body/div[2]/div/div/section[2]/div/div/div/div/div/div/div/div");

        private By Click_Any_White_Papers_eBooks2_loc = By.XPath("/html/body/div[2]/div/div/section[2]/div/div/div/div/div/div/div/div/article[2]/div/div[1]/p/a");

        private By iframe_Form_loc = By.XPath("/html/body/div[2]/div/div/section/div/div/div/div/div/div/div/div/div/div/section[4]/div/div/div[2]/div/div/div[2]/div/iframe");

        //FirstName Text Field
        private By FirstName_loc = By.Id("18882_241306pi_18882_241306");
        //LastName Text Field
        private By LastName_loc = By.Id("18882_241308pi_18882_241308");
        //Email Text Field
        private By email_loc = By.Id("18882_241310pi_18882_241310");
        //Company Text Field
        private By company_loc = By.Id("18882_241312pi_18882_241312");
        //Industry Drop down
        private By industry_loc = By.Id("18882_241314pi_18882_241314");
        //Click on Submit Button
        private By submit_form_loc = By.XPath("/html/body/form/p[2]");

        public Kurto_SysTest_1(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void Resourse_drpdn()
        {
            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(White_Papers_eBooks_loc)).Perform();

            driver.FindElement(White_Papers_eBooks_loc).Click();
            try
            {
                //Tittle Verification
                string Given_Titl = "White Papers | Kurtosys";
                string PageTitle = driver.Title;
                Console.WriteLine(PageTitle);
                Assert.That(Given_Titl, Is.EqualTo(PageTitle));
            }
            catch(Exception E) 
            {
                Console.WriteLine(E);
            }
        }

        public void Click_Any_White_Papers_eBooks1()
        {
            driver.FindElement(Click_Any_White_Papers_eBooks1_loc).Click();
            driver.FindElement(Click_Any_White_Papers_eBooks2_loc).Click();
        }

        public void iframe_Form()
        {
            IWebElement iframe_Form = driver.FindElement(iframe_Form_loc);
            driver.SwitchTo().Frame(iframe_Form);
        }


        //FirstName Text Field
        public void Frst_Name()
        {
            IWebElement FirstName = driver.FindElement(FirstName_loc);
            FirstName.SendKeys("Jade");
        }
        //LastName Text Field
        public void Last_Name()
        {
            IWebElement LastName = driver.FindElement(LastName_loc);
            LastName.SendKeys("kone");
        }
        public void Email_TextField()
        {
            IWebElement email = driver.FindElement(email_loc);
            email.SendKeys("jadekone@xyz.com");
        }
        //Company Text Field
        public void company_txtfield()
        {
            IWebElement company = driver.FindElement(company_loc);
            company.SendKeys("xyz.com");
        }
        //Industry Drop down
        public void Industry_Drpdn()
        {
            IWebElement industry = driver.FindElement(industry_loc);
            SelectElement industrys = new SelectElement(industry);
            industrys.SelectByText("Asset and Investment Management");
        }

        //Click on Submit Button
        public void Submit_form_btn()
        {
            IWebElement submit_form = driver.FindElement(submit_form_loc);
            submit_form.Submit();
        }
    }
}
