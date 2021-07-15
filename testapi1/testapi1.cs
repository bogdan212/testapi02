using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

using System.Xml;



namespace testapi1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program coma = new Program();
            
            Console.WriteLine(coma.GetDataFromServer(10, 10));

            Console.ReadLine();
        }

        public int GetDataFromServer(int a, int b)
        {
            var client = new RestClient("http://demo.macroscop.com:8080/command?type=gettime&login=root&password=&responsetype=json");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            //var periodFrom = new DateTime(response.Content);

            string dateInput = response.Content;
            dateInput = dateInput.Remove(0, 2);
            


            var parsedfrom = DateTime.ParseExact(dateInput.Remove(19), "G", null);

            //var periodTo = new DateTime(2022, 10, 5, 12, 30, 0);
            var periodTo = parsedfrom.AddSeconds(15);
            var periodfrom = parsedfrom.AddSeconds(-15);
            // utc +0
            //var periodNow = DateTime.Now.ToUniversalTime();
            //локальное время
            var periodNow = DateTime.Now;
            Console.WriteLine(DateTime.Now);
            if (periodNow > periodfrom && periodNow < periodTo)
            {
                Console.WriteLine("between");
                return a + b;
            }
            else
            {
                Console.WriteLine("not between");
                return 1;
            }

        }
    }
}
