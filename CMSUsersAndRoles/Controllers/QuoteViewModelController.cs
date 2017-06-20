using CMSUsersAndRoles.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CMSUsersAndRoles.Controllers
{
    public class QuoteViewModelController : Controller
    {
        private CMSWebFormsContext db = new CMSWebFormsContext();
        private QuoteViewModel qvm = new QuoteViewModel();       
        
        [Authorize]
        // GET: QuoteViewModel
        public ActionResult Index(string Search)
        {
            var qvmList = (from c in db.Customers
                           join q in db.Quotes on c.CustomerId equals q.CustomerId
                           join qd in db.QuoteDetails on q.QuoteId equals qd.QuoteId into quoteDetailGroup
                           select new
                           {
                               c.FirstName,
                               c.LastName,
                               c.Company,
                               c.Address1,
                               c.Address2,
                               c.City,
                               c.State,
                               c.PostalCode,
                               c.WorkPhone,
                               c.CellPhone,
                               c.Email,
                               c.Discount,
                               c.PaymentTerms,
                               c.SalesRep,
                               q.QuoteId,
                               q.DeliveryAddressPhone,
                               q.DeliveryAddressEmail,
                               q.DateApproved,
                               q.DateOrdered,
                               q.GoodUntil,
                               q.QuoteDate,
                               q.QuoteSent,
                               q.Subtotal,
                               q.Tax,
                               q.Total,
                               quoteDetailGroup
                           }
                          ).ToList().Select(r => new QuoteViewModel
                          {
                              FirstName = r.FirstName,
                              LastName = r.LastName,
                              Company = r.Company,
                              Address1 = r.Address1,
                              Address2 = r.Address2,
                              City = r.City,
                              State = r.State,
                              PostalCode = r.PostalCode,
                              WorkPhone = r.WorkPhone,
                              CellPhone = r.CellPhone,
                              Email = r.Email,
                              Discount = r.Discount,
                              PaymentTerms = r.PaymentTerms,
                              SalesRep = r.SalesRep,
                              QuoteId = r.QuoteId,
                              DeliveryAddressPhone = r.DeliveryAddressPhone,
                              DeliveryAddressEmail = r.DeliveryAddressEmail,
                              QuoteDate = r.QuoteDate,
                              Tax = r.Tax,
                              GoodUntil = r.GoodUntil,
                              Total = r.Total,
                              DateApproved = r.DateApproved,
                              DateOrdered = r.DateOrdered,
                              QuoteSent = r.QuoteSent,
                              QuoteDetail = r.quoteDetailGroup.DefaultIfEmpty(new QuoteDetail { QuoteId = 1, QuoteDetailId = 1, ProductId = 1, Amount = 1, Discount = 0, ListPrice = 0, ProductName = "item", Price = 0 }).ToList()

                          });        

            if (Search != null)
            {
                var quoteList = qvmList.Where(x => x.Company.Contains(Search) || x.SalesRep.Contains(Search)).ToList();
               
                return View(quoteList);
            }
            else
            {
                return View(qvmList);
            }
        }

        public ActionResult Create()
        {
            QuoteViewModel qvm = new QuoteViewModel();
            qvm.QuoteDetail = new List<QuoteDetail>();
            qvm.QuoteDetail.Add(new QuoteDetail() { QuoteId = qvm.QuoteId, QuoteDetailId = (qvm.QuoteDetail.Count + 1), Discount = 0 });

            var customers = db.Customers.ToList();
            ViewBag.Customers = customers;

            var items = db.Products.ToList();
            ViewBag.ProductData = items;

            return View(qvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       public ActionResult Create(QuoteViewModel qvm)
        {
            //if (qvm.QuoteDetail == null)
            //{
            //    qvm.QuoteDetail = new List<QuoteDetail>();
            //    qvm.QuoteDetail.Add(new QuoteDetail() { QuoteId = qvm.QuoteId, QuoteDetailId = (qvm.QuoteDetail.Count + 1) });
            //    var customerList = db.Customers.ToList();
            //    ViewBag.Customers = customerList;
            //    return View(qvm);
            //}

            if (ModelState.IsValid)
            {

                foreach (var quoteDetail in qvm.QuoteDetail)
                {

                    QuoteDetail qd = db.QuoteDetails.FirstOrDefault(o => ((o.QuoteId == quoteDetail.QuoteId) && (o.QuoteDetailId == quoteDetail.QuoteDetailId)));

                    if (qd != null)
                    {
                        qd.ProductId = quoteDetail.ProductId;
                        qd.ProductName = quoteDetail.ProductName;
                        qd.Amount = quoteDetail.Amount;
                        qd.ListPrice = quoteDetail.ListPrice;
                        qd.Discount = quoteDetail.Discount;
                        qd.Price = quoteDetail.Price;
                    }
                    else
                    {
                        db.QuoteDetails.Add(quoteDetail);
                    }

                }
                Quote quote1 = new Quote();

                quote1.CustomerId = qvm.CustomerId;
                quote1.SalesRep = qvm.SalesRep;
                quote1.DeliveryAddressContact = qvm.DeliveryAddressContact;
                quote1.DeliveryAddressCompany = qvm.DeliveryAddressCompany;
                quote1.DeliveryAddressStreet1 = qvm.DeliveryAddressStreet1;
                quote1.DeliveryAddressStreet2 = qvm.DeliveryAddressStreet2;
                quote1.DeliveryAddressCity = qvm.DeliveryAddressCity;
                quote1.DeliveryAddressState = qvm.DeliveryAddressState;
                quote1.DeliveryAddressZip = qvm.DeliveryAddressZip;
                quote1.DeliveryAddressPhone = qvm.DeliveryAddressPhone;
                quote1.DeliveryAddressAltPhone = qvm.DeliveryAddressAltPhone;
                quote1.DeliveryAddressEmail = qvm.DeliveryAddressEmail;
                quote1.QuoteDate = qvm.QuoteDate;
                quote1.GoodUntil = qvm.GoodUntil;
                quote1.Subtotal = qvm.Subtotal;
                quote1.Tax = qvm.Tax;
                quote1.Total = qvm.Total;

                db.Quotes.Add(quote1);

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        var objContext = ((IObjectContextAdapter)db).ObjectContext;
                        // Get failed entry
                        var entry = ex.Entries.Single();
                        // Now call refresh on ObjectContext
                        objContext.Refresh(RefreshMode.ClientWins, entry.Entity);
                    }

                return RedirectToAction("Index");
            }

            var customers = db.Customers.ToList();
            ViewBag.Customers = customers;

            var items = db.Products.ToList();
            ViewBag.ProductData = items;

            return View(qvm);
        }
    
    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            var qvmList = (from c in db.Customers
                           join q in db.Quotes on c.CustomerId equals q.CustomerId
                           join qd in db.QuoteDetails on q.QuoteId equals qd.QuoteId into quoteDetailGroup
                           select new
                           {
                               c.FirstName,
                               c.LastName,
                               c.Company,
                               c.Address1,
                               c.Address2,
                               c.City,
                               c.State,
                               c.PostalCode,
                               c.WorkPhone,
                               c.CellPhone,
                               c.Email,
                               c.Discount,
                               c.PaymentTerms,
                               c.SalesRep,
                               q.QuoteId,
                               q.DeliveryAddressCompany,
                               q.DeliveryAddressContact,
                               q.DeliveryAddressStreet1,
                               q.DeliveryAddressStreet2,
                               q.DeliveryAddressCity,
                               q.DeliveryAddressState,
                               q.DeliveryAddressZip,
                               q.DeliveryAddressPhone,
                               q.DeliveryAddressAltPhone,
                               q.DeliveryAddressEmail,
                               q.DateApproved,
                               q.DateOrdered,
                               q.GoodUntil,
                               q.QuoteDate,
                               q.QuoteSent,
                               q.Subtotal,
                               q.Tax,
                               q.Total,
                               quoteDetailGroup
                           }
                          ).ToList().Select(r => new QuoteViewModel
                          {
                              FirstName = r.FirstName,
                              LastName = r.LastName,
                              Company = r.Company,
                              Address1 = r.Address1,
                              Address2 = r.Address2,
                              City = r.City,
                              State = r.State,
                              PostalCode = r.PostalCode,
                              WorkPhone = r.WorkPhone,
                              CellPhone = r.CellPhone,
                              Email = r.Email,
                              Discount = r.Discount,
                              PaymentTerms = r.PaymentTerms,
                              SalesRep = r.SalesRep,
                              QuoteId = r.QuoteId,
                              DeliveryAddressCompany = r.DeliveryAddressCompany,
                              DeliveryAddressContact = r.DeliveryAddressContact,
                              DeliveryAddressStreet1 = r.DeliveryAddressStreet1,
                              DeliveryAddressStreet2 = r.DeliveryAddressStreet2,
                              DeliveryAddressCity = r.DeliveryAddressCity,
                              DeliveryAddressState = r.DeliveryAddressState,
                              DeliveryAddressZip = r.DeliveryAddressZip,
                              DeliveryAddressPhone = r.DeliveryAddressPhone,
                              DeliveryAddressAltPhone = r.DeliveryAddressAltPhone,
                              DeliveryAddressEmail = r.DeliveryAddressEmail,
                              QuoteDate = r.QuoteDate,
                              Subtotal = r.Subtotal,
                              Tax = r.Tax,
                              GoodUntil = r.GoodUntil,
                              Total = r.Total,
                              DateApproved = r.DateApproved,
                              DateOrdered = r.DateOrdered,
                              QuoteSent = r.QuoteSent,
                              QuoteDetail = r.quoteDetailGroup.DefaultIfEmpty(new QuoteDetail { QuoteId = 1, QuoteDetailId = 1, ProductId = 1, Amount = 1, Discount = 0, ListPrice = 0, ProductName = "item", Price = 0 }).ToList()

                          });

            QuoteViewModel qvm = (QuoteViewModel)qvmList.Where(q => q.QuoteId == id).FirstOrDefault();
            qvm.QuoteDetail = db.QuoteDetails.Where(i => i.QuoteId == id).ToList();

            if (qvm == null)
            {
                return HttpNotFound();
            }
            return View(qvm);
        }
        // GET: QuoteViewModel/Edit/5
        [Authorize(Roles = "Admin, SalesEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var qvmList = (from c in db.Customers
                           join q in db.Quotes on c.CustomerId equals q.CustomerId
                           join qd in db.QuoteDetails on q.QuoteId equals qd.QuoteId into quoteDetailGroup
                           select new
                           {
                               c.CustomerId,
                               c.FirstName,
                               c.LastName,
                               c.Company,
                               c.Address1,
                               c.Address2,
                               c.City,
                               c.State,
                               c.PostalCode,
                               c.WorkPhone,
                               c.CellPhone,
                               c.Email,
                               c.Discount,
                               c.PaymentTerms,
                               c.SalesRep,
                               q.QuoteId,
                               q.DeliveryAddressCompany,
                               q.DeliveryAddressContact,
                               q.DeliveryAddressStreet1,
                               q.DeliveryAddressStreet2,
                               q.DeliveryAddressCity,
                               q.DeliveryAddressState,
                               q.DeliveryAddressZip,
                               q.DeliveryAddressPhone,
                               q.DeliveryAddressAltPhone,
                               q.DeliveryAddressEmail,
                               q.DateApproved,
                               q.DateOrdered,
                               q.GoodUntil,
                               q.QuoteDate,
                               q.QuoteSent,
                               q.Subtotal,
                               q.Tax,
                               q.Total,
                               quoteDetailGroup
                           }
                          ).ToList().Select(r => new QuoteViewModel
                          {
                              CustomerId = r.CustomerId,
                              FirstName = r.FirstName,
                              LastName = r.LastName,
                              Company = r.Company,
                              Address1 = r.Address1,
                              Address2 = r.Address2,
                              City = r.City,
                              State = r.State,
                              PostalCode = r.PostalCode,
                              WorkPhone = r.WorkPhone,
                              CellPhone = r.CellPhone,
                              Email = r.Email,
                              Discount = r.Discount,
                              PaymentTerms = r.PaymentTerms,
                              SalesRep = r.SalesRep,
                              QuoteId = r.QuoteId,
                              DeliveryAddressCompany = r.DeliveryAddressCompany,
                              DeliveryAddressContact = r.DeliveryAddressContact,
                              DeliveryAddressStreet1 = r.DeliveryAddressStreet1,
                              DeliveryAddressStreet2 = r.DeliveryAddressStreet2,
                              DeliveryAddressCity = r.DeliveryAddressCity,
                              DeliveryAddressState = r.DeliveryAddressState,
                              DeliveryAddressZip = r.DeliveryAddressZip,
                              DeliveryAddressPhone = r.DeliveryAddressPhone,
                              DeliveryAddressAltPhone = r.DeliveryAddressAltPhone,
                              DeliveryAddressEmail = r.DeliveryAddressEmail,
                              QuoteDate = r.QuoteDate,
                              GoodUntil = r.GoodUntil,
                              Subtotal = r.Subtotal,
                              Tax = r.Tax,
                              Total = r.Total,
                              DateApproved = r.DateApproved,
                              DateOrdered = r.DateOrdered,
                              QuoteSent = r.QuoteSent,
                              QuoteDetail = r.quoteDetailGroup.DefaultIfEmpty(new QuoteDetail { QuoteId = 1, QuoteDetailId = 1, ProductId = 1, Amount = 1, Discount = 0, ListPrice = 0, ProductName = "item", Price = 0 }).ToList()

                          });

            QuoteViewModel qvm = (QuoteViewModel)qvmList.Where(q => q.QuoteId == id).FirstOrDefault();
            qvm.QuoteDetail = db.QuoteDetails.Where(i => i.QuoteId == id).ToList();

            var items = db.Products.ToList();
            ViewBag.ProductData = items;

            if (qvm == null)
            {
                return HttpNotFound();
            }
            return View(qvm);
        }
        public ActionResult AddProduct(int quoteId, int quoteDetailId)
        {
            var items = db.Products.ToList();
            ViewBag.ProductData = items;

            return PartialView("EditQuoteDetail", new QuoteDetail { QuoteId = quoteId, QuoteDetailId = quoteDetailId });
        }

        [HttpGet]
        public ActionResult DisplayCustomerAddress()
        {
            return PartialView("DisplayCustomerAddress");
        }

        [HttpPost]
        public ActionResult GetCustomer(int custId)
        {
            var data = db.Customers.Find(custId);
            return Json(data);
        }

        [HttpPost]
        public ActionResult GetProduct(int pId)
        {
            var data = db.Products.Find(pId);
            return Json(data);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int quoteId, int quoteDetailId)
        {
            QuoteDetail quoteDetail = db.QuoteDetails.FirstOrDefault(p => ((p.QuoteId == quoteId) && (p.QuoteDetailId == quoteDetailId)));
      
            if (quoteDetail != null)
            {
                db.QuoteDetails.Remove(quoteDetail);
                db.SaveChanges();
            }

            return Json(true);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuoteViewModel qvm, /*[Bind(Include = "CustomerId,SalesRep,FirstName,LastName,Company,Address1,Address2,City,State,PostalCode,WorkPhone,CellPhone,Email,Discount,PaymentTerms")] Customer customer,*/
                                 [Bind(Include = "QuoteId,QuoteDetailId,ProductId,ProductName,Amount,ListPrice,Discount,Price")] List<QuoteDetail> quoteDetails,
                                 [Bind(Include = "QuoteId,CustomerId,DeliveryAddressCompany,DeliveryAddressContact,DeliveryAddressStreet1,DeliveryAddressStreet2,DeliveryAddressCity,DeliveryAddressState,DeliveryAddressZip,DeliveryAddressPhone,DeliveryAddressAltPhone,DeliveryAddressEmail,Subtotal,Tax,Total,QuoteDate,GoodUntil,QuoteSent,DateApproved,DateOrdered")] Quote quote)
        //public ActionResult Edit(QuoteViewModel qvm)
        {
            //if (qvm.QuoteDetail == null)
            //{
            //    qvm.QuoteDetail = new List<QuoteDetail>();
            //    qvm.QuoteDetail.Add(new QuoteDetail() { QuoteId = qvm.QuoteId, QuoteDetailId = (qvm.QuoteDetail.Count + 1) });
            //    var itemList = db.Products.ToList();
            //    ViewBag.ProductData = itemList;
            //    return View(qvm);
            //}

            if (!ModelState.IsValid)
            {
                string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            }

            if (ModelState.IsValid)
            {
                
                foreach (var quoteDetail in qvm.QuoteDetail)
                {

                    QuoteDetail qd = db.QuoteDetails.FirstOrDefault(o => ((o.QuoteId == quoteDetail.QuoteId) && (o.QuoteDetailId == quoteDetail.QuoteDetailId)));

                    if (qd != null)
                    {
                        qd.ProductId = quoteDetail.ProductId;
                        qd.ProductName = quoteDetail.ProductName;
                        qd.Amount = quoteDetail.Amount;
                        qd.ListPrice = quoteDetail.ListPrice;
                        qd.Discount = quoteDetail.Discount;
                        qd.Price = quoteDetail.Price;
                    }
                    else
                    {
                        db.QuoteDetails.Add(quoteDetail);
                    }
                    
                }

                quote.QuoteId = qvm.QuoteId;
                quote.DeliveryAddressCompany = qvm.DeliveryAddressCompany;
                quote.DeliveryAddressContact = qvm.DeliveryAddressContact;
                quote.DeliveryAddressStreet1 = qvm.DeliveryAddressStreet1;
                quote.DeliveryAddressStreet2 = qvm.DeliveryAddressStreet2;
                quote.DeliveryAddressCity = qvm.DeliveryAddressCity;
                quote.DeliveryAddressState = qvm.DeliveryAddressState;
                quote.DeliveryAddressZip = qvm.DeliveryAddressZip;
                quote.DeliveryAddressPhone = qvm.DeliveryAddressPhone;
                quote.DeliveryAddressAltPhone = qvm.DeliveryAddressAltPhone;
                quote.DeliveryAddressEmail = qvm.DeliveryAddressEmail;
                quote.GoodUntil = qvm.GoodUntil;  
                quote.DateApproved = qvm.DateApproved;
                quote.DateOrdered = qvm.DateOrdered;
                quote.QuoteDate = qvm.QuoteDate;
                quote.QuoteSent = qvm.QuoteSent;
                quote.Subtotal = qvm.Subtotal;
                quote.Tax = qvm.Tax;
                quote.Total = qvm.Total;

               
               
                db.Entry(quote).State = EntityState.Modified;
               
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                       
                        var objContext = ((IObjectContextAdapter)db).ObjectContext;
                        // Get failed entry
                        var entry = ex.Entries.Single();
                        // Now call refresh on ObjectContext
                        objContext.Refresh(RefreshMode.ClientWins, entry.Entity);

                       
                    }

               
              
                return RedirectToAction("Index");
            }
            var items = db.Products.ToList();
            ViewBag.ProductData = items;

            return View(qvm);
        }
        // GET: QuoteViewModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var qvmList = (from q in db.Quotes
                           join qd in db.QuoteDetails on q.QuoteId equals qd.QuoteId into quoteDetailGroup
                           select new
                           {
                               
                               q.QuoteId,
                               q.SalesRep,
                               q.DeliveryAddressCompany,
                               q.DeliveryAddressContact,
                               q.DeliveryAddressStreet1,
                               q.DeliveryAddressStreet2,
                               q.DeliveryAddressCity,
                               q.DeliveryAddressState,
                               q.DeliveryAddressZip,
                               q.DeliveryAddressPhone,
                               q.DeliveryAddressAltPhone,
                               q.DeliveryAddressEmail,
                               q.DateApproved,
                               q.DateOrdered,
                               q.GoodUntil,
                               q.QuoteDate,
                               q.QuoteSent,
                               q.Subtotal,
                               q.Tax,
                               q.Total,
                               quoteDetailGroup
                           }
                          ).ToList().Select(r => new QuoteViewModel
                          {
                              QuoteId = r.QuoteId,
                              SalesRep = r.SalesRep,
                              DeliveryAddressCompany = r.DeliveryAddressCompany,
                              DeliveryAddressContact = r.DeliveryAddressContact,
                              DeliveryAddressStreet1 = r.DeliveryAddressStreet1,
                              DeliveryAddressStreet2 = r.DeliveryAddressStreet2,
                              DeliveryAddressCity = r.DeliveryAddressCity,
                              DeliveryAddressState = r.DeliveryAddressState,
                              DeliveryAddressZip = r.DeliveryAddressZip,
                              DeliveryAddressPhone = r.DeliveryAddressPhone,
                              DeliveryAddressAltPhone = r.DeliveryAddressAltPhone,
                              DeliveryAddressEmail = r.DeliveryAddressEmail,
                              QuoteDate = r.QuoteDate,
                              Subtotal = r.Subtotal,
                              Tax = r.Tax,
                              GoodUntil = r.GoodUntil,
                              Total = r.Total,
                              DateApproved = r.DateApproved,
                              DateOrdered = r.DateOrdered,
                              QuoteSent = r.QuoteSent,
                              QuoteDetail = r.quoteDetailGroup.DefaultIfEmpty(new QuoteDetail { QuoteId = 1, QuoteDetailId = 1, ProductId = 1, Amount = 1, Discount = 0, ListPrice = 0, ProductName = "item", Price = 0 }).ToList()

                          });

            QuoteViewModel qvm = (QuoteViewModel)qvmList.Where(q => q.QuoteId == id).FirstOrDefault();
            qvm.QuoteDetail = db.QuoteDetails.Where(i => i.QuoteId == id).ToList();

            if (qvm == null)
            {
                return HttpNotFound();
            }
            return View(qvm);
        }

        // POST: Formulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            qvm.QuoteDetail = db.QuoteDetails.Where(i => i.QuoteId == id).ToList();
            foreach (var quoteDetail in qvm.QuoteDetail)
            {
                db.QuoteDetails.Remove(quoteDetail);
            }

            Quote quote = db.Quotes.Find(id);
            db.Quotes.Remove(quote);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Order(int? id)
        {
            OrderViewModel ovm = new OrderViewModel();
            ovm.OrderDetail = new List<OrderDetail>();

            var qvmList = (from c in db.Customers
                           join q in db.Quotes on c.CustomerId equals q.CustomerId
                           join qd in db.QuoteDetails on q.QuoteId equals qd.QuoteId into quoteDetailGroup
                           select new
                           {
                               c.FirstName,
                               c.LastName,
                               c.Company,
                               c.Address1,
                               c.Address2,
                               c.City,
                               c.State,
                               c.PostalCode,
                               c.WorkPhone,
                               c.CellPhone,
                               c.Email,
                               c.Discount,
                               c.PaymentTerms,
                               c.SalesRep,
                               q.QuoteId,
                               q.DeliveryAddressCompany,
                               q.DeliveryAddressContact,
                               q.DeliveryAddressStreet1,
                               q.DeliveryAddressStreet2,
                               q.DeliveryAddressCity,
                               q.DeliveryAddressState,
                               q.DeliveryAddressZip,
                               q.DeliveryAddressPhone,
                               q.DeliveryAddressAltPhone,
                               q.DeliveryAddressEmail,
                               q.DateApproved,
                               q.DateOrdered,
                               q.GoodUntil,
                               q.QuoteDate,
                               q.QuoteSent,
                               q.Subtotal,
                               q.Tax,
                               q.Total,
                               quoteDetailGroup
                           }
                          ).ToList().Select(r => new QuoteViewModel
                          {
                              FirstName = r.FirstName,
                              LastName = r.LastName,
                              Company = r.Company,
                              Address1 = r.Address1,
                              Address2 = r.Address2,
                              City = r.City,
                              State = r.State,
                              PostalCode = r.PostalCode,
                              WorkPhone = r.WorkPhone,
                              CellPhone = r.CellPhone,
                              Email = r.Email,
                              Discount = r.Discount,
                              PaymentTerms = r.PaymentTerms,
                              SalesRep = r.SalesRep,
                              QuoteId = r.QuoteId,
                              DeliveryAddressCompany = r.DeliveryAddressCompany,
                              DeliveryAddressContact = r.DeliveryAddressContact,
                              DeliveryAddressStreet1 = r.DeliveryAddressStreet1,
                              DeliveryAddressStreet2 = r.DeliveryAddressStreet2,
                              DeliveryAddressCity = r.DeliveryAddressCity,
                              DeliveryAddressState = r.DeliveryAddressState,
                              DeliveryAddressZip = r.DeliveryAddressZip,
                              DeliveryAddressPhone = r.DeliveryAddressPhone,
                              DeliveryAddressAltPhone = r.DeliveryAddressAltPhone,
                              DeliveryAddressEmail = r.DeliveryAddressEmail,
                              QuoteDate = r.QuoteDate,
                              Subtotal = r.Subtotal,
                              Tax = r.Tax,
                              GoodUntil = r.GoodUntil,
                              Total = r.Total,
                              DateApproved = r.DateApproved,
                              DateOrdered = r.DateOrdered,
                              QuoteSent = r.QuoteSent,
                              QuoteDetail = r.quoteDetailGroup.DefaultIfEmpty(new QuoteDetail { QuoteId = 1, QuoteDetailId = 1, ProductId = 1, Amount = 1, Discount = 0, ListPrice = 0, ProductName = "item", Price = 0 }).ToList()

                          });

            QuoteViewModel qvm = qvmList.Where(q => q.QuoteId == id).FirstOrDefault();
            qvm.QuoteDetail = db.QuoteDetails.Where(i => i.QuoteId == id).ToList();

            foreach (var item in qvm.QuoteDetail)
            {
                var od = new OrderDetail();
                od.OrderId = ovm.OrderId;
                od.ProductId = item.ProductId;
                od.ProductName = item.ProductName;
                od.SKU = item.SKU;
                od.Price = item.Price;
                od.ListPrice = item.ListPrice;
                od.Discount = item.Discount;
                od.Amount = item.Amount;

                ovm.OrderDetail.Add(od);
            }

            ovm.CustomerId = qvm.CustomerId;
            ovm.FirstName = qvm.FirstName;
            ovm.LastName = qvm.LastName;
            ovm.Company = qvm.Company;
            ovm.Address1 = qvm.Address1;
            ovm.Address2 = qvm.Address2;
            ovm.City = qvm.City;
            ovm.State = qvm.State;
            ovm.PostalCode = qvm.PostalCode;
            ovm.WorkPhone = qvm.WorkPhone;
            ovm.CellPhone = qvm.CellPhone;
            ovm.Email = qvm.Email;
            ovm.PaymentTerms = qvm.PaymentTerms;
            ovm.SalesRep = qvm.SalesRep;
            ovm.OrderStatus = OrderStatus.Pending;
            ovm.OrderStatusString = OrderStatus.Pending.ToString();
            ovm.QuoteId = qvm.QuoteId;
            ovm.BillingAddressAltPhone = qvm.CellPhone;
            ovm.BillingAddressCity = qvm.City;
            ovm.BillingAddressCompany = qvm.Company;
            ovm.BillingAddressContact = qvm.FirstName + " " + qvm.LastName;
            ovm.BillingAddressEmail = qvm.Email;
            ovm.BillingAddressPhone = qvm.WorkPhone;
            ovm.BillingAddressState = qvm.State;
            ovm.BillingAddressStreet1 = qvm.Address1;
            ovm.BillingAddressStreet2 = qvm.Address2;
            ovm.BillingAddressZip = qvm.PostalCode;
            ovm.ShippingAddressAltPhone = qvm.DeliveryAddressAltPhone;
            ovm.ShippingAddressCity = qvm.DeliveryAddressCity;
            ovm.ShippingAddressCompany = qvm.DeliveryAddressCompany;
            ovm.ShippingAddressContact = qvm.DeliveryAddressContact;
            ovm.ShippingAddressState = qvm.DeliveryAddressState;
            ovm.ShippingAddressStreet1 = qvm.DeliveryAddressStreet1;
            ovm.ShippingAddressStreet2 = qvm.DeliveryAddressStreet2;
            ovm.ShippingAddressZip = qvm.DeliveryAddressZip;
            ovm.ShippingAddressPhone = qvm.DeliveryAddressPhone;
            ovm.ShippingAddressEmail = qvm.DeliveryAddressEmail;
            ovm.OrderDate = DateTime.Now.Date;
            ovm.Subtotal = qvm.Subtotal;
            ovm.Tax = qvm.Tax;
            ovm.Total = qvm.Total;

            var customers = db.Customers.ToList();
            ViewBag.Customers = customers;

            var items = db.Products.ToList();
            ViewBag.ProductData = items;

            return View("../OrderViewModel/Edit", ovm);
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