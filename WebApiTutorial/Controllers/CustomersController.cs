using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTutorial.Models;

namespace WebApiTutorial.Controllers
{
    public class CustomersController : ApiController
    {
		private WebApiContext db = new WebApiContext();

		[HttpGet]
		public IEnumerable<Customer> List() {
			return db.Customers.ToList();
		}
		[HttpGet]
		public Customer Get(int? id) {
			if(id == null) return null;
			return db.Customers.Find(id);
		}
		[HttpPost]
		public bool Create(Customer customer) {
			if(customer == null) return false;
			if(!ModelState.IsValid) return false;
			db.Customers.Add(customer);
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		public bool Change(Customer customer) {
			if(customer == null) return false;
			if(!ModelState.IsValid) return false;
			db.Customers.Attach(customer);
			db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		public bool Remove(Customer customer) {
			if(customer == null) return false;
			if(!ModelState.IsValid) return false;
			db.Customers.Attach(customer);
			db.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return true;
		}

	}
}
