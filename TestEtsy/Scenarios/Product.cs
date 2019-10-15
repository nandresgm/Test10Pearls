using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestEtsy.Pages;

namespace TestEtsy.Scenarios
{
    public class Product
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
        /// Point 6, Create an automated script to add a product to cart and validate that the product
        /// is in the cart
        /// </summary>
        [Test]
        public void addProducto()
        {
            string title = Actions.AddProductToCart();
            Cart pageCart = new Cart();
            Assert.IsTrue(pageCart.checkProduct(title));
        }

        /// <summary>
        /// This method end the execution of driver
        /// </summary>
        [TearDown]
        public void end()
        {
            Driver.webDriver.Quit();
        }
    }
}
