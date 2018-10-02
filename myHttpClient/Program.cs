using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace myHttpClient
{
    class Program
    {
        public class MyObject
        {
            public string ABC { get; set; }
        }

        static void Main(string[] args)
        {
            Task<MyObject> t1 = fetchAsync();

            t1.Wait();
            var bb = t1.Result;

            Console.WriteLine();
            Console.WriteLine("<-------------------RESULT------------------->");
            Console.WriteLine(bb.ABC);
            for (; ; );
        }

        public static async System.Threading.Tasks.Task<MyObject> fetchAsync()
        {
            var http = new System.Net.Http.HttpClient();
            var url = String.Format(
                "https://e8a3ncsk63.execute-api.eu-west-1.amazonaws.com/WillyStage");


            string content = File.ReadAllText("postRequestTemplate.json");
            Console.WriteLine(content);

            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response2 = await http.PostAsync(url, stringContent);

            var result = await response2.Content.ReadAsStringAsync();
            var res = new MyObject()
            {
                ABC = result.ToString()
            };
            return res;
        }
    }
}
