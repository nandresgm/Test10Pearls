using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestEtsy.Pages
{
    /// <summary>
    /// This class map the elements of modal login
    /// </summary>
    public class LoginGoogle
    {
        #region Constructor
        public LoginGoogle()
        {
            PageFactory.InitElements(Driver.webDriver, this);
        }
        #endregion

        #region Find of elements
        [FindsBy(How = How.Id, Using = "identifierId")]
        public IWebElement txtEmail;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div/span/span")]
        public IWebElement btnNext;
        #endregion

    }
}
