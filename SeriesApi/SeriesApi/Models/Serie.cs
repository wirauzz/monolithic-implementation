using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriesApi.Models
{
    public class Serie
    {
        public int id { get; set; }
        public string name { get; set; }
        public string gnre { get; set; }
        public int rate { get; set; }
        public int seasons { get; set; }
    }
}
