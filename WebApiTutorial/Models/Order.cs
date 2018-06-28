using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTutorial.Models {
	public class Order {
		public int Id { get; set; }
		public string Vendor { get; set; }
		public string Product { get; set; }
		public double Price { get; set; }
		public int CustomerId { get; set; }
		public virtual Customer Customer { get; set; }

		public Order() {

		}
	}
}