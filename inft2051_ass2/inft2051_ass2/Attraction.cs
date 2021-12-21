using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace inft2051_ass2
{
    //creat attraction class
    public class Attraction
    {
        [PrimaryKey]
        public int id { get; set; }
        public string Name { get; set; }
        public int belong_to_city { get; set; }
        public string img_name { get; set; }
        public string introduction { get; set; }
        //public string address { get; set; }
    }
}
