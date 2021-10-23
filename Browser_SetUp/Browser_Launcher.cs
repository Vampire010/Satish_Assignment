using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satish_Assignment.Browser_SetUp
{
    class Browser_Launcher
    {
        public static IWebDriver driver { get; set; }

        public static void StartBrowser(string BrowserType, string url)
        {
            if (BrowserType.Equals("Chrome"))
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(url);
            }

            else if (BrowserType.Equals("Firefox"))
            {
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl(url);
            }
        }

    }
}
