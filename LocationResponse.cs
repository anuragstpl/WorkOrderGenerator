using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WorkOrderCreator
{
    public partial class LocationResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("storeNumber")]
        public string StoreNumber { get; set; }

        [JsonProperty("storeName")]
        public string StoreName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("costCenterCode")]
        public string CostCenterCode { get; set; }

        [JsonProperty("multiBrandLocation")]
        public bool MultiBrandLocation { get; set; }

        [JsonProperty("timeZoneOffset")]
        public long TimeZoneOffset { get; set; }

        [JsonProperty("timeZone")]
        public object TimeZone { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }
    }
}
