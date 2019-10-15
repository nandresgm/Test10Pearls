using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEtsy.Pages
{
    /// <summary>
    /// This class map the elements that will be add to cart
    /// </summary>
    public class Listing
    {
        #region Constructor
        public Listing()
        {
            PageFactory.InitElements(Driver.webDriver, this);
        }
        #endregion

        #region Find of elements
        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/div[1]/div[1]/div/div[2]/div/div[1]/div[5]/div/form/button")]
        public IWebElement btnAddCar { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/div[1]/div[1]/div/div[2]/div/div[1]/div[2]/h1")]
        public IWebElement lblTitle { get; set; }
        #endregion
    }
}
