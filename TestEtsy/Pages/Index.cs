using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestEtsy.Pages
{
    public class Index
    {
        /// <summary>
        /// This class map the index page with their elements
        /// </summary>

        #region Constructor
        public Index()
        {
            PageFactory.InitElements(Driver.webDriver, this);
        }
        #endregion

        #region Find of elements
        [FindsBy(How = How.Id, Using = "register")]
        public IWebElement linkRegister { get; set; }

        [FindsBy(How = How.Id, Using = "sign-in")]
        public IWebElement btnSignIn { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/header/div[4]/ul/li[4]/a/span[1]")]
        public IWebElement btnAccount { get; set; }

        [FindsBy(How = How.ClassName, Using = "top-divider")]
        public IWebElement opcSignOut { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/div[3]/div/div[2]/div/ul/li[1]/a")]
        public IWebElement lnkProduct { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Check that button account is present for validate if the sesesion if began
        /// </summary>
        /// <returns>True if sesion began</returns>
        public bool CheckSesion()
        {
            try
            {
                if (btnAccount.Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
        #endregion


    }

}
