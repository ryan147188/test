using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using Json.Net;
using System.Net;

namespace ConsoleApp1
{   
    class Class1
    {
        static void Main(string[] args)
             
        {
            
            //get request Key

            Rootobject rootobject = new Rootobject
            {
                merchant_code = "test13",
                trade_type = 2,
                order_number = "r" + DateTime.Now.ToString("yyyyMMddhhmmss"),                          
                order_amount = 1.ToString(".0"),
                order_time = DateTime.Now.ToString("yyyyMMddhhmmss"),                             
                ip = "60.250.156.79",
                notify_url = "https://gsitsyaoran.000webhostapp.com/NotifyResponse.php?rate=80",
                remark = "Test",
                sign_type = "SHA512"
            }; //取得資料
            string jsondata = JsonConvert.SerializeObject(rootobject);
            //轉成JSON格式                        
            Console.WriteLine("result：" + jsondata);
            //顯示       
            var client = new RestClient("http://api.qat.stargate.com/test/getsign/alipay");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", jsondata, ParameterType.RequestBody);
            var response = client.Execute(request);
            var content = response.Content;
            //Restsharp 套件內容         
            Console.WriteLine("post方式獲取結果：" + content);
            //印出 
            
            if (response.ContentLength == 130) 
            //判斷長度=130
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK) 
                //判斷狀態是否為200                  
                {
                    Console.WriteLine("測試結果"+"Pass");
                    Console.WriteLine(response.StatusCode);
                    Console.WriteLine(System.Net.HttpStatusCode.OK);
                }     
                else
                {
                    Console.WriteLine("Fail");
                }
            }
            else 
            {
                Console.WriteLine("Fail");
            }

        

            //payrequest

            Rootobject2 rootobject2 = new Rootobject2
            {
                merchant_code = rootobject.merchant_code,
                trade_type = rootobject.trade_type,
                order_number = rootobject.order_number,
                order_amount = rootobject.order_amount,
                order_time = rootobject.order_time,
                ip = rootobject.ip,
                notify_url = rootobject.notify_url,
                remark = rootobject.remark,
                sign_type = rootobject.sign_type,
                sign = content.Substring(1, 128)
            };//取得前面的資料
            string jsondata2 = JsonConvert.SerializeObject(rootobject2);
            //轉成JSON格式                        
            Console.WriteLine("result：" + jsondata2);
            //顯示               
            var client2 = new RestClient("http://api.qat.stargate.com/PayRequest/alipay");
            var request2 = new RestRequest(Method.POST);         
            request2.AddHeader("content-type", "application/json");         
            request2.AddParameter("application/json", jsondata2, ParameterType.RequestBody);
            var response2 = client2.Execute(request2);           
            var content2 = response2.Content;
            //Restsharp 套件內容         
            Console.WriteLine("post方式獲取結果："+ content2);
            //印出 

            var recode = JsonConvert.DeserializeObject<Rootobject3>(response2.Content);
            //用 Newtonsoft.Json來反序列化
            Console.WriteLine("return_code_URL:" + recode.code_url);
            Console.WriteLine("return_code:" + recode.return_code);
            Console.WriteLine("return_msg:" + recode.return_msg);
            //印出response2的return_code和url的值

            if (recode.return_code == 0 )
             //判斷return_code是否為0
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
            }
            Console.Read();

        }
    }
    
}