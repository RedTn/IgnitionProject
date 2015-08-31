using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace AIAWebApplication_2.Helpers
{
    public class Helper
    {
        private static string apiDomain = "http://localhost:58865";

        public static string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T Deserialize<T>(string jsonResponse)
        {
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }

        public static string UploadToDb(string jsonObj, Type t)
        {
            using (var client = new HttpClient())
            {
                string url = String.Format("{0}/api/{1}s/", apiDomain, MapObjectToUrl(t));

                HttpResponseMessage hrm = client.PostAsync(url, new StringContent(jsonObj, Encoding.UTF8, "application/json")).Result;
                if (hrm.IsSuccessStatusCode)
                {
                    return hrm.Content.ReadAsStringAsync().Result;
                }
                else throw new System.Exception(hrm.Content.ReadAsStringAsync().Result);
            }
        }

        private static string ChangeToDb(string jsonObj, Type type, int id)
        {
            using (var client = new HttpClient())
            {
                string url = String.Format("{0}/api/{1}s/{2}", apiDomain, MapObjectToUrl(type), id);
                HttpResponseMessage hrm = client.PutAsync(url, new StringContent(jsonObj)).Result;
                if (hrm.IsSuccessStatusCode)
                {
                    return hrm.Content.ReadAsStringAsync().Result;
                }
                else throw new System.Exception(hrm.Content.ReadAsStringAsync().Result);
            }
        }

        private static string ChangeToDb(string jsonObj, Type type, long id)
        {
            using (var client = new HttpClient())
            {
                string url = String.Format("{0}/api/{1}s/{2}", apiDomain, MapObjectToUrl(type), id);
                HttpResponseMessage hrm = client.PutAsync(url, new StringContent(jsonObj, Encoding.UTF8, "application/json")).Result;
                if (hrm.IsSuccessStatusCode)
                {
                    return hrm.Content.ReadAsStringAsync().Result;
                }
                else throw new System.Exception(hrm.Content.ReadAsStringAsync().Result);
            }
        }

        private static string MapObjectToUrl(Type t)
        {
            string typeName = t.ToString().Split('.').Last();
            switch (typeName)
            {
                case "AIAUser":
                    return "AIAUser";
                case "Driver":
                    return "Driver";
                case "Rule":
                    return "Rule";
                case "Vehicle":
                    return "Vehicle";
                case "Quote":
                    return "Quote";
                default:
                    throw new Exception("Invald type.");
            }
        }

        //GET methods
        public static T Get<T>(int id)
        {
            using (var client = new HttpClient())
            {
                string url = String.Format("{0}/api/{1}s/{2}", apiDomain, MapObjectToUrl(typeof(T)), id);
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    return Deserialize<T>(response.Content.ReadAsStringAsync().Result);
                }
                else throw new System.Exception(response.Content.ReadAsStringAsync().Result);

            }
        }

        public static T Get<T>(long id)
        {
            using (var client = new HttpClient())
            {
                string url = String.Format("{0}/api/{1}s/{2}", apiDomain, MapObjectToUrl(typeof(T)), id);
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    return Deserialize<T>(response.Content.ReadAsStringAsync().Result);
                }
                else throw new System.Exception(response.Content.ReadAsStringAsync().Result);

            }
        }

        public static IQueryable<T> Get<T>()
        {
            using (var client = new HttpClient())
            {
                string url = String.Format("{0}/api/{1}s", apiDomain, MapObjectToUrl(typeof(T)));
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    return Deserialize<IQueryable<T>>(response.Content.ReadAsStringAsync().Result);
                }
                else throw new System.Exception(response.Content.ReadAsStringAsync().Result);

            }
        }

        //POST method
        public static T Post<T>(T obj)
        {
            string jsonObj = Serialize<T>(obj);
            return Deserialize<T>(UploadToDb(jsonObj, typeof(T)));
        }

        //PUT methods
        public static T Put<T>(T obj, int id)
        {
            string jsonObj = Serialize<T>(obj);
            return Deserialize<T>(ChangeToDb(jsonObj, typeof(T), id));
        }

        public static T Put<T>(T obj, long id)
        {
            string jsonObj = Serialize<T>(obj);
            return Deserialize<T>(ChangeToDb(jsonObj, typeof(T), id));
        }

        //DELETE methods
        public static T Delete<T>(int id)
        {
            using (var client = new HttpClient())
            {
                string url = String.Format("{0}/api/{1}s/{2}", apiDomain, MapObjectToUrl(typeof(T)), id);
                HttpResponseMessage hrm = client.DeleteAsync(url).Result;
                if (hrm.IsSuccessStatusCode)
                {
                    return Deserialize<T>(hrm.Content.ReadAsStringAsync().Result);
                }
                else throw new System.Exception(hrm.Content.ReadAsStringAsync().Result);
            }
        }
    }
}