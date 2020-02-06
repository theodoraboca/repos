using System;
using System.Collections.Generic;
using System.Text;

namespace Automation
{
    public static class Constants
    {
        public static string Url = "http://automationpractice.com/index.php";
        public static string DressesClassButton = "sf-with-ul";
        public static string DressesXpathButton = "//a[@title='Dresses']";
        public static string SendKeysWord = "blouse";
        public static string SearchBarId = "search_query_top";
        public static string SearchBarXpath = "//input[@id='search_query_top']";
        public static string SearchButtonXpath = "//button[@class ='btn btn-default button-search']";
        public static string TShirtsButtonXpath = "//a[@title='T-shirts']";
        public static string GridId = "grid";
        public static string ListId = "list";
        public static string SortByDropdown = "selectProductSort";
        public static string SpanXpath = "//*[@id='uniform-selectProductSort']/span";
        public static string ProductListClass = "product_list";
        public static string AddToCartXPath = "//a[@title='Add to cart']";
        public static string ContinueShoppingXPath = "//span[@title='Continue shopping']";
        public static string NrOfProdMessageXpath = "//*[@id='center_column']/h1/span[2]";
        public static string TshirtImageXpath = "//img[@title='Faded Short Sleeve T-shirts']";
    }

}