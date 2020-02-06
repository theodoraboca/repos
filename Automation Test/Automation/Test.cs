using Automation;
using FluentAssertions;
using Microsoft.Build.BuildEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;


namespace Automation_Test
{
    [TestClass]
    public class Tests
    {
        public ChromeDriver driver { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver()
            {
                Url = Constants.Url
            };

            driver.Navigate();

                   }

    [TestCleanup]
        public void TestCleanup()
        {
            Thread.Sleep(3000);
            driver.Close();
        }


        [TestMethod]
        public void SampleTest()
        {

            // Step1: Open Dresses tab

            var dresses = driver.FindElementsByXPath(Constants.DressesXpathButton);
            var dress = dresses.Where(d => d.Displayed == true).FirstOrDefault();

            dress.Click();
            Thread.Sleep(3000);


            //Step 2: Check if the URL has changed

            driver.Url.Should().NotBe(Constants.Url);
        }


        [TestMethod]
        public void SearchUsingSearchBar()
        {
            // Step1: "Search Blouse" items

            var searchBar = driver.FindElementById(Constants.SearchBarId);
            var searchButton = driver.FindElementByXPath(Constants.SearchButtonXpath);

            searchBar.SendKeys(Constants.SendKeysWord);
            searchButton.Submit();

        }

        [TestMethod]
        public void CheckIfElementIsClickedOn()
        {
            // Step 1:  Open T-Shirts tab.

            var tShirts = driver.FindElementsByXPath(Constants.TShirtsButtonXpath);
            var tShirt = tShirts.Where(t => t.Displayed == true).FirstOrDefault();
            tShirt.Click();

            // Step 2: Switch to Grid view instead of List
            var grid = driver.FindElementById(Constants.GridId);
            grid.Click();

            // Step 3: Check if "Grid" view is selected
            var selectedClass = grid.GetAttribute("class");
            Assert.IsTrue(selectedClass == "selected");

        }


        [TestMethod]
        public void SelectValueFromDrowpdown()
        {

            // Step 1: Open Dresses tab
            var dresses = driver.FindElementsByXPath(Constants.DressesXpathButton);
            var dress = dresses.Where(d => d.Displayed == true).FirstOrDefault();
            dress.Click();
            Thread.Sleep(2000);

            // Step 2: Click on "Sort by" dropdown
            var sort = driver.FindElementById(Constants.SortByDropdown);
            sort.Click();

            // Step 3: select "Price: Highest First" option
            SelectElement select = new SelectElement(sort);
            select.SelectByIndex(2);

            // Step 4: Check if the selected option is  "Price: Highest First"

            var span = driver.FindElementByXPath(Constants.SpanXpath);
            var selectedOption = span.Text;
            Assert.IsTrue(selectedOption == "Price: Highest first");
        }

               [TestMethod]
        public void CountElements()
        {
            // Step 1: Click on T-shirts tab
            
            var tShirts = driver.FindElementsByXPath(Constants.TShirtsButtonXpath);
            var tShirt = tShirts.Where(t => t.Displayed).FirstOrDefault();
            tShirt.Click();

            // Step 2: Count elements from list
            var productList = driver.FindElementsByClassName(Constants.ProductListClass);
            var numberOfTshirts = productList.Count();

            // Step 3: Check if the number of products is 1
            Assert.IsTrue(numberOfTshirts == 1);
        }  
 
        [TestMethod]
        public void AddToCartOnListMode()
        {
            // Step 1: Click on T-shirts tab

            var tShirts = driver.FindElementsByXPath(Constants.TShirtsButtonXpath);
            var tShirt = tShirts.Where(t => t.Displayed).FirstOrDefault();
            tShirt.Click();

            // Step 2: Switch to List mode
            var list = driver.FindElementById(Constants.ListId);
            list.Click();

            // Step 3: Add to cart the only element from the page
            var addToCartButton = driver.FindElementByXPath(Constants.AddToCartXPath);
            addToCartButton.Click();

            // Step 4: Click on "Continue Shopping" button
            var continueShoppingButton = driver.FindElementByXPath(Constants.ContinueShoppingXPath);
            continueShoppingButton.Click();

            //Step 5: Check if the message on the right is saying that you only have 1 product in the list.
            var cartMessage = driver.FindElementByXPath(Constants.NrOfProdMessageXpath);
            var messageText = cartMessage.Text;
            Assert.IsTrue( messageText == "There is 1 product.");
        }

        [TestMethod]
        public void AddToCartOnGridMode()
        {
            // Step 1: Click on T-shirts tab

            var tShirts = driver.FindElementsByXPath(Constants.TShirtsButtonXpath);
            var tShirt = tShirts.Where(t => t.Displayed).FirstOrDefault();
            tShirt.Click();

            // Step 2: Add to cart the only element from the page by hovering over element
            Actions builder = new Actions(driver);
            var tshirtImage = driver.FindElementByXPath(Constants.TshirtImageXpath);  
            var addToCartButton = driver.FindElementByXPath(Constants.AddToCartXPath);
            builder.MoveToElement(tshirtImage).Build().Perform();
            addToCartButton.Click();

            // Step 3: Click on "Continue Shopping" button
            var continueShoppingButton = driver.FindElementByXPath(Constants.ContinueShoppingXPath);
            continueShoppingButton.Click();
        }
    }

    }

