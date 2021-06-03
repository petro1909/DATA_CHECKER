using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using System.Net.NetworkInformation;

namespace DATA_CHECKER
{
    class RobotUtil
    {
        static string programPage = "INDEX_TP.HTM";
        public static string RobotIpAdress;
        public static string RobotPort;
        public static string ElementType;
        public static string ElementNumber;
        static bool IsSuccess;

        public static string GetPage(string RobotIp, string RobotPage)
        {
            IsSuccess = Connection.CheckConnection(RobotIp);

            if(IsSuccess == false)
            {
                return "Robot" + RobotIp + "is not connected";
            }

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://" + RobotIp + "/MD/" + RobotPage)
            };
            // client.DefaultRequestHeaders.Authorization = authenticationHeaderValue;

            var result = client.GetStringAsync(client.BaseAddress);
            result.Wait();

            return result.Result;
        }


        public static HtmlDocument CreateWebDock(string adress)
        {
            string url = "http://" + RobotIpAdress + RobotPort + "/MD/" + adress;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(url);
            return document;
        }

        public static List<string> GetLSProgramNames()
        {
            HtmlDocument document = CreateWebDock(programPage);
            List<HtmlNode> nodes = document.DocumentNode.SelectNodes("//td").Where(x=>x.InnerText.Contains(".LS")).ToList();
            List<string> stringNodes = new List<string>();
            
            foreach(HtmlNode node in nodes)
            {
                stringNodes.Add(node.InnerText);
            }

            return stringNodes;
        }

        public static string GetProgramCode(string adress)
        {
            HtmlDocument document = CreateWebDock(adress);
            HtmlNode code = document.DocumentNode.SelectSingleNode("//pre");
            return code.InnerText;
        }



    }
}
