using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UlasimApp.API.Models
{
    public class UlasimAppAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public UlasimAppAPIContext() : base("name=UlasimAppAPIContext")
        {
        }

        public System.Data.Entity.DbSet<UlasimApp.API.Models.Line> Lines { get; set; }
        public System.Data.Entity.DbSet<UlasimApp.API.Models.Stop> Stops { get; set; }
        public System.Data.Entity.DbSet<UlasimApp.API.Models.User> Users { get; set; }
        public System.Data.Entity.DbSet<UlasimApp.API.Models.StopSubscription> StopSubscriptions { get; set; }

    }
}
