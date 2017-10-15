using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UlasimApp.API.Models;
using UlasimApp.API.Services;

namespace UlasimApp.API.Controllers
{
    public class StopsController : Controller
    {
        private UlasimApp.API.Models.UlasimAppAPIContext db = new Models.UlasimAppAPIContext();
      
        public ActionResult GetNearbyStops(double lat, double longitude, double distance)
        {

            var stops = db.Stops.ToList();

            var properStops = new List<Stop>();

            foreach(var item in stops)
            {
                if(GeoService.Instance.DistanceTo(lat, longitude, item.Latitude, item.Longitude) <= distance)
                {
                    properStops.Add(item);
                }
            }


            return Json(properStops, JsonRequestBehavior.AllowGet);   

        }
        


    }
}
