using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UlasimApp.API.Models
{
    public class StopSubscription
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StopId { get; set; }
    }
}