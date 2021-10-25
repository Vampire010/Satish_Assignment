using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Satish_Assignment.Browser_SetUp
{
   public class Browser_Launcher
    {
        public static IWebDriver driver;

        public static void StartBrowser(string BrowserType, string url)
        {
            if (BrowserType.Equals("chrome"))
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();
                Thread.Sleep(2000);

            }

            else if (BrowserType.Equals("Firefox"))
            {
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();
                Thread.Sleep(2000);

            }
        }

    }
}
