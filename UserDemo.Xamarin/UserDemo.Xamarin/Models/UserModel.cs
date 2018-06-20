using System;
using System.Collections.Generic;
using System.Text;

namespace UserDemo.Xamarin.Models
{
    public class Data
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }

    public class RootObject
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public Data[] data { get; set; }

    }
}
