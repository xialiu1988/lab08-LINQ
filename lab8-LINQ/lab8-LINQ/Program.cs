using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using lab8_LINQ.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lab8_LINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           List<Properties> list= GetNeighbors(GetObj());//get all the information from the data.json file
            Print(list);//Output all of the neighborhoods in this data list
            IEnumerable<Properties> result=FillterOutNoNameNeighbors(list); // Filter out all the neighborhoods that do not have any names
            Console.WriteLine("===============");
            Console.WriteLine("===============");
            Console.WriteLine("===============");
            Print(result);
            Console.WriteLine("===============");
            Console.WriteLine("===============");
            Console.WriteLine("===============");
                         // Remove the Duplicates
        }

        public static void Print(IEnumerable<Properties> result)
        {
            foreach (Properties n in result)
            {

                Console.WriteLine(n.neighborhood);

            }
        }



        public static void Print(List<Properties> list)
        {
            foreach (Properties n in list)
            {

                Console.WriteLine(n.neighborhood);

            }
        }


        public static IEnumerable<Properties> FillterOutNoNameNeighbors(List<Properties> list)
        {
            IEnumerable<Properties> result = from n in list
                                                 where n.neighborhood.Length != 0
                                                 select n;

            return result;

        }

        public static List<Properties> GetNeighbors(JObject jObject)
        {
            var o = jObject["features"];
            List<Properties> neighbors = new List<Properties>();
            foreach (var item in o)
            {
                Properties pro = new Properties
                {
                  zip = (string)item["properties"]["zip"],
                    city = (string)item["properties"]["city"],
                    state = (string)item["properties"]["state"],
                   address = (string)item["properties"]["address"],
                    borough = (string)item["properties"]["borough"],
                    neighborhood = (string)item["properties"]["neighborhood"],
                    county = (string)item ["properties"]["county"],

                };

                neighbors.Add(pro);

            }
            return neighbors;

        }

        public static JObject GetObj()
        {    
           var stream = File.OpenText("c:/Users/xialiu/codefellows401/lab08-linq/lab8-LINQ/lab8-LINQ/data.json");
            //Read the file              
            string st = stream.ReadToEnd();
            JObject o = JObject.Parse(st);
        return o;
        }






    }
}
