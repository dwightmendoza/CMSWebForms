using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMSUsersAndRoles.Models;
using System.Data.SqlClient;

namespace CMSUsersAndRoles.Controllers
{
    public class InventoriesController : Controller
    {
        private CMSWebFormsContext db = new CMSWebFormsContext();

        // GET: Inventories
        [Authorize]
        public ActionResult Index(string Search)
        {
            if (Search != null)
            {
                return View(db.Inventories.Where(x => x.Name.Contains(Search) || x.SKU.Contains(Search)).ToList());
            }
            else
            {
                return View(db.Inventories.ToList());
            }
        }
        //public ActionResult Index()
        //{
        //    return View(db.Inventories.ToList());
        //}

        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,SKU,Name,Warehouse,Location,OnHand,OnOrder,Committed,Available,Minimum,EOQ,Maximum,StdCost,AvgCost,LastCost,InventoryDate")] Inventory inventory)
        {
            //var test = doesSKUExist(inventory.SKU);
            if (ModelState.IsValid)
            {
                db.Inventories.Add(inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventory);
        }

        [HttpPost]
        public JsonResult doesSKUExist(string Sku)
        {
            string conStr = @"Data Source=cmsapirontech.database.windows.net;Initial Catalog=CMSDatabase;Integrated Security=False;User ID=dwight;Password=Fatboy99!;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlconn = new SqlConnection(conStr);

            SqlCommand does_SKU_exist = new SqlCommand("SELECT SKU FROM [Inventories] WHERE [SKU] = @SKU", sqlconn);
            sqlconn.Open();
            does_SKU_exist.Parameters.Add("@SKU", SqlDbType.VarChar).Value = Sku;
            var sku = does_SKU_exist.ExecuteScalar();
            return Json(sku == null);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,SKU,Name,Warehouse,Location,OnHand,OnOrder,Committed,Available,Minimum,EOQ,Maximum,StdCost,AvgCost,LastCost,InventoryDate")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
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
