using System;
using System.Collections.Generic;
using System.Data.Entity; // DbContext by kütüphane içinde
using System.Linq;
using System.Web;

namespace exp_4_Models.Models
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
        {
            //this.Database.Connection.ConnectionString = "Server=.;Database=Northwind;User Id=sa;Password=123;";
            this.Database.Connection.ConnectionString = "Server=.;Database=Northwind;User Id=sa;Password=Password1;";
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
    }
}

//migration gerektiği durumda yazılacak kodlar;
//enable-migrations
//add-migration Init
//update-database