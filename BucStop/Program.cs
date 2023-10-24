using System.Web.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Games",
    pattern: "Games/{action}/{id?}",
    defaults: new { controller = "Games", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



// Start of Test -------------------------------------------------------------

IWebDriver driver = new ChromeDriver();

driver.Navigate().GoToUrl("https://bucstop.mjustis.com/");

// Test name: Bucstsop test 01
// Step # | name | target | value
// 1 | open | https://bucstop.mjustis.com/ | 
driver.Navigate().GoToUrl("https://bucstop.mjustis.com/");
// 2 | setWindowSize | 1552x840 | 
driver.Manage().Window.Size = new System.Drawing.Size(1552, 840);
// 3 | click | css=img | 
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
// 13 | click | css=.nav-item > .active | 
//driver.FindElement(By.CssSelector(".nav-item > .active")).Click();
// 14 | click | css=.active:nth-child(1) | 
//driver.FindElement(By.CssSelector(".active:nth-child(1)")).Click();
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

driver.Quit();

// End of Test -------------------------------------------------------------

app.Run();
