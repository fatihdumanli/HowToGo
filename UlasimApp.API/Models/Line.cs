using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UlasimApp.API.Models
{
    public class Line
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUri { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
    }
}