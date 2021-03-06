using MvcNgDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MvcNgDemo.Controllers
{
    [RoutePrefix("api/Customers")]
    public class CustomersController : ApiController
    {
        private DoFactoryContext db = new DoFactoryContext();

        // GET: api/Customers
        [Route("GetCustomers")]
        public IHttpActionResult GetCustomers()
        {
            return Json(db.Customers.Select(c => new { c.Id, c.FirstName, c.LastName, c.Phone, c.City, c.Country }).ToList());
        }

        // GET: api/Customers/5
        [Route("GetCustomer/{id}")]
        //[ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = db.Customers.Find(id);//Where(c => c.Id == id);//.Select(c => new { c.Id, c.FirstName, c.LastName, c.Phone, c.City, c.Country });

            return Json(new { customer.Id, customer.FirstName, customer.LastName, customer.Phone, customer.City, customer.Country });
            //Customer customer = db.Customers.Find(id);
            //if (customer == null)
            //{
            //    return NotFound();
            //}

            //return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }
    }
}
