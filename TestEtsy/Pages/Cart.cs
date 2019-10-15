using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace TestEtsy.Pages
{
    /// <summary>
    /// This class map the cart page with their elements
    /// </summary>
    public class Cart
    {
        #region Constructor
        public Cart()
        {
            PageFactory.InitElements(Driver.webDriver, this);
        }
        #endregion

        #region Find of elements
        [FindsBy(How = How.Id, Using = "multi-shop-cart-list")]
        public IWebElement products { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// Check that producto is in the cart
        /// </summary>
        /// <param name="product"></param>
        /// <returns>True if the product is in the cart</returns>
        public bool checkProduct(string product)
        {
            List<IWebElement> lstProducts = new List<IWebElement>();
            lstProducts = products.FindElements(By.TagName("a")).ToList();
            foreach (IWebElement item in lstProducts)
            {
                if (item.Text.Equals(product))
                {
                    return true;
                }
            }
            return false;

        }
        #endregion
        
    }
}
