using System;
using System.Collections.Generic;
using System.Text;

namespace FCC_ULS_Crawler
{
    class SearchPageConstants
    {
        public const string searchBySelectCSS = "select[name=\"fiUlsSearchByType\"]";
        public const string searchByFrnCSS = "option[value=\"uls_l_frn                     \"]";
        public const string searchByValueCSS = "input[name=\"fiUlsSearchByValue\"]";
        public const string searchBtnCSS = "input[alt=\"Search\"]";
    }

    class SearchResultsConstants
    {
        public const string licenseLinkCSS = "a[href*=\"license.jsp\"]";
        public const string nextBtnCSS = "a[title*=\"Next page\"]";
    }

    class LicenseResultConstants
    {
        public const string locationsTabLinkCSS = "a[title=\"Locations\"]";
        public const string locationLinkCSS = "a[href*=\"licenseLocDetail\"]";
        public const string nextBtnCSS = "a[title*=\"Next page\"]";
    }

    class LocationDetailConstants
    {
        public const string ManufacturerXPath = "//td[contains(text(), 'Manufacturer')]/following-sibling::td[1]";
        public const string GainXPath = "//td[contains(text(), 'Gain')]/following-sibling::td[1]";
        public const string TransmissionLocationXPath = "//td[contains(normalize-space(text()), 'Support Structure Type')]/following-sibling::td[1]";
        public const string EIRPXPath = "//td[contains(text(), 'EIRP')]/following-sibling::td[1]";
        public const string AntennaElevationXPath = "//td[starts-with(normalize-space(text()), 'Overall Height') and substring(text()[2], string-length(text()[2]) - string-length('With Appurtenances')+1) = 'With Appurtenances']/following-sibling::td[1]";
        public const string PolarityXPath = "//td[contains(text(), 'Polarization')]/following-sibling::td[1]";
        public const string AzimuthXPath = "//td[contains(text(), 'Azimuth')]/following-sibling::td[1]";
        public const string SiteNameXPath = "//b[contains(normalize-space(text()), '. Site')]";
        public const string CoordinatesXPath = "//td[contains(normalize-space(text()), 'Transmitter')]/following-sibling::td[1]";
        public const string CityXPath = "//td[contains(normalize-space(text()), 'City')]/following-sibling::td[1]";
        public const string CountyXPath = "//td[contains(normalize-space(text()), 'County')]/following-sibling::td[1]";
        public const string ElevationAngleXPath = "//td[contains(text(), 'Elevation Angle')]/following-sibling::td[1]";
        public const string SpectrumXPath = "//td[contains(text(), 'Radio Service')]/following-sibling::td[1]";
    }
}
