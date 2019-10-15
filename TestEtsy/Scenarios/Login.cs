using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestEtsy.Pages;
using TestEtsy.TestDataAccess;

namespace TestEtsy.Scenarios
{
    public class Login
    {
        /// <summary>
        /// Is the first method to execute, beginning the driver and select the base url
        /// </summary>
        [SetUp]
        public void Begin()
        {
            Actions.BeginDriver();
        }

        /// <summary>
        /// Point 4, Login into the site with different users using a data driven framework
        /// the assertions must validate the sucessfull login
        /// </summary>
        [Test]
        public void doLogin()
        {
            Actions.LoginWithExcel();
        }

        /// <summary>
        /// Point 5, Create an automated script to test a failed attempt to login
        /// this test check the require fields
        /// </summary>
        [Test]
        public void LoginFields()
        {
            ModalLogin pageModalLogin = new ModalLogin();
            Actions.RequireFieldsLogin();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(Settings.ErrorMessages.emptyField, pageModalLogin.lblErrorPassword.Text);
                Assert.AreEqual(Settings.ErrorMessages.emptyField, pageModalLogin.lblErrorEmail.Text);
            });
            
        }

        /// <summary>
        /// Point 5, Create an automated script to test a failed attempt to login
        /// this test check the email when isn't registered
        /// </summary>
        [Test]
        public void InvalidEmail()
        {
            ModalLogin pageModalLogin = new ModalLogin();
            Actions.CheckEmail();
            Assert.AreEqual(Settings.ErrorMessages.invalidEmail,pageModalLogin.lblErrorEmail.Text);
        }

        /// <summary>
        /// Point 5, Create an automated script to test a failed attempt to login
        /// this test check when the password is incorrect
        /// </summary>
        [Test]
        public void InvalidPassword()
        {
            ModalLogin pageModalLogin = new ModalLogin();
            Actions.CheckPassword();
            Assert.AreEqual(Settings.ErrorMessages.invalidPassword, pageModalLogin.lblErrorPassword.Text);
        }

        /// <summary>
        /// This method end the execution of driver
        /// </summary>
        [TearDown]
        public void End()
        {
            Driver.webDriver.Quit();
        }
    }
}
