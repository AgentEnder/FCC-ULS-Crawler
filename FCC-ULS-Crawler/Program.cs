using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FCC_ULS_Crawler
{
    class Program
    {
        const string baseUrl = "https://wireless2.fcc.gov/UlsApp/UlsSearch/";
        const string licenseSearchURL = "searchLicense.jsp";
        const string FRN = "0016251530";
        static IWebDriver driver;
        static void Main(string[] args)
        {
            // Setup chrome driver + navigate to ULS License Search
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseUrl + licenseSearchURL);

            // Select search by FRN, enter FRN and click search.
            driver.FindElement(By.CssSelector(SearchPageConstants.searchBySelectCSS)).Click();
            driver.FindElement(By.CssSelector(SearchPageConstants.searchByFrnCSS)).Click();
            var searchField = driver.FindElement(By.CssSelector(SearchPageConstants.searchByValueCSS));
            searchField.Click();
            searchField.SendKeys(FRN);
            driver.FindElement(By.CssSelector(SearchPageConstants.searchBtnCSS)).Click();

            // Get links to each license for given FRN, and iterate through them.
            var licenseLinks = GetLicenseLinks();
            Console.WriteLine($"{licenseLinks.Count()} licenses found!");
            foreach (var licenseLink in licenseLinks)
            {
                driver.Navigate().GoToUrl(licenseLink);
                Console.WriteLine(driver.Url);
            }

            driver.Close();
            driver.Quit();
            driver.Dispose();
        }

        static List<string> GetLicenseLinks()
        {
            var licenseLinks = driver.FindElements(By.CssSelector(SearchResultsConstants.licenseLinkCSS)).Select(x => x.GetAttribute("href")).ToList();
            while (true)
            {
                IWebElement nextButton;
                try
                {
                    nextButton = driver.FindElement(By.CssSelector(SearchResultsConstants.nextBtnCSS));
                }
                catch (NoSuchElementException)
                {
                    break;
                }
                nextButton.Click();
                licenseLinks.AddRange(
                    driver.FindElements(By.CssSelector(SearchResultsConstants.licenseLinkCSS)).Select(x => x.GetAttribute("href")).ToList()
                );
            }
            return licenseLinks;
        }
    }
}
