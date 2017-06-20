using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMSUsersAndRoles.Models;

namespace CMSUsersAndRoles.Controllers
{
    public class FormulasController : Controller
    {
        private CMSWebFormsContext db = new CMSWebFormsContext();

        // GET: Formulas
        [Authorize]
        //public ActionResult Index()
        //{
        //    return View(db.Formulae.ToList());
        //}
        public ActionResult Index(string Search)
        {
            if (Search != null)
            {
                return View(db.Formulae.Where(x => x.Name.Contains(Search) || x.SKU.Contains(Search)).ToList());
            }
            else
            {
                return View(db.Formulae.ToList());
            }
        }
        [Authorize(Roles = "Admin, LabView, LabEdit")]
        // GET: Formulas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formula formula = db.Formulae.Find(id);
            formula.Ingredients = db.Ingredients.Where(i => i.ProductId == id).ToList();
            if (formula == null)
            {
                return HttpNotFound();
            }
            return View(formula);
        }

        // GET: Formulas/Create
        public ActionResult Create()
        {
            Formula formula = new Formula();
            formula.Ingredients = new List<Ingredient>();
            formula.Ingredients.Add(new Ingredient() { Name = "Item", Amount = 1, UnitOfMeasure = UnitOfMeasure.oz });
            return View(formula);
        }

        // POST: Formulas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,SKU,Name,Ingredients,Instructions")] Formula formula)
        {
            //formula.Ingredients = new List<Ingredient>();

            if (ModelState.IsValid)
            {
                db.Formulae.Add(formula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formula);
        }
        public ActionResult AddIngredient(int productId, int ingredientId)
        {

            
            return PartialView("EditIngredients", new Ingredient { ProductId = productId, IngredientId = ingredientId });
            //return PartialView("EditIngredients", new Ingredient());

        }

        [HttpPost]
        [ActionName("DeleteIngredient")]
        public ActionResult DeleteIngredient(int productId, int ingredientId)
        {
            Ingredient ingredient = db.Ingredients.FirstOrDefault(o => ((o.ProductId == productId) && (o.IngredientId == ingredientId)));
            //var iName = ingredient.Name;
            if (ingredient != null)
            {
                db.Ingredients.Remove(ingredient);
                db.SaveChanges();
            }

            return Json(true);

          // return RedirectToAction("Edit");
        }

        // GET: Formulas/Edit/5
        [Authorize(Roles = "Admin, LabEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formula formula = db.Formulae.Find(id);
            formula.Ingredients = db.Ingredients.Where(i => i.ProductId == id).ToList();

            foreach (var ingredient in formula.Ingredients)
            {
                if (ingredient.Name == "Item")
                {
                    ingredient.Name = "";
                    ingredient.Amount = 0;
                }
            };
            
            if (formula == null)
            {
                return HttpNotFound();
            }
            return View(formula);
        }

        // POST: Formulas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,[Bind(Include = "ProductId,SKU,Name,Ingredients,Instructions")] Formula formula, [Bind(Include = "ProductId,IngredientId,Name,Amount,UnitofMeasure")] List<Ingredient> ingredients)
        {
            if (ModelState.IsValid)
            {
                 if (formula.Ingredients == null)
                {
                    formula.Ingredients = new List<Ingredient>();
                    formula.Ingredients.Add(new Ingredient() { ProductId = formula.ProductId, IngredientId = formula.Ingredients.Count + 1 });
                    return View(formula);
                     // qvm.QuoteDetail.Add(new QuoteDetail() { QuoteId = qvm.QuoteId, QuoteDetailId = (qvm.QuoteDetail.Count + 1) });
                    // AddIngredient(formula.ProductId, 1);
                    // return PartialView("EditIngredients", new Ingredient { ProductId = formula.ProductId });
                }

                formula.Ingredients.Clear();
                 foreach (var ingredient in ingredients)

                {
                    Ingredient a = db.Ingredients.FirstOrDefault(o => ((o.ProductId == ingredient.ProductId) && (o.IngredientId == ingredient.IngredientId)));
                    //Ingredient a = db.Ingredients.FirstOrDefault(o => ((o.ProductId == ingredients[i].ProductId) && (o.IngredientId == ingredients[i].IngredientId)));
                    if (a != null)
                    {
                        a.Name = ingredient.Name;
                        a.Amount = ingredient.Amount;
                        a.UnitOfMeasure = ingredient.UnitOfMeasure;                   
                    }
                    else
                    {
                        db.Ingredients.Add(ingredient);
                        
                    }
                   
                }
               
                db.Entry(formula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formula);
        }

        // GET: Formulas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formula formula = db.Formulae.Find(id);
            if (formula == null)
            {
                return HttpNotFound();
            }
            return View(formula);
        }

        // POST: Formulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formula formula = db.Formulae.Find(id);
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
