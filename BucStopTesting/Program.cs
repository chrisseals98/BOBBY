using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System;
using OpenQA.Selenium.Edge;

namespace BucStopTesting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string errorLogDirectory = Path.Combine(baseDirectory, "ErrorLogs");
            string logFileName = "log.txt";
            string logFilePath = Path.Combine(errorLogDirectory, logFileName);

            IWebDriver driver = new ChromeDriver();

            Console.WriteLine($"Filepath is {logFilePath}.");

            try
            {
                // Test name: Bucstsop test 01
                // Step # | name | target | value
                // 1 | open | https://bucstop.mjustis.com/ | 
                driver.Navigate().GoToUrl("https://bucstop.mjustis.com/");
                // 2 | setWindowSize | 1552x840 | 
                driver.Manage().Window.Size = new System.Drawing.Size(1552, 840);
                // 3 | click | css=img | 
                driver.FindElement(By.CssSelector("img")).Click();
                driver.FindElement(By.CssSelector("img")).Click();
                // 4 | click | linkText=Home | 
                driver.FindElement(By.LinkText("Home")).Click();
                // 5 | click | linkText=Games | 
                driver.FindElement(By.LinkText("Games")).Click();
                // 6 | click | css=.game-item:nth-child(1) .game-thumbnail | 
                driver.FindElement(By.CssSelector(".game-item:nth-child(1) .game-thumbnail")).Click();
                // 7 | click | css=.nav-item > .active | 
                driver.FindElement(By.CssSelector(".nav-item > .active")).Click();
                // 8 | click | css=.active:nth-child(1) | 
                driver.FindElement(By.CssSelector(".active:nth-child(1)")).Click();
                // 9 | click | linkText=Home | 
                driver.FindElement(By.LinkText("Home")).Click();
                // 10 | click | linkText=Games | 
                driver.FindElement(By.LinkText("Games")).Click();
                // 11 | click | css=.game-item:nth-child(2) .game-thumbnail | 
                driver.FindElement(By.CssSelector(".game-item:nth-child(2) .game-thumbnail")).Click();
                // 12 | click | id=game | 
                driver.FindElement(By.Id("game")).Click();
                // 15 | click | linkText=Games | 
                driver.FindElement(By.LinkText("Games")).Click();
                // 16 | click | css=.game-item:nth-child(3) .game-thumbnail | 
                driver.FindElement(By.CssSelector(".game-item:nth-child(3) .game-thumbnail")).Click();
                // 17 | click | css=.nav-item > .active | 
                driver.FindElement(By.CssSelector(".nav-item > .active")).Click();
                // 18 | click | css=.active:nth-child(1) | 
                driver.FindElement(By.CssSelector(".active:nth-child(1)")).Click();
                // 19 | click | linkText=Games | 
                driver.FindElement(By.LinkText("Games")).Click();
                // 20 | click | linkText=Privacy | 
                driver.FindElement(By.LinkText("Privacy")).Click();
                // 21 | click | linkText=Admin | 
                driver.FindElement(By.LinkText("Admin")).Click();
                // 22 | click | linkText=Home | 
                driver.FindElement(By.LinkText("Home")).Click();
                // 23 | click | css=img | 
                driver.FindElement(By.CssSelector("img")).Click();

                // fake finds
                driver.FindElement(By.CssSelector("fakeCSS")).Click();
            }
            catch (NoSuchElementException ex1)
            {
                LogException(ex1, logFilePath);
                Console.WriteLine("Could not find specific element.");
            }
            catch(Exception ex)
            {
                LogException(ex, logFilePath);
                Console.WriteLine("Could not find general element.");
            }

            driver.Quit();
        }

        static void LogException(Exception ex, string logFilePath)
        {
            using (StreamWriter sw = new StreamWriter(logFilePath, true))
            {
                sw.WriteLine("  ===== Error Message =====  ");
                sw.WriteLine(DateTime.Now + ": " + ex.Message);
                sw.WriteLine();
            }
        }


    }
}