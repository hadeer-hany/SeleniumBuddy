using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace SeleniumTestBuddy
{
    
    public class Tests
    {
        public IWebDriver driver;
        [SetUp]
        public void Setup()
        {
             driver = new ChromeDriver(Path.GetFullPath(@"C:\chromedriver_win32"));
            driver.Navigate().GoToUrl("https://stackoverflow.com/");

        }

        [Test]
        public void Test1()
        {
            //Creating Chrome driver instance:
          

            // Use the VerticalCombineDecorator to capture entire page:
            var vcs = new VerticalCombineDecorator(new ScreenshotMaker());
            var screen = driver.TakeScreenshot(vcs);


            //Coverting a byte array to an image:
            using (Image image = Image.FromStream(new MemoryStream(screen)))
            {
                var a = image.Size;
                image.Save("SeleniumScreenShot.png", ImageFormat.Jpeg);  // Or Png
            }


            //Close Chrome instance:
            driver.Close();
            Assert.Pass();
        }
    }
}