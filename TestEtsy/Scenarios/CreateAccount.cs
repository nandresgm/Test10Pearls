using NUnit.Framework;
using System.Threading;
using TestEtsy.Pages;

namespace TestEtsy.Scenarios
{
    public class CreateAccount
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
        /// Point 1, Create an account into the site
        /// </summary>
        [Test]
        public void Register()
        {
            Index pageIndex = new Index();
            Actions.Register();
            Assert.IsTrue(pageIndex.CheckSesion());
        }

        /// <summary>
        /// Point 2, Create an automate script to test the require fields
        /// </summary>
        [Test]
        public void TestFields()
        {
            ModalAccount pageModalAccount = new ModalAccount();
            Actions.RequireFieldsAccount();
            Assert.IsTrue(!pageModalAccount.ValidarCampos());
        }


        /// <summary>
        /// Point 3, Create an account into the site using gmail option
        /// </summary>
        [Test]
        public void RegisterWithGmail()
        {
            Index pageIndex = new Index();
            Actions.RegisterWithGmail();
            Assert.IsTrue(pageIndex.CheckSesion());
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
