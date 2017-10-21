using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UlasimApp.API.Models;

namespace UlasimApp.API.Controllers
{
    public class UsersController : Controller
    {
        private UlasimApp.API.Models.UlasimAppAPIContext db = new Models.UlasimAppAPIContext();


        public ActionResult GetUserDetails(string email)
        {
            var res = db.Users.Where(u => u.Email == email).SingleOrDefault();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Register(string email, string name, string username,
            string password)
        {
            User u = new User()
            {
                Email = email,
                Name = name,
                Password = password,
                Username = username
            };

            db.Users.Add(u);
            db.SaveChanges();

            return Json("ok");
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var res = db.Users.Where(u => u.Email == email && u.Password == password).SingleOrDefault();
            return Json(res != null);
        }
     
    }
}
