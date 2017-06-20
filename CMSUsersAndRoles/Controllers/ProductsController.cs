using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMSUsersAndRoles.Models;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace CMSUsersAndRoles.Controllers
{
    public class ProductsController : Controller
    {
        private CMSWebFormsContext db = new CMSWebFormsContext();

        // GET: Products
        [Authorize]
        public ActionResult Index(string Search)
        {
            if (Search != null)
            {
                return View(db.Products.Where(x => x.Name.Contains(Search) || x.SKU.Contains(Search)).ToList());
            }
            else
            {
                return View(db.Products.ToList());
            }
        }
       

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "ProductId,SKU,Name,Description,ProductType,UnitOfMeasure,SalesQuantity,Container,Hazardous,Warehouse,Price")] Product product, [Bind(Include = "ProductId,SKU,Location,OnHand,OnOrder,Committed,Available,Minimum,EOQ,Maximum,StdCost,AvgCost,LastCost,InventoryDate")] Inventory inventory, [Bind(Include = "ProductId,SKU,Name,Ingredients,Instructions")] Formula formula)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                inventory.ProductId = product.ProductId;
                inventory.SKU = product.SKU;
                inventory.Name = product.Name;
                inventory.Warehouse = product.Warehouse;
                db.Inventories.Add(inventory);
                formula.ProductId = product.ProductId;
                formula.SKU = product.SKU;
                formula.Name = product.Name;
                formula.Ingredients = new List<Ingredient> { new Ingredient { Name = "Item", Amount = 1, UnitOfMeasure = UnitOfMeasure.ml } };
                db.Formulae.Add(formula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpPost]
        public JsonResult doesSKUExist(string Sku)
        {
            string conStr = @"Data Source=cmsapirontech.database.windows.net;Initial Catalog=CMSDatabase;Integrated Security=False;User ID=dwight;Password=Fatboy99!;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlconn = new SqlConnection(conStr);

            SqlCommand does_SKU_exist = new SqlCommand("SELECT SKU FROM [Products] WHERE [SKU] = @SKU", sqlconn);
            sqlconn.Open();
            does_SKU_exist.Parameters.Add("@SKU", SqlDbType.VarChar).Value = Sku;
            var sku = does_SKU_exist.ExecuteScalar();
            return Json(sku == null);
        }

        //public JsonResult doesSKUExist(string Sku, string initialSku)
        //{
        //    string conStr = @"Data Source=cmsapirontech.database.windows.net;Initial Catalog=CMSDatabase;Integrated Security=False;User ID=dwight;Password=Fatboy99!;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //    SqlConnection sqlconn = new SqlConnection(conStr);

        //    SqlCommand does_SKU_exist = new SqlCommand("SELECT SKU FROM [Products] WHERE [SKU] = @SKU", sqlconn);
        //    sqlconn.Open();
        //    does_SKU_exist.Parameters.Add("@SKU", SqlDbType.VarChar).Value = Sku;
        //    var sku = does_SKU_exist.ExecuteScalar();
        //    return Json(sku==null, JsonRequestBehavior.AllowGet);
        //}



        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,SKU,Name,Description,ProductType,UnitOfMeasure,SalesQuantity,Container,Hazardous,Warehouse,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
               // db.SaveChanges();
                //added do while
                //bool saveFailed;
                //do
                //{
                //    saveFailed = false;
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                //        saveFailed = true;

                        // Update original values from the database 
                        var entry = ex.Entries.Single();
                        entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                    }

                //} while (saveFailed);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin, Database Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            //db.SaveChanges();
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
            Formula formula = db.Formulae.Find(id);
            List<Ingredient> ingredients = db.Ingredients.Where(o => (o.ProductId == id)).ToList();
            foreach (var ingredient in ingredients)
            {
                db.Ingredients.Remove(ingredient);
            }
            db.Formulae.Remove(formula);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
