using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestEtsy.Pages
{
    /// <summary>
    /// This class map the elements of modal in that create a account
    /// </summary>
    public class ModalAccount
    {
        #region Constructor
        public ModalAccount()
        {
            PageFactory.InitElements(Driver.webDriver, this);
        }
        #endregion

        #region Find of elements
        [FindsBy(How = How.Id, Using = "join_neu_email_field")]
        public IWebElement txtEmail;

        [FindsBy(How = How.Id, Using = "join_neu_first_name_field")]
        public IWebElement txtName;

        [FindsBy(How = How.Id, Using = "join_neu_password_field")]
        public IWebElement txtPassword;

        [FindsBy(How = How.Name, Using = "submit_attempt")]
        public IWebElement btnRegister;

        [FindsBy(How = How.XPath, Using = "/html/body/div[8]/div/div[2]/div/div/div/div/div/div/div[2]/form/div[3]/div/div[1]/div/button")]
        public IWebElement btnGoogle;

        [FindsBy(How = How.Id, Using = "aria-join_neu_email_field-error")]
        public IWebElement lblErrorEmail;

        [FindsBy(How = How.Id, Using = "aria-join_neu_first_name_field-error")]
        public IWebElement lblErrorName;

        [FindsBy(How = How.Id, Using = "aria-join_neu_password_field-error")]
        public IWebElement lblErrorPassword;
        #endregion

        #region Methods
        /// <summary>
        /// Check that fields were fill
        /// </summary>
        /// <returns></returns>
        public bool ValidarCampos()
        {
            if (lblErrorEmail.Displayed && lblErrorName.Displayed && lblErrorPassword.Displayed)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion


    }
}
