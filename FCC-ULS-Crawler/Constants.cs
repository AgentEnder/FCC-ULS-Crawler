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
}
