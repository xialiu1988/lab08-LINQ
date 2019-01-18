using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;


namespace lab8_LINQ.Classes
{
    public class Geometry
    {
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("coordinates")]
        public List<double> coordinates { get; set; }

    }
}
