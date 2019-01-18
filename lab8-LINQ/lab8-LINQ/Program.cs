using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            loadJson();
          
        }

        public static void loadJson()
        {    
           var stream = File.OpenText("c:/Users/xialiu/codefellows401/lab08-linq/lab8-LINQ/lab8-LINQ/data.json");
            //Read the file              
            string st = stream.ReadToEnd();
            dynamic item = JsonConvert.DeserializeObject<object>(st);

            JArray array = (JArray)item["features"];

            for (int i = 0; i < array.Count; i++) 
            {
                Properties p = new Properties
                {
                    zip = (string)item["features"][i]["properties"]["zip"],

                    city = (string)item["features"][i]["properties"]["city"],
                    state = (string)item["features"][i]["properties"]["state"],
                    address = (string)item["features"][i]["properties"]["address"],
                    borough = (string)item["features"][i]["properties"]["zip"],
                    neighborhood = (string)item["features"][i]["properties"]["neighborhood"],
                    county = (string)item["features"][i]["properties"]["county"],
                };


            }

           List<Properties> mm= CreateFieldsList(array);

            foreach (var item3 in mm)
            {
                Console.WriteLine(item3.neighborhood);
            }

        }

        private static List<Properties> CreateFieldsList(JArray fieldsArray)
        {
            return fieldsArray.Select(
              x => new Properties
              {
                  neighborhood = (string)x["features"][0]["properties"]["neighborhood"],
              
              }).ToList();
        }
    }
}
