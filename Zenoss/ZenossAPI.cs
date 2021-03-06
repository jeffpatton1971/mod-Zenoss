﻿namespace mod_zenoss
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net;
    using System.Text;
    public class ZenossAPI
    {
        static string host = null;
        static CookieAwareWebClient client = new CookieAwareWebClient();
        static int req_count = 0;
        /// <summary>
        /// A hashtable of routers
        /// </summary>
        /// <returns>A Hashtable object</returns>
        private static Hashtable GetRouters()
        {
            Hashtable routerTable = new Hashtable();

            routerTable.Add("MessagingRouter", "messaging");
            routerTable.Add("EventsRouter", "evconsole");
            routerTable.Add("ProcessRouter", "process");
            routerTable.Add("ServiceRouter", "service");
            routerTable.Add("SettingsRouter", "settings");
            routerTable.Add("DeviceRouter", "device");
            routerTable.Add("NetworkRouter", "network");
            routerTable.Add("TemplateRouter", "template");
            routerTable.Add("DetailNavRouter", "detailnav");
            routerTable.Add("ReportRouter", "report");
            routerTable.Add("MibRouter", "mib");
            routerTable.Add("ZenPackRouter", "zenpack");

            return routerTable;
        }
        /// <summary>
        /// A function to handle authenticating to a Zenoss server
        /// </summary>
        /// <param name="Credential">A NetworkCredential object that contains the username and password to conenct as</param>
        /// <param name="zenServer">A string containing the name of the server to auth to</param>
        public static void Connect(NetworkCredential Credential, string zenServer)
        {
            try
            {
                string authPath = "/zport/acl_users/cookieAuthHelper/login";
                string came_from = "/zport/dmd/";
                string username = Credential.UserName;
                string password = Credential.Password;
                ZenossAPI.host = zenServer;
                ZenossAPI.req_count = ZenossAPI.req_count + 1;

                NameValueCollection login_params = new NameValueCollection { 
                {"__ac_name",username},
                {"__ac_password",password},
                {"submitted","true"},
                {"came_from",host+came_from}
            };

                client.UploadValues(host + authPath, "POST", login_params);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// This function builds the actual URL and connection to retrieve data from
        /// or send data to a Zenoss server.
        /// </summary>
        /// <param name="endpoint">The location of where the data is stored</param>
        /// <param name="router">Represents what we are trying to get at</param>
        /// <param name="method">What method are we accessing to perform our action</param>
        /// <param name="data">A JSON string that contains the data</param>
        /// <returns>A JSON string</returns>
        public static string RouterRequest(string endpoint, string router, string method, string data = null)
        {
            try
            {
                Hashtable routerLookup = GetRouters();
                string RouterValue = (string)routerLookup[router];

                string apiUrl = host + endpoint + "/" + RouterValue + "_router";

                ZenossAPI.client.Headers["Content-type"] = "application/json";
                ZenossAPI.client.Headers["charset"] = "utf-8";

                int tid = ZenossAPI.req_count;

                JObject jPayload = new JObject(
                    new JProperty("action", router),
                    new JProperty("method", method),
                    new JProperty("data", new JArray(
                        JArray.Parse(data))),
                    new JProperty("type", "rpc"),
                    new JProperty("tid", tid));
                JArray jPost = new JArray();
                jPost.Add(jPayload);

                ZenossAPI.req_count = ZenossAPI.req_count + 1;

                byte[] restReturn = client.UploadData(apiUrl, Encoding.Default.GetBytes(jPost.ToString()));
                return Encoding.ASCII.GetString(restReturn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// This is a generic function which can handle most of the methods provided by various Routers
        /// </summary>
        /// <param name="id">The ID</param>
        /// <param name="router">Which router to use</param>
        /// <param name="endpoint">Which endpoint to use</param>
        /// <param name="method">What method to call</param>
        /// <returns>A JSON object containing the data requested</returns>
        public static JObject RunMethod(string id, string router, string endpoint, string method, JObject PayLoad = null)
        {
            try
            {
                JArray jData = new JArray();
                JObject jPayload = new JObject();
                switch (method)
                {
                    case "getDevices" :
                        //
                        // GetDevices requires uid
                        //
                        if (PayLoad == null)
                        {
                            jPayload.Add(new JProperty("uid", id));
                        }
                        else
                        {
                            jPayload = PayLoad;
                        }
                        break;
                    case "getTree" :
                        //
                        // GetTree requires id
                        //
                        jPayload.Add(new JProperty("id", id));
                        break;
                    case "getGroups" :
                        //
                        // GetGroups has no required parameters 
                        //
                        break;
                    case "query" :
                        //
                        // Query has no required parameters
                        //
                        if (PayLoad == null)
                        {

                        }
                        else
                        {
                            jPayload = PayLoad;
                        }
                        break;
                    case "addDevice" :
                        //
                        // AddDevice requires deviceName
                        // AddDevice requires deviceClass
                        //
                        if (PayLoad == null)
                        {

                        }
                        else
                        {
                            jPayload = PayLoad;
                        }
                        break;
                    case "removeDevices" :
                        //
                        //
                        //
                        if (PayLoad == null)
                        {

                        }
                        else
                        {
                            jPayload = PayLoad;
                        }
                        break;
                }
                jData.Add(jPayload);

                return JObject.Parse(RouterRequest(endpoint, router, method, jData.ToString())) as JObject;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get a list of devices from Zenoss
        /// </summary>
        /// <param name="deviceClass">The class of the device</param>
        /// <returns>a JSON object</returns>
        public static JObject GetDevices()
        {
            try
            {
                string endpoint = "/zport/dmd/Devices";
                string router = "DeviceRouter";
                string method = "getDevices";

                return RunMethod(endpoint, router, endpoint, method);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Return information about a specific device from Zenoss
        /// </summary>
        /// <param name="device_name">The name of the device</param>
        /// <param name="deviceClass">The class of the device</param>
        /// <returns>A JSON object</returns>
        public static JObject FindDevice(string device_name)
        {
            try
            {
                string endpoint = "/zport/dmd/Devices";
                string router = "DeviceRouter";
                string method = "getDevices";
                string deviceClass = "/zport/dmd/Devices";

                JObject jPayload = new JObject();
                jPayload = new JObject(
                    new JProperty("uid", deviceClass),
                    new JProperty("params",
                        new JObject(new JProperty("name", device_name))));
                return RunMethod(endpoint, router, endpoint, method, jPayload);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Add a device to Zenoss
        /// </summary>
        /// <param name="device_name">The name of the device</param>
        /// <param name="device_class">The class of the device</param>
        /// <param name="collector">The name of the collector</param>
        /// <returns>A JSON object</returns>
        public static JObject AddDevice(string device_name, IList GroupPath, string device_class = "/zport/dmd/Devices", string collector = "localhost")
        {
            try
            {
                string endpoint = "/zport/dmd/Devices";
                string router = "DeviceRouter";
                string method = "addDevice";

                JObject jPayload = new JObject(
                    new JProperty("deviceName", device_name),
                    new JProperty("deviceClass", device_class),
                    new JProperty("model", "True"),
                    new JProperty("collector", collector),
                    new JProperty("groupPaths",
                        new JArray(GroupPath)));

                return RunMethod(endpoint, router, endpoint, method, jPayload);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Create an event on a specific device
        /// </summary>
        /// <param name="device_name">The name of the device</param>
        /// <param name="severity">The severity of the event</param>
        /// <param name="summary">A description of the event</param>
        /// <param name="eventClass">The event class</param>
        /// <param name="component">What component on the device created the event</param>
        /// <param name="evclasskey"></param>
        /// <returns>A JSON object</returns>
        public static JObject CreateEvent(string device_name, string severity, string summary, string eventClass = "", string component = "", string evclasskey = "")
        {
            try
            {
                string endpoint = "/zport/dmd/Devices";
                string router = "EventsRouter";
                string method = "add_event";

                string[] sev = { "Critical", "Error", "Warning", "Info", "Debug", "Clear" };
                if (sev.Any(severity.Contains))
                {
                    JObject jPayload = new JObject(
                        new JProperty("device", device_name),
                        new JProperty("summary", summary),
                        new JProperty("severity", severity),
                        new JProperty("component", component),
                        new JProperty("evclasskey", evclasskey),
                        new JProperty("evclass", eventClass));

                    return RunMethod(endpoint, router, endpoint, method, jPayload);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Remove a device from Zenoss
        /// </summary>
        /// <param name="device_name">The name of the device</param>
        /// <param name="device_class">The class of the device</param>
        /// <returns>A JSON object</returns>
        public static JObject RemoveDevice(string device_name, string device_class)
        {
            try
            {
                string endpoint = "/zport/dmd/Devices";
                string router = "DeviceRouter";
                string method = "removeDevices";

                JObject device = JObject.Parse(FindDevice(device_name).ToString());
                JToken result = device["result"];
                zenObjects.zenDevice zd = (result["devices"][0]).ToObject<zenObjects.zenDevice>();
                string uid = zd.uid;
                string hash = (string)result["hash"];

                JObject jPayload = new JObject(
                    new JProperty("uids",
                        new JArray(uid)),
                    new JProperty("hashcheck", hash),
                    new JProperty("action", "delete"));

                return RunMethod(uid, router, endpoint, method, jPayload);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Set the production state for a given device
        /// </summary>
        /// <param name="device_name">The name of the device</param>
        /// <param name="prod_state">The production state</param>
        /// <returns>A JSON object</returns>
        public static JObject SetProductionState(string device_name, string ProductionState)
        {
            try
            {
                string endpoint = "/zport/dmd/Devices";
                string router = "DeviceRouter";
                string method = "setProductionState";
                int prod_state = 0;

                JToken device = FindDevice(device_name);
                string uid = (string)device["uid"];
                string hash = (string)device["hash"];

                switch (ProductionState.ToLower())
                {
                    case "decommissioned" :
                        prod_state = -1;
                        break;
                    case "maintenance" :
                        prod_state = 300;
                        break;
                    case "pre-production" :
                        prod_state = 500;
                        break;
                    case "production" :
                        prod_state = 1000;
                        break;
                }

                JObject jPayload = new JObject(
                    new JProperty("uids",
                        new JArray(uid)),
                    new JProperty("hashcheck", hash),
                    new JProperty("prodState", prod_state));

                return RunMethod(endpoint, router, endpoint, method, jPayload);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get a list of events from Zenoss for a given device
        /// </summary>
        /// <param name="device_name">The name of the device</param>
        /// <param name="limit">How many events to return</param>
        /// <param name="component">What component on the device created the event</param>
        /// <param name="eventClass">The event class</param>
        /// <param name="severity"></param>
        /// <param name="eventState"></param>
        /// <returns>A JSON object</returns>
        public static JObject GetEvents(string device_name = "", int limit = 100, string component = "", string eventClass = "", string severity = "", string eventState = "")
        {
            try
            {
                string endpoint = "/zport/dmd/Events";
                string router = "EventsRouter";
                string method = "query";

                JProperty jStart = new JProperty("start", 0);
                JProperty jLimit = new JProperty("limit", limit);
                JProperty jDir = new JProperty("dir", "DESC");
                JProperty jSort = new JProperty("sort", "severity");

                JProperty jSeverity = new JProperty("severity", severity);
                JProperty jEventState = new JProperty("eventState", eventState);

                JObject jPayload = new JObject(
                    jStart,
                    jLimit,
                    jDir,
                    jSort,
                    new JProperty("params", new JObject(
                        jSeverity,
                        jEventState)),
                    new JProperty("keys", new JArray(
                        "eventState",
                        "severity",
                        "device",
                        "component",
                        "eventClass",
                        "summary",
                        "firstTime",
                        "lastTime",
                        "count",
                        "evid",
                        "eventClassKey",
                        "message")));

                return RunMethod(endpoint, router, endpoint, method, jPayload);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Extend the WebClient class to accept cookies
        /// </summary>
        private class CookieAwareWebClient : WebClient
        {
            private readonly CookieContainer m_container = new CookieContainer();
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest request = base.GetWebRequest(address);
                HttpWebRequest webRequest = request as HttpWebRequest;
                if (webRequest != null)
                {
                    webRequest.CookieContainer = m_container;
                }
                return request;
            }
        }
        /// <summary>
        /// A collection of routers
        /// </summary>
        private class Routers
        {
            public const string MessagingRouter = "messaging";
            public const string EventsRouter = "evconsole";
            public const string ProcessRouter = "process";
            public const string ServiceRouter = "service";
            public const string SettingsRouter = "settings";
            public const string DeviceRouter = "device";
            public const string NetworkRouter = "network";
            public const string TemplateRouter = "template";
            public const string DetailNavRouter = "detailnav";
            public const string ReportRouter = "report";
            public const string MibRouter = "mib";
            public const string ZenPackRouter = "zenpack";
        }
    }
}