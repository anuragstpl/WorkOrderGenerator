using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WorkOrderCreator
{
    public partial class WorkOrderResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("workOrderNumber")]
        public string WorkOrderNumber { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("workType")]
        public object WorkType { get; set; }

        [JsonProperty("status")]
        public object Status { get; set; }

        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }

        [JsonProperty("dateReported")]
        public DateTimeOffset DateReported { get; set; }

        [JsonProperty("dateModified")]
        public DateTimeOffset DateModified { get; set; }

        [JsonProperty("targetDate")]
        public DateTimeOffset TargetDate { get; set; }

        [JsonProperty("scheduledStartDateTime")]
        public object ScheduledStartDateTime { get; set; }

        [JsonProperty("scheduledCompleteDateTime")]
        public object ScheduledCompleteDateTime { get; set; }

        [JsonProperty("actualStartDateTime")]
        public object ActualStartDateTime { get; set; }

        [JsonProperty("actualCompleteDateTime")]
        public object ActualCompleteDateTime { get; set; }

        [JsonProperty("nextFollowUpDateTime")]
        public object NextFollowUpDateTime { get; set; }

        [JsonProperty("latestInteractiveVoiceResponseIn")]
        public object LatestInteractiveVoiceResponseIn { get; set; }

        [JsonProperty("latestInteractiveVoiceResponseOut")]
        public object LatestInteractiveVoiceResponseOut { get; set; }

        [JsonProperty("glCode")]
        public long GlCode { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("requestingContact")]
        public string RequestingContact { get; set; }

        [JsonProperty("alternateContact")]
        public string AlternateContact { get; set; }

        [JsonProperty("requestTypeId")]
        public long RequestTypeId { get; set; }

        [JsonProperty("requestType")]
        public string RequestType { get; set; }

        [JsonProperty("departmentId")]
        public long DepartmentId { get; set; }

        [JsonProperty("department")]
        public object Department { get; set; }

        [JsonProperty("tradeId")]
        public long TradeId { get; set; }

        [JsonProperty("requestCodeId")]
        public long RequestCodeId { get; set; }

        [JsonProperty("requestCode")]
        public string RequestCode { get; set; }

        [JsonProperty("serviceLocationName")]
        public string ServiceLocationName { get; set; }

        [JsonProperty("dne")]
        public long Dne { get; set; }

        [JsonProperty("provider")]
        public Provider Provider { get; set; }

        [JsonProperty("client")]
        public Cause Client { get; set; }

        [JsonProperty("cause")]
        public Cause Cause { get; set; }

        [JsonProperty("remedy")]
        public Cause Remedy { get; set; }

        [JsonProperty("equipment")]
        public Equipment Equipment { get; set; }

        [JsonProperty("workTypeGLCode")]
        public object WorkTypeGlCode { get; set; }

        [JsonProperty("requestGLCode")]
        public object RequestGlCode { get; set; }

        [JsonProperty("dispatchMatrixGLCode")]
        public object DispatchMatrixGlCode { get; set; }

        [JsonProperty("availableVendorAction")]
        public long AvailableVendorAction { get; set; }

        [JsonProperty("alternateWorkOrderNumber")]
        public string AlternateWorkOrderNumber { get; set; }

        [JsonProperty("isETAMissed")]
        public bool IsEtaMissed { get; set; }

        [JsonProperty("missedETAMessage")]
        public object MissedEtaMessage { get; set; }

        [JsonProperty("isEmergency")]
        public bool IsEmergency { get; set; }

        [JsonProperty("isVendorOnSite")]
        public bool IsVendorOnSite { get; set; }

        [JsonProperty("hasAttachments")]
        public bool HasAttachments { get; set; }

        [JsonProperty("targetCompleteDate")]
        public DateTimeOffset TargetCompleteDate { get; set; }

        [JsonProperty("isSnow")]
        public bool IsSnow { get; set; }

        [JsonProperty("projectNumber")]
        public object ProjectNumber { get; set; }

        [JsonProperty("projectOther")]
        public object ProjectOther { get; set; }

        [JsonProperty("currencyCode")]
        public object CurrencyCode { get; set; }
    }

    public partial class Cause
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public object Name { get; set; }

        [JsonProperty("requestCodeId", NullValueHandling = NullValueHandling.Ignore)]
        public long? RequestCodeId { get; set; }

        [JsonProperty("domain")]
        public object Domain { get; set; }

        [JsonProperty("causeId", NullValueHandling = NullValueHandling.Ignore)]
        public long? CauseId { get; set; }
    }

    public partial class Equipment
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("equipmentTypeName")]
        public object EquipmentTypeName { get; set; }

        [JsonProperty("brand")]
        public object Brand { get; set; }

        [JsonProperty("model")]
        public object Model { get; set; }

        [JsonProperty("assetTag")]
        public object AssetTag { get; set; }

        [JsonProperty("serialNumber")]
        public object SerialNumber { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("storeNumber")]
        public string StoreNumber { get; set; }

        [JsonProperty("storeName")]
        public string StoreName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("addressDetails")]
        public AddressDetails AddressDetails { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("mallName")]
        public string MallName { get; set; }

        [JsonProperty("costCenterCode")]
        public long CostCenterCode { get; set; }

        [JsonProperty("multiBrandLocation")]
        public bool MultiBrandLocation { get; set; }

        [JsonProperty("timeZoneOffset")]
        public long TimeZoneOffset { get; set; }

        [JsonProperty("timeZone")]
        public object TimeZone { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }
    }

    public partial class AddressDetails
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("stateAbbreviation")]
        public string StateAbbreviation { get; set; }

        [JsonProperty("countryAbbreviation")]
        public string CountryAbbreviation { get; set; }

        [JsonProperty("addressType")]
        public long AddressType { get; set; }

        [JsonProperty("line1")]
        public string Line1 { get; set; }

        [JsonProperty("line2")]
        public string Line2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("zipPostalCode")]
        public long ZipPostalCode { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }

    public partial class Provider
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("contact")]
        public string Contact { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("dne")]
        public long Dne { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        [JsonProperty("email")]
        public object Email { get; set; }

        [JsonProperty("address")]
        public object Address { get; set; }

        [JsonProperty("addressDetails")]
        public object AddressDetails { get; set; }
    }
}
