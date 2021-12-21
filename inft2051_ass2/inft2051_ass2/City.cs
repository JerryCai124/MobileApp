using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace inft2051_ass2
{
    //creat city class
    public class city
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Name { get; set; }
    }
}
