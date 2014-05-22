namespace Zenoss
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    /// <summary>
    /// A collection of json object for working with Zenoss
    /// </summary>
    class zenObjects
    {
        [JsonObject(MemberSerialization.OptIn)]
        public class Info
        {
            [JsonProperty]
            public int count { get; set; }
            [JsonProperty]
            public int acknowledged_count { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class Clear
        {
            [JsonProperty]
            public int count { get; set; }
            [JsonProperty]
            public int acknowledged_count { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class Warning
        {
            [JsonProperty]
            public int count { get; set; }
            [JsonProperty]
            public int acknowledged_count { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class Critical
        {
            [JsonProperty]
            public int count { get; set; }
            [JsonProperty]
            public int acknowledged_count { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class Error
        {
            [JsonProperty]
            public int count { get; set; }
            [JsonProperty]
            public int acknowledged_count { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class Debug
        {
            [JsonProperty]
            public int count { get; set; }
            [JsonProperty]
            public int acknowledged_count { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class Events
        {
            [JsonProperty]
            public Info info { get; set; }
            [JsonProperty]
            public Clear clear { get; set; }
            [JsonProperty]
            public Warning warning { get; set; }
            [JsonProperty]
            public Critical critical { get; set; }
            [JsonProperty]
            public Error error { get; set; }
            [JsonProperty]
            public Debug debug { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class zenDevice
        {
            [JsonProperty]
            public List<object> groups { get; set; }
            [JsonProperty]
            public string ipAddressString { get; set; }
            [JsonProperty]
            public string serialNumber { get; set; }
            [JsonProperty]
            public string name { get; set; }
            [JsonProperty]
            public string collector { get; set; }
            [JsonProperty]
            public object osModel { get; set; }
            [JsonProperty]
            public string productionState { get; set; }
            [JsonProperty]
            public object location { get; set; }
            [JsonProperty]
            public string priority { get; set; }
            [JsonProperty]
            public object hwModel { get; set; }
            [JsonProperty]
            public string tagNumber { get; set; }
            [JsonProperty]
            public object osManufacturer { get; set; }
            [JsonProperty]
            public List<object> systems { get; set; }
            [JsonProperty]
            public object hwManufacturer { get; set; }
            [JsonProperty]
            public long? ipAddress { get; set; }
            [JsonProperty]
            public Events events { get; set; }
            [JsonProperty]
            public string uid { get; set; }
        }
    }
}