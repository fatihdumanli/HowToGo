using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlasimApp.Model
{
    public class Stop
    {
        public int Id { get; set; }

        public string From { get; set; }
        public string To { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public string Latitude { get; set; }

    }
}
