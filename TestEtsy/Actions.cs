using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Threading;
using TestEtsy.Pages;
using TestEtsy.TestDataAccess;

namespace TestEtsy
{
    public static class Actions
    {
        #region Actions settings of driver
        public static void BeginDriver()
        {
            Driver.webDriver = new FirefoxDriver();
            Driver.ImplicitWait();
            Driver.webDriver.Navigate().GoToUrl(Settings.URL);
        }

        public static void UpdateDriver()
        {
            foreach (string handle in Driver.webDriver.WindowHandles)
            {
                Driver.webDriver.SwitchTo().Window(handle);
            }
        }
        #endregion

        #region Actions account
        public static void Register()
        {
            NavigateTo.Register();
            ModalAccount pageModalAccount = new ModalAccount();
            Index pageIndex = new Index();
            pageModalAccount.txtEmail.SendKeys(Settings.AccountRegister.email);
            pageModalAccount.txtName.SendKeys(Settings.AccountRegister.nombre);
            pageModalAccount.txtPassword.SendKeys(Settings.AccountRegister.password);
            pageModalAccount.btnRegister.Click();
            Thread.Sleep(2000);
        }

        public static void RequireFieldsAccount()
        {
            NavigateTo.Register();
            ModalAccount pageModalAccount = new ModalAccount();
            pageModalAccount.btnRegister.Click();
        }

        public static void RegisterWithGmail()
        {
            NavigateTo.Register();
            ModalAccount pageModalAccount = new ModalAccount();
            LoginGoogle pageLoginGoogle = new LoginGoogle();
            Index pageIndex = new Index();
            Thread.Sleep(3000);
            pageModalAccount.btnGoogle.Click();
            Actions.UpdateDriver();
            pageLoginGoogle.txtEmail.SendKeys(Settings.GmailAccount.email);
            pageLoginGoogle.btnNext.Click();
            Thread.Sleep(3000);
            pageLoginGoogle.txtPassword.SendKeys(Settings.GmailAccount.password);
            pageLoginGoogle.btnNext.Click();
            Thread.Sleep(3000);
        }
        #endregion

        #region Actions in the login
        public static void LoginWithExcel()
        {
            NavigateTo.Login();
            List<UserData> users = new List<UserData>();
            users = ReadData();
            ModalLogin pageModalLogin = new ModalLogin();
            Index pageIndex = new Index();
            foreach (UserData user in users)
            {
                Thread.Sleep(3000);
                pageModalLogin.txtEmail.SendKeys(user.Email);
                pageModalLogin.txtPassword.SendKeys(user.Password);
                pageModalLogin.btnBeginSesion.Click();
                Thread.Sleep(3000);
                Actions.UpdateDriver();
                if (pageIndex.CheckSesion())
                {
                    pageIndex.btnAccount.Click();
                    Thread.Sleep(2000);
                    pageIndex.opcSignOut.Click();
                    NavigateTo.Login();
                }
                else
                {
                    pageModalLogin.SaveResult();
                    WriteResult(user, pageModalLogin.result);
                    pageModalLogin.txtEmail.Clear();
                    pageModalLogin.txtPassword.Clear();
                }
            }
        }

        public static void RequireFieldsLogin()
        {
            NavigateTo.Login();
            ModalLogin pageModalLogin = new ModalLogin();
            pageModalLogin.txtEmail.SendKeys(Settings.InvalidCredentials.withoutEmail);
            pageModalLogin.txtPassword.SendKeys(Settings.InvalidCredentials.withoutEmail);
            pageModalLogin.btnBeginSesion.Click();
        }

        public static void CheckEmail()
        {
            NavigateTo.Login();
            ModalLogin pageModalLogin = new ModalLogin();
            pageModalLogin.txtEmail.SendKeys(Settings.InvalidCredentials.invalidEmail);
            pageModalLogin.txtPassword.SendKeys(Settings.InvalidCredentials.invalidPassword);
            pageModalLogin.btnBeginSesion.Click();
        }

        public static void CheckPassword()
        {
            NavigateTo.Login();
            ModalLogin pageModalLogin = new ModalLogin();
            pageModalLogin.txtEmail.SendKeys(Settings.ValidCrentials.email);
            pageModalLogin.txtPassword.SendKeys(Settings.InvalidCredentials.invalidPassword);
            pageModalLogin.btnBeginSesion.Click();
            Thread.Sleep(1000);
        }

        public static List<UserData> ReadData()
        {
            return ExcelDataAccess.GetUsers();
        }

        public static void WriteResult(UserData data, string error)
        {
            ExcelDataAccess.CreateTxt(data, error);
        }
        #endregion

        #region Actions product
        public static string AddProductToCart()
        {
            Index pageIndex = new Index();
            Listing pageListing = new Listing();
            string title;
            pageIndex.lnkProduct.Click();
            Thread.Sleep(5000);
            Actions.UpdateDriver();
            title = pageListing.lblTitle.Text;
            pageListing.btnAddCar.Click();
            return title;
        }
        #endregion
    }
}
