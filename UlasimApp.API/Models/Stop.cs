﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UlasimApp.API.Models
{
    public class Stop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

    }
}