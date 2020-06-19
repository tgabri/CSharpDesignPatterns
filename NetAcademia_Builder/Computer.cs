using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace NetAcademia_Builder
{
    public class Computer
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Processor Processor { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public OS OS { get; set; }
        public int HDD { get; set; }
        public bool HasDVD { get; set; }
        public bool HasSoundCard { get; set; }
        public bool HasUSB { get; set; }
        public List<string> Applications { get; set; } = new List<string>();

        public void Display()
        {
            Console.WriteLine(JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}