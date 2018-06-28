using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiTutorial.Models {
	public class WebApiContext : DbContext {
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }

		public WebApiContext() : base() { }
	}
}