﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace MarketHelpers
{
    public class Helpers
    {

        public static string ConnectionString { get; set; } = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;





        public static string GetUserRealIp()
        {
            string url = "http://checkip.dyndns.org";
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];
            return a4;
        }

        public static GloabalInfo GetUserGloabInfo(string IdAddress)
        {

            var requestString = $"http://www.geoplugin.net/json.gp?ip={IdAddress}";
            System.Net.WebRequest req = System.Net.WebRequest.Create(requestString);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            var info =JsonConvert.DeserializeObject<GloabalInfo>(response);
            return info;
        }
   

   

    }
    





}
