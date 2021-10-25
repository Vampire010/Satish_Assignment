using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Satish_Assignment.Browser_SetUp;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.IO;
using System.Threading;

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
            IWebElement resrsedrp = Browser_Launcher.driver.FindElement(Resourse_drpdn_loc);
            Actions act = new Actions(Browser_Launcher.driver);
            act.MoveToElement(resrsedrp).Perform();

            Browser_Launcher.driver.FindElement(White_Papers_eBooks_loc).Click();
            try
            {
                //Tittle Verification
                string Given_Titl = "White Papers | Kurtosys";
                string PageTitle = Browser_Launcher.driver.Title;
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
            Browser_Launcher.driver.FindElement(Click_Any_White_Papers_eBooks1_loc).Click();
            Browser_Launcher.driver.FindElement(Click_Any_White_Papers_eBooks2_loc).Click();
        }

        public void iframe_Form()
        {
            IWebElement iframe_Form = Browser_Launcher.driver.FindElement(iframe_Form_loc);
            Browser_Launcher.driver.SwitchTo().Frame(iframe_Form);
        }


        //FirstName Text Field
        public void Frst_Name(string Fst_name)
        {
            IWebElement FirstName = Browser_Launcher.driver.FindElement(FirstName_loc);
            FirstName.SendKeys(Fst_name);
            Submit_form_btn();

            string fst_val = FirstName.GetAttribute("value");
            if (Fst_name.Equals(fst_val))
            {
                Assert.That(Fst_name, Is.EqualTo(fst_val));
            }
            else
            {
                takescreenshots("first_name_Error.png");
            }

        }
        //LastName Text Field
        public void Last_Name(string lst_name)
        {
            IWebElement LastName = Browser_Launcher.driver.FindElement(LastName_loc);
            LastName.SendKeys(lst_name);
            Submit_form_btn();
            string lst_val = LastName.GetAttribute("value");
            if (lst_name.Equals(lst_val))
            {
                Console.WriteLine(lst_val);
            }
            else
            {
                takescreenshots("Last_name_Error.png");
                Assert.That(lst_name, Is.EqualTo(lst_val));

            }

        }
        public void Email_TextField(string email)
        {
            IWebElement email_inp = Browser_Launcher.driver.FindElement(email_loc);
            email_inp.SendKeys(email);

            Submit_form_btn();

            IWebElement field_req = Browser_Launcher.driver.FindElement(By.Id("error_for_18882_241310pi_18882_241310"));
            Boolean eml_val = field_req.Displayed;
            Boolean status = true;
            if (eml_val.Equals(status))
            {
                Console.WriteLine(eml_val);
            }
            else
            {
                Thread.Sleep(2000);
                takescreenshots("Email_Error.png");
                Assert.That(status, Is.EqualTo(eml_val));

            }
        }
        //Company Text Field
        public void company_txtfield(string company_name)
        {
            IWebElement company = Browser_Launcher.driver.FindElement(company_loc);
            company.SendKeys(company_name);

            Submit_form_btn();
            string compny_val = company.GetAttribute("value");
            if (company_name.Equals(compny_val))
            {
                Console.WriteLine("compny_val");
            }
            else
            {
                takescreenshots("company_name_Error.png");
                Assert.That(company_name, Is.EqualTo(compny_val));

            }
        }
        //Industry Drop down
        public void Industry_Drpdn()
        {
            IWebElement industry = Browser_Launcher.driver.FindElement(industry_loc);
            SelectElement industrys = new SelectElement(industry);
            industrys.SelectByText("Asset and Investment Management");
        }

        //Click on Submit Button
        public void Submit_form_btn()
        {
            IWebElement submit_form = Browser_Launcher.driver.FindElement(submit_form_loc);
            submit_form.Submit();
        }


        public void takescreenshots(string errname)
        {
            ITakesScreenshot ts = Browser_Launcher.driver as ITakesScreenshot;
            Screenshot screenshot = ts.GetScreenshot();

            screenshot.SaveAsFile(@"C:\Users\archana\source\repos\Satish_Assignment\ScreenShot_Repo\"+ errname);
        }
    }
}
