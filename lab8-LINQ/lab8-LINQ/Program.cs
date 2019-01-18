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
            Print(list);//Output all of the neighborhoods in this data list
            IEnumerable<Properties> result=FillterOutNoNameNeighbors(list); // Filter out all the neighborhoods that do not have any names
            Console.WriteLine("===============");
            Console.WriteLine("===============");
            Console.WriteLine("===============");
            Print(result);
            Console.WriteLine("===============");
            Console.WriteLine("===============");
            Console.WriteLine("===============");
            RomoveDuplicate(list);  // Remove the Duplicates :ouput the unique neighborhoods
            Console.WriteLine("===============");
            Console.WriteLine("===============");
            Console.WriteLine("===============");

            //rewrite FillterOutNoNameNeighbors above using lamda,one single query
            IEnumerable < Properties > res = FillterOutNoNameNeighborsLamda(list);
            Print(res);
        }
        /// <summary>
        /// while loop traverse the list to see if any two items are same
        /// </summary>
        /// <param name="list"></param>
      public static void RomoveDuplicate(List<Properties> list)
        {
            int i = 0;
            List<string> distinctElements = new List<string>();
            while (i < list.Count)
            {
                if (!distinctElements.Contains(list[i].neighborhood))
                    distinctElements.Add(list[i].neighborhood);
                i++;
            }

            foreach (var item in distinctElements)
            {
                Console.WriteLine(item);
                
            }

          
            }



        public static void Print(IEnumerable<Properties> result)
        {
            foreach (Properties n in result)
            {

                Console.WriteLine($" {n.neighborhood}");

            }
        }



        public static void Print(List<Properties> list)
        {
            foreach (Properties n in list)
            {
                
                Console.WriteLine($" {n.neighborhood}");

            }
        }

        /// <summary>
        /// LINQ to query from the list 
        /// </summary>
        /// <param name="list"></param>
        /// <returns>new list</returns>
        public static IEnumerable<Properties> FillterOutNoNameNeighbors(List<Properties> list)
        {
            IEnumerable<Properties> result = from n in list
                                                 where n.neighborhood.Length != 0
                                                 select n;

            return result;

        }

        /// <summary>
        /// rewrite--using lambda
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<Properties> FillterOutNoNameNeighborsLamda(List<Properties> list)
        {
            var result = list.Where((n) =>  n.neighborhood.Length != 0);
         

            return result;

        }





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
