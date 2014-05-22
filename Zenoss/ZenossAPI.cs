namespace Zenoss
{
    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    public class CookieAwareWebClient : WebClient
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
    public class Routers
    {
        public const string MessagingRouter = "messaging";
        public const string EventsRouter = "evconsole";
        public const string ProcessRouter = "process";
        public const string ServiceRouter = "service";
        public const string DeviceRouter = "device";
        public const string NetworkRouter = "network";
        public const string TemplateRouter = "template";
        public const string DetailNavRouter = "detailnav";
        public const string ReportRouter = "report";
        public const string MibRouter = "mib";
        public const string ZenPackRouter = "zenpack";
    }
    public class ZenossAPI
    {
        public static string host = null;
        public static CookieAwareWebClient client = new CookieAwareWebClient();
        public static int req_count = 0;
        public static Hashtable GetRouters()
        {
            Hashtable routerTable = new Hashtable();

            routerTable.Add("MessagingRouter", "messaging");
            routerTable.Add("EventsRouter", "evconsole");
            routerTable.Add("ProcessRouter", "process");
            routerTable.Add("ServiceRouter", "service");
            routerTable.Add("DeviceRouter", "device");
            routerTable.Add("NetworkRouter", "network");
            routerTable.Add("TemplateRouter", "template");
            routerTable.Add("DetailNavRouter", "detailnav");
            routerTable.Add("ReportRouter", "report");
            routerTable.Add("MibRouter", "mib");
            routerTable.Add("ZenPackRouter", "zenpack");

            return routerTable;
        }
        public static void connect(string host, string username, string password)
        {
            string authPath = "/zport/acl_users/cookieAuthHelper/login";
            string came_from = "/zport/dmd/";
            ZenossAPI.host = host;
            ZenossAPI.req_count = ZenossAPI.req_count + 1;

            NameValueCollection login_params = new NameValueCollection { 
                {"__ac_name",username},
                {"__ac_password",password},
                {"submitted","true"},
                {"came_from",host+came_from}
            };

            client.UploadValues(host + authPath, "POST", login_params);
        }
        public static string router_request(string endpoint, string router, string method, string data = null)
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
        public static JObject get_devices(string deviceClass = "/zport/dmd/Devices")
        {
            string endpoint = "/zport/dmd/Devices";
            string router = "DeviceRouter";
            string method = "getDevices";

            JObject jPayload = new JObject(
                new JProperty("uid", deviceClass),
                new JProperty("params", "{}"));
            JArray jData = new JArray();
            jData.Add(jPayload);

            List<zenObjects.zenDevice> zDevices = (List<zenObjects.zenDevice>)JsonConvert.DeserializeObject(router_request(endpoint, router, method, jData.ToString()), typeof(List<zenObjects.zenDevice>));

            return JObject.Parse(router_request(endpoint, router, method, jData.ToString())) as JObject;
        }
        public static JObject find_device(string device_name, string deviceClass = "/zport/dmd/Devices")
        {
            string endpoint = "/zport/dmd/Devices";
            string router = "DeviceRouter";
            string method = "getDevices";

            JObject jPayload = new JObject(
                new JProperty("uid", deviceClass),
                new JProperty("params", "{}"));
            JArray jData = new JArray();
            jData.Add(jPayload);

            JObject jReturn = JObject.Parse(router_request(endpoint, router, method, jData.ToString()))["result"] as JObject;
            string hash = jReturn["hash"].ToString();

            jPayload.RemoveAll();
            jPayload = new JObject(
                new JProperty("uid", deviceClass),
                new JProperty("params",
                    new JObject(new JProperty("name", device_name))));
            jData.ReplaceAll(jPayload);

            JObject zDevice = JObject.Parse(router_request(endpoint, router, method, jData.ToString()))["result"] as JObject;
            zDevice["hash"] = hash;
            return zDevice;
        }
        public static JObject add_device(string device_name, string device_class = "/zport/dmd/Devices", string collector = "localhost")
        {
            string endpoint = "/zport/dmd/Devices";
            string router = "DeviceRouter";
            string method = "addDevice";

            JObject jPayload = new JObject(
                new JProperty("deviceName", device_name),
                new JProperty("deviceClass", device_class),
                new JProperty("model", "True"),
                new JProperty("collector", collector));
            JArray jData = new JArray();
            jData.Add(jPayload);

            return JObject.Parse(router_request(endpoint, router, method, jData.ToString()));
        }
        public static JObject create_event_on_device(string device, string severity, string summary, string evclass = "", string component = "", string evclasskey = "")
        {
            string endpoint = "/zport/dmd/Devices";
            string router = "EventsRouter";
            string method = "add_event";

            string[] sev = { "Critical", "Error", "Warning", "Info", "Debug", "Clear" };
            if (sev.Any(severity.Contains))
            {
                JObject jPayload = new JObject(
                    new JProperty("device", device),
                    new JProperty("summary", summary),
                    new JProperty("severity", severity),
                    new JProperty("component", component),
                    new JProperty("evclasskey", evclasskey),
                    new JProperty("evclass", evclass));
                JArray jData = new JArray();
                jData.Add(jPayload);

                return JObject.Parse(router_request(endpoint, router, method, jData.ToString()));
            }
            else
            {
                return null;
            }
        }
        public static JObject remove_device(string device_name, string device_class)
        {
            string endpoint = "/zport/dmd/Devices";
            string router = "DeviceRouter";
            string method = "removeDevices";

            JToken device = find_device(device_name)["devices"][0];
            string uid = (string)device["uid"];
            string hash = (string)device["hash"];

            JObject jPayload = new JObject(
                new JProperty("uids",
                    new JArray(uid)),
                new JProperty("hashcheck", hash),
                new JProperty("action", "delete"));
            JArray jData = new JArray();
            jData.Add(jPayload);

            return JObject.Parse(router_request(endpoint, router, method, jData.ToString()));
        }
        public static JObject set_prod_state(string device_name, int prod_state)
        {
            string endpoint = "/zport/dmd/Devices";
            string router = "DeviceRouter";
            string method = "setProductionState";

            JToken device = find_device(device_name)["devices"][0];
            string uid = (string)device["uid"];
            string hash = (string)device["hash"];

            //
            // prodState -1 = Decommissioned
            // prodState 300 = Maintenance
            // prodState 500 = Pre-Production
            // prodState 1000 = Production
            // 

            JObject jPayload = new JObject(
                new JProperty("uids",
                    new JArray(uid)),
                new JProperty("hashcheck", hash),
                new JProperty("prodState", prod_state));
            JArray jData = new JArray();
            jData.Add(jPayload);

            return JObject.Parse(router_request(endpoint, router, method, jData.ToString()));
        }
        public static JObject get_events(string device_name = "", int limit = 100, string component = "", string eventClass = "")
        {
            string endpoint = "/zport/dmd/Events";
            string router = "EventsRouter";
            string method = "query";

            JProperty jStart = new JProperty("start", 0);
            JProperty jLimit = new JProperty("limit", limit);
            JProperty jDir = new JProperty("dir", "DESC");
            JProperty jSort = new JProperty("sort", "severity");

            JProperty jSeverity = new JProperty("severity", "[5,4,3,2]");
            JProperty jEventState = new JProperty("eventState", "[0,1]");

            //JProperty jDevice = null;
            //JProperty jComponent = null;
            //JProperty jEventClass = null;

            //if (device_name != "")
            //{
            //    jDevice = new JProperty("device", device_name);
            //}

            //if (component != "")
            //{
            //    jComponent = new JProperty("component", component);
            //}

            //if (eventClass != "")
            //{
            //    jEventClass = new JProperty("eventClass", eventClass);
            //}


            dynamic blah = new JArray();
            blah.data = new JArray("start", 0);

            JObject jPayload = new JObject(new JProperty("data", new JArray(
                JArray.Parse(jStart.ToString()),
                JArray.Parse(jLimit.ToString()),
                JArray.Parse(jDir.ToString()),
                JArray.Parse(jSort.ToString()))));
            JArray jRequest = new JArray();
            jRequest.Add(jPayload);

            return JObject.Parse(router_request(endpoint, router, method, jRequest.ToString()))["result"] as JObject;
        }
    }
}
