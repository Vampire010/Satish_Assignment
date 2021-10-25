using NUnit.Framework;
using OpenQA.Selenium;
using Satish_Assignment.Browser_SetUp;
using Satish_Assignment.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Satish_Assignment.TestRunner
{
    class Global_Test 
    {
        public static string url = "https://www.kurtosys.com/";
        public static string browser_type = "chrome";
   

       [Test]
        public static void Test_01()
        {
            Kurto_SysTest_1 krt = new Kurto_SysTest_1(Browser_Launcher.driver);

            Kurto_SysTest_1.StartBrowser(browser_type , url);
            krt.Resourse_drpdn();
            krt.Click_Any_White_Papers_eBooks1();
            krt.iframe_Form();
            krt.Frst_Name("");
            krt.Last_Name("key");
            krt.Email_TextField("joe@");
            krt.company_txtfield("");
            krt.Industry_Drpdn();
        //    krt.Submit_form_btn();
        }

    }
}
