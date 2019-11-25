using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MarketHelpers
{
    

    public class GloabalInfo
    {
        [JsonProperty("geoplugin_request")]
        public string GeopluginRequest { get; set; }

        [JsonProperty("geoplugin_status")]
        public long GeopluginStatus { get; set; }

        [JsonProperty("geoplugin_delay")]
        public string GeopluginDelay { get; set; }

        [JsonProperty("geoplugin_credit")]
        public string GeopluginCredit { get; set; }

        [JsonProperty("geoplugin_city")]
        public string GeopluginCity { get; set; }

        [JsonProperty("geoplugin_region")]
        public string GeopluginRegion { get; set; }

        [JsonProperty("geoplugin_regionCode")]
        public string GeopluginRegionCode { get; set; }

        [JsonProperty("geoplugin_regionName")]
        public string GeopluginRegionName { get; set; }

        [JsonProperty("geoplugin_areaCode")]
        public string GeopluginAreaCode { get; set; }

        [JsonProperty("geoplugin_dmaCode")]
        public string GeopluginDmaCode { get; set; }

        [JsonProperty("geoplugin_countryCode")]
        public string GeopluginCountryCode { get; set; }

        [JsonProperty("geoplugin_countryName")]
        public string GeopluginCountryName { get; set; }

        [JsonProperty("geoplugin_inEU")]
        public long GeopluginInEu { get; set; }

        [JsonProperty("geoplugin_euVATrate")]
        public bool GeopluginEuVaTrate { get; set; }

        [JsonProperty("geoplugin_continentCode")]
        public string GeopluginContinentCode { get; set; }

        [JsonProperty("geoplugin_continentName")]
        public string GeopluginContinentName { get; set; }

        
        public long GeopluginLongitude { get; set; }

      

        [JsonProperty("geoplugin_timezone")]
        public string GeopluginTimezone { get; set; }

        [JsonProperty("geoplugin_currencyCode")]
        public string GeopluginCurrencyCode { get; set; }

        [JsonProperty("geoplugin_currencySymbol")]
        public string GeopluginCurrencySymbol { get; set; }

        [JsonProperty("geoplugin_currencySymbol_UTF8")]
        public string GeopluginCurrencySymbolUtf8 { get; set; }

        [JsonProperty("geoplugin_currencyConverter")]
        public double GeopluginCurrencyConverter { get; set; }
    }

}
