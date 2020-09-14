using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCC_ULS_Crawler
{
    class Program
    {
        const string baseUrl = "https://wireless2.fcc.gov/UlsApp/UlsSearch/";
        const string licenseSearchURL = "searchLicense.jsp";
        const string FRN = "0016251530";
        const bool Testing = true;

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
                GetLocationDetails();
            }

            driver.Close();
            driver.Quit();
            driver.Dispose();
        }

        static List<string> GetLicenseLinks()
        {
            var licenseLinks = driver.FindElements(By.CssSelector(SearchResultsConstants.licenseLinkCSS)).Select(x => x.GetAttribute("href")).ToList();
            while (true && !Testing)
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

        static List<string> GetLocationLinks()
        {
            HashSet<string> locationLinks = driver.FindElements(By.CssSelector(LicenseResultConstants.locationLinkCSS)).Select(x => x.GetAttribute("href")).ToHashSet();
            while (true && !Testing)
            {
                IWebElement nextButton;
                try
                {
                    nextButton = driver.FindElement(By.CssSelector(LicenseResultConstants.nextBtnCSS));
                }
                catch (NoSuchElementException)
                {
                    break;
                }
                nextButton.Click();
                locationLinks.Union(
                    driver.FindElements(By.CssSelector(LicenseResultConstants.locationLinkCSS)).Select(x => x.GetAttribute("href")).ToList()
                );
            }
            return locationLinks.ToList();
        }

        static List<Location> GetLocationDetails()
        {
            driver.FindElement(By.CssSelector(LicenseResultConstants.locationsTabLinkCSS)).Click();
            List<string> locations = GetLocationLinks();
            var locationDetails = new List<Location>();
            foreach (var location in locations)
            {
                driver.Navigate().GoToUrl(location);
                var city = driver.FindElement(By.XPath(LocationDetailConstants.CityXPath)).Text;
                var county = driver.FindElement(By.XPath(LocationDetailConstants.CountyXPath)).Text;
                var ppc = String.IsNullOrWhiteSpace(city) ? county : city;
                locationDetails.Add(new Location
                {
                    AntennaAzimuth = float.Parse(driver.FindElement(By.XPath(LocationDetailConstants.AzimuthXPath)).Text.Split(" ")[0]),
                    Coordinates = Coordinates.Parse(driver.FindElement(By.XPath(LocationDetailConstants.CoordinatesXPath)).Text),
                    EIRP = float.Parse(driver.FindElement(By.XPath(LocationDetailConstants.EIRPXPath)).Text.Split(" ")[0]),
                    EquipmentManufacturer = driver.FindElement(By.XPath(LocationDetailConstants.ManufacturerXPath)).Text,
                    Name = driver.FindElement(By.XPath(LocationDetailConstants.SiteNameXPath)).Text.Split(". Site ")[1],
                    TransmitAntennaGain = float.Parse(driver.FindElement(By.XPath(LocationDetailConstants.GainXPath)).Text.Split(" ")[0]),
                    Polarity = driver.FindElement(By.XPath(LocationDetailConstants.PolarityXPath)).Text,
                    TransmissionLocation = driver.FindElement(By.XPath(LocationDetailConstants.TransmissionLocationXPath)).Text,
                    PrimaryPopulationCenter = ppc,
                    AntennaElevation = float.Parse(driver.FindElement(By.XPath(LocationDetailConstants.AntennaElevationXPath)).Text.Split(" ")[0]),
                    MechanicalBeamTilt = float.Parse(driver.FindElement(By.XPath(LocationDetailConstants.ElevationAngleXPath)).Text.Split(" ")[0]),
                    RecordLink = new Uri(driver.Url),
                    WirelessSpectrum = driver.FindElement(By.XPath(LocationDetailConstants.SpectrumXPath)).Text
                });
            }

            return locationDetails;
        }
    }
}
