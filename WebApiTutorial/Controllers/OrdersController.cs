using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTutorial.Models;

namespace WebApiTutorial.Controllers
{
    public class OrdersController : ApiController
    {
		private WebApiContext db = new WebApiContext();

		[HttpGet]
		public IEnumerable<Order> List() {
			return db.Orders.ToList();
		}

		[HttpGet]
		public Order Get(int? id) {
			if(id == null) return null;
			return db.Orders.Find(id);
		}
		[HttpPost]
		public bool Create(Order order) {
			if(order == null) return false;
			if(!ModelState.IsValid) return false;
			db.Orders.Add(order);
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		public bool Change(Order order) {
			if(order == null) return false;
			if(!ModelState.IsValid) return false;
			db.Orders.Attach(order);
			db.Entry(order).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return true;
		}

		public bool Remove(Order order) {
			if(order == null) return false;
			if(!ModelState.IsValid) return false;
			db.Orders.Attach(order);
			db.Entry(order).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return true;
		}

	}
}
