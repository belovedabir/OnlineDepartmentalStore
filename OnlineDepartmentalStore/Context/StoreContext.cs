using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineDepartmentalStore.Models
{
    public class StoreContext : DbContext 
    {
        public StoreContext()
            : base("StoreConnection")
        {

        }

        public System.Data.Entity.DbSet<OnlineDepartmentalStore.Models.Products> Products { get; set; }
    }
}