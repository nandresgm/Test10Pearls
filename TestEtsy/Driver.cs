using OpenQA.Selenium;
using System;

namespace TestEtsy
{
    public static class Driver
    {
        public static IWebDriver webDriver { get; set; }

        public static void ImplicitWait(int seconds = 5)
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
    }
}
