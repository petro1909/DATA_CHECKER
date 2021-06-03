using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.NetworkInformation;

namespace DATA_CHECKER
{
    class Connection
    {

        

        public static bool CheckConnection(string RobotIp) {
            try {
                Ping ping = new Ping();
                PingReply result = ping.Send(RobotIp);
                return  result.Status == IPStatus.Success;
                //if (result.Status == IPStatus.Success)
                //{
                //    return "Robot is connected";
                //} else
                //{
                //    return "Robot is not connected";
                //}
            } catch(Exception e) {
                Console.WriteLine("Error" + e);
                return false; 
                
            }
        }
    }
}
