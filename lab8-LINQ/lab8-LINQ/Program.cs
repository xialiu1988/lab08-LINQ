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

           List<Properties> list= GetNeighbors(GetObj());//get all the information from the data.json file

            //Output all of the neighborhoods in this data list
            var query1 = from f in list
                        select f.neighborhood;
            foreach(var fea in query1)
            {
                Console.WriteLine(fea);
            }

            Console.WriteLine("===============");
            Console.WriteLine("===============");
            Console.WriteLine("===============");
            // Filter out all the neighborhoods that do not have any names
            var query2 = from f in query1
                         where f != ""
                         select f;

    
            foreach (var fea in query2)
            {
                Console.WriteLine(fea);
            }
            // IEnumerable < Properties > result = FillterOutNoNameNeighbors(list); 

            
            Console.WriteLine("===============");
            Console.WriteLine("===============");
            Console.WriteLine("===============");

            // Remove the Duplicates :ouput the unique neighborhoods
            var query3 = query2
                        .Distinct();

            foreach (var fea in query3)
            {
                Console.WriteLine(fea);
            }


            Console.WriteLine("===============");
            Console.WriteLine("===============");
            Console.WriteLine("===============");
            //rewrite all the queries above into one single query
            var query4 = list.Where(n => n.neighborhood.Length > 0)
                       .GroupBy(g => g.neighborhood)
                       .Select(s => s.First());


            foreach (var item in query4)
            {
                Console.WriteLine(item.neighborhood);
            }


            Console.WriteLine("===============");
            Console.WriteLine("===============");
            Console.WriteLine("===============");
            //rewrite FillterOutNoNameNeighbors above using lamda,one single query

            var query5= list.Where((n) => n.neighborhood.Length != 0);

            foreach (var item in query5)
            {
                Console.WriteLine(item.neighborhood);
            }

        
        }
       
      /// <summary>
      /// get a list of Properties type of objects created
      /// </summary>
      /// <param name="jObject"></param>
      /// <returns></returns>

        public static List<Properties> GetNeighbors(JObject jObject)
        {
            var o = jObject["features"];
            //create a new list type is Properties, is empty ,waiting to be added 
            List<Properties> neighbors = new List<Properties>();
          
            foreach (var item in o)
            { //start create net Properties type of object
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

                neighbors.Add(pro);//add this new object to the list

            }
            return neighbors;

        }

    
        /// <summary>
        /// get object o from JSON file       
        /// </summary>
        /// <returns></returns>
        public static JObject GetObj()
        {    
           var stream = File.OpenText("../../../data.json");
            //Read the file              
            string st = stream.ReadToEnd();
            JObject o = JObject.Parse(st);
        return o;
        }

    }
}
