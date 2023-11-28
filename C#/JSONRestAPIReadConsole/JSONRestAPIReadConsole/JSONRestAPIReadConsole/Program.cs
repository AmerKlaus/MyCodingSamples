using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JSONRestAPIReadConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetEmployeeData();
        }

        public static void GetEmployeeData()
        {
            var client = new RestClient("http://dummy.restapiexample.com/api/v1/");
            var requestObject = new RestRequest("employees");
            var response = client.Execute(requestObject);    //.ExecuteAsync(requestObject);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                Rootobject result = JsonConvert.DeserializeObject<Rootobject>(rawResponse);

                for(int i = 0; i < 24;  i++)
                {
                    System.Console.WriteLine(result.data[i].id   );
                    System.Console.WriteLine(result.data[i].employee_name);
                    System.Console.WriteLine(result.data[i].employee_age);
                    System.Console.WriteLine(result.data[i].employee_salary+"\n");
                }
            }
        }
    }
    /*
    public class Rootobject
    {
        public string status { get; set; }
        public Datum[] data { get; set; }
        public string message { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
    }
*/
}
