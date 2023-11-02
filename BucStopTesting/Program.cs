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
            // Finds the current directory and adds folder and log file to filepath
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string errorLogDirectory = Path.Combine(baseDirectory, "ErrorLogs");

            // Check if the 'ErrorLogs' directory exists, and if not, create it
            if (!Directory.Exists(errorLogDirectory))
            {
                Directory.CreateDirectory(errorLogDirectory);
            }

            string logFileName = "log.txt";
            string logFilePath = Path.Combine(errorLogDirectory, logFileName);

            // We can add more drivers as need be
            IWebDriver driver = new ChromeDriver();

            Console.WriteLine($"Filepath is {logFilePath}.");

            try
            {
                // Test name: Bucstsop test 01
                // Step # | name | target | value
                // 1 | open | https://bucstop.mjustis.com/ | 
                driver.Navigate().GoToUrl("https://bucstop.mjustis.com/"); // Replace URL with LocalHost:PORT - for me it's "https://localhost:7182/"
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
                // 13 | click | linkText=Games | 
                driver.FindElement(By.LinkText("Games")).Click();
                // 14 | click | css=.game-item:nth-child(3) .game-thumbnail | 
                driver.FindElement(By.CssSelector(".game-item:nth-child(3) .game-thumbnail")).Click();
                // 15 | click | css=.nav-item > .active | 
                driver.FindElement(By.CssSelector(".nav-item > .active")).Click();
                // 16 | click | css=.active:nth-child(1) | 
                driver.FindElement(By.CssSelector(".active:nth-child(1)")).Click();
                // 17 | click | linkText=Games | 
                driver.FindElement(By.LinkText("Games")).Click();
                // 18 | click | linkText=Privacy | 
                driver.FindElement(By.LinkText("Privacy")).Click();
                // 19 | click | linkText=Admin | 
                driver.FindElement(By.LinkText("Admin")).Click();
                // 20 | click | linkText=Home | 
                driver.FindElement(By.LinkText("Home")).Click();
                // 21 | click | css=img | 
                driver.FindElement(By.CssSelector("img")).Click();

                // Error injection to test error logging
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

        // Adds timestamped error message to log file
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