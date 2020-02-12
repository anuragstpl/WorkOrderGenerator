using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WorkOrderCreator
{
    public partial class WorkOrder
    {
        [JsonProperty("alternateContact")]
        public string AlternateContact { get; set; }

        [JsonProperty("alternateWorkOrderNumber")]
        public string AlternateWorkOrderNumber { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isEmergency")]
        public bool IsEmergency { get; set; }

        [JsonProperty("locationNumber")]
        public long LocationNumber { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }

        [JsonProperty("DNE")]
        public long Dne { get; set; }

        [JsonProperty("requestCode")]
        public long RequestCode { get; set; }

        [JsonProperty("requestType")]
        public long RequestType { get; set; }

        [JsonProperty("requestingContact")]
        public string RequestingContact { get; set; }

        [JsonProperty("scriptingQuestion")]
        public List<ScriptingQuestion> ScriptingQuestion { get; set; }

        [JsonProperty("serviceLocation")]
        public long ServiceLocation { get; set; }

        [JsonProperty("vendorCode")]
        public string VendorCode { get; set; }

        [JsonProperty("workOrderType")]
        public string WorkOrderType { get; set; }

        [JsonProperty("workType")]
        public string WorkType { get; set; }

        [JsonProperty("Equipment")]
        public string Equipment { get; set; }

        [JsonProperty("StatusCode")]
        public string StatusCode { get; set; }
    }

    public partial class ScriptingQuestion
    {
        [JsonProperty("answer")]
        public string Answer { get; set; }

        [JsonProperty("verbage")]
        public string Verbage { get; set; }

        [JsonProperty("scriptQuestionType")]
        public long ScriptQuestionType { get; set; }

        [JsonProperty("choices")]
        public List<object> Choices { get; set; }
    }
}
