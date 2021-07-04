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
using CDVWebApiv6.Data;
using CDVWebApiv6.Models;

namespace CDVWebApiv6.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductsDB2Context db = new ProductsDB2Context();

        // GET: api/Products
        public IQueryable<Products> GetProducts()
        {
            return db.Products;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Products))]
        public IHttpActionResult GetProducts(int id)
        {
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProducts(int id, Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != products.id)
            {
                return BadRequest();
            }

            db.Entry(products).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
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

        // POST: api/Products
        [ResponseType(typeof(Products))]
        public IHttpActionResult PostProducts(Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(products);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = products.id }, products);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Products))]
        public IHttpActionResult DeleteProducts(int id)
        {
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }

            db.Products.Remove(products);
            db.SaveChanges();

            return Ok(products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductsExists(int id)
        {
            return db.Products.Count(e => e.id == id) > 0;
        }
    }
}