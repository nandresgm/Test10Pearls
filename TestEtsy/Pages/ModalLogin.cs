using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestEtsy.Pages
{
    public class ModalLogin
    {
        #region Constructor
        public ModalLogin()
        {
            PageFactory.InitElements(Driver.webDriver, this);
        }
        #endregion

        #region Find of elements
        [FindsBy(How = How.Id, Using = "join_neu_email_field")]
        public IWebElement txtEmail { get; set; }

        [FindsBy(How = How.Id, Using = "join_neu_password_field")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[8]/div/div[2]/div/div/div/div/div/div/div[2]/form/div[1]/div/div[5]/div/button")]
        public IWebElement btnBeginSesion { get; set; }

        [FindsBy(How = How.Id, Using = "aria-join_neu_email_field-error")]
        public IWebElement lblErrorEmail { get; set; }

        [FindsBy(How = How.Id, Using = "aria-join_neu_password_field-error")]
        public IWebElement lblErrorPassword { get; set; }
        #endregion

        #region Variables
        public string result;
        #endregion

        #region Methods
        /// <summary>
        /// Set the variable result if is display some error message
        /// </summary>
        public void SaveResult()
        {
            if (lblErrorPassword.Displayed)
            {
                result = lblErrorPassword.Text;
            }
            else
            {
                result = lblErrorEmail.Text;
            }
        }
        #endregion

    }
}
