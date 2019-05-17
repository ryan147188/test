using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace ConsoleApp1
{
    class Rootobject
    {
        public string merchant_code { get; set; }
        public int trade_type { get; set; }
        public string order_number { get; set; }
        public string order_amount { get; set; }
        public string order_time { get; set; }
        public string ip { get; set; }
        public string notify_url { get; set; }
        public string remark { get; set; }
        public string sign_type { get; set; }

    }

    class Rootobject2
    {
        public string merchant_code { get; set; }
        public int trade_type { get; set; }
        public string order_number { get; set; }
        public string order_amount { get; set; }
        public string order_time { get; set; }
        public string ip { get; set; }
        public string notify_url { get; set; }
        public string remark { get; set; }
        public string sign_type { get; set; }
        public string sign { get; set; }
    }


     class Rootobject3
     {
      
        public string code_url { get; set; }    
        public int return_code { get; set; }    
        public object return_msg { get; set; }
     }



}

