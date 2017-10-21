using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UlasimApp.Services;

namespace UlasimApp.Model
{
    public class Stop
    {
        public int Id { get; set; }
        public int LineId { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Line Line
        {
            get
            {
                return Task.Run(async () => await LocationService.Instance.GetLineDetails(LineId)).Result;
            }
        }

    }
}


