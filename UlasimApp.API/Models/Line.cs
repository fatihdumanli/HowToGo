using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UlasimApp.API.Models
{
    public class Line
    {
        public int Id { get; set; }
        public int FromId { get; set; }

        public string From { get; set; }
        public string To { get; set; }

    }
}