using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace AutoCalculator
{
        public abstract class BaseSelenium
        {

            public static IWebDriver Instance;
            //public string Url { get; set; }

            public BaseSelenium()
            {
                //FirefoxOptions options = new FirefoxOptions();
                //options.AddArguments("test-type");
                //options.AddArguments("--start-maximized");
                //Instance = new FirefoxDriver(@"C:\Users\sergeys\source\repos\AutoCalculator\AutoCalculator\bin\Debug\netcoreapp2.1");

                ChromeOptions options = new ChromeOptions();
                options.AddArguments("test-type");
                options.AddArguments("--start-maximized");
                options.AddArgument("incognito");
                Instance = new ChromeDriver(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "")), options);
            }

            public enum Identifier
            {
                Id,
                Xpath,
                Css
            };

            public void NavigateURL(string Url)
            {
                Instance.Navigate().GoToUrl(Url);
            }

            public static void Click(By by)
            {
                IWebElement elem = FindElement(by);
                elem.Click();
            }

            public static By FindIdentifierByTxt(string name) => By.XPath($"//*[contains(text(),'{name}')]");

            public static void SendKeys(By by, string txt)
            {
                IWebElement elem = FindElement(by);
                elem.SendKeys(txt);
            }

            public static List<string> GetResults(By by)
            {
                IWebElement elem = FindElement(by);
                var listli = elem.FindElements(By.TagName("li"));
                List<string> res = new List<string>();
                res =  listli[0].Text.Split("\r\n").ToList();

                return res;
            }

            public static int GetItemsCount(By by)
            {
                IWebElement elem = FindElement(by);
                var listli = elem.FindElements(By.TagName("li"));

                return listli.Count;
            }

            public static string GetInputValue(By by)
            {
                Thread.Sleep(1000);
                IWebElement elem = FindElement(by);
                IJavaScriptExecutor jse = (IJavaScriptExecutor)Instance;
                string text = (string)jse.ExecuteScript("return document.getElementById('input').value");
                return text;
            }
            public static IWebElement FindElement(By by, int timeoutInSeconds = 5)
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until(drv => drv.FindElement(by));
                }
                return Instance.FindElement(by);
            }

            public static bool WaitUntilElementIsPresent(By by, int timeout = 5)
            {
                for (var i = 0; i < timeout; i++)
                {
                    if (Instance.FindElement(by).Displayed)
                        return true;
                }
                return false;
            }

            public static void ClosePopUpAlert()
            {
                for (int cont = 10; cont > 0; cont--)
                {
                    try
                    {
                        IAlert alert = Instance.SwitchTo().Alert();
                        alert.Accept();
                    }
                    catch (NoAlertPresentException)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(0.5));
                    }
                }
            }

        ~BaseSelenium()
            {
                Instance.Close();
            }


        }
}
