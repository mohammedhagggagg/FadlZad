using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using FadlZ.Models;

namespace FadlZ.Controllers
{
    //[Authorize]
    public class ProductsController : ApiController
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Products
        [Authorize]
        public List<Product> Getproducts()
        {
            try
            {
            return db.products.ToList();
            } catch
            {
                return null ;
            }
            

        }

        
        // GET: api/Products/5
        [Authorize]
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(string id)
        {
            Product product = db.products.FirstOrDefault(d =>d.Pro_ID==id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        // PUT: api/Products/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(string id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Pro_ID)
            {
                return BadRequest();
            }


            try
            {
            db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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
        [Authorize]
        [HttpPost]
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(  string Pro_Name, string Pro_Description, string Pro_Type,HttpPostedFileBase Pro_Image )
        {
            Product product = new Product();
            product.Pro_Name = Pro_Name;
            product.Pro_Type = Pro_Type;
            product.Pro_Description = Pro_Description;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            product.Pro_ID = Guid.NewGuid().ToString();
            string path = System.Web.HttpContext.Current.Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Fetch the File.
             
            try
            {
                HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];
                string fileName = Path.GetFileName(postedFile.FileName);
                postedFile.SaveAs(path + product.Pro_ID);
            }
            catch (Exception ex)
            {

                return BadRequest("Error in Image and exception is " + ex.Message);
            }
           

            //Fetch the File Name.
            

            //Save the File.
            
            product.Pro_Image= product.Pro_ID+".jpeg";
            

            try
            {
                db.products.Add(product);

                db.SaveChanges();
            }
            catch (Exception ex )
            {
                if (ProductExists(product.Pro_ID))
                { 
                    return Conflict();
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = product.Pro_ID }, product);
        }

        // DELETE: api/Products/5
        [Authorize]
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(string id)
        {
            Product product = db.products.FirstOrDefault(i=>i.Pro_ID==id);
            if (product == null)
            {
                return NotFound();
            }
            try
            {
            db.products.Remove(product);
            db.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }    
            
            return Ok("Deleted Succefully");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(string id)
        {
            return db.products.Count(e => e.Pro_ID == id) > 0;
        }
    }
}