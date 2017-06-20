using CMSUsersAndRoles.Models;
using System;
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
    public class OrderViewModelController : Controller
    {
        private CMSWebFormsContext db = new CMSWebFormsContext();
        private OrderViewModel ovm = new OrderViewModel();
        // GET: OrderViewModel
        [Authorize]
        public ActionResult Index(string Search)
        {
            var ovmList = (from c in db.Customers
                           join o in db.Orders on c.CustomerId equals o.CustomerId
                           join od in db.OrderDetails on o.OrderId equals od.OrderId into orderDetailGroup
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
                               o.OrderId,
                               o.OrderStatusString,
                               o.ShippingAddressPhone,
                               o.ShippingAddressEmail,
                               o.OrderDate,
                               o.DateRequested,
                               o.DateShipped,
                               o.Subtotal,
                               o.Tax,
                               o.Total,
                               orderDetailGroup
                           }
                          ).ToList().Select(r => new OrderViewModel
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
                              PaymentTerms = r.PaymentTerms,
                              SalesRep = r.SalesRep,
                              OrderId = r.OrderId,
                              OrderStatusString = r.OrderStatusString,
                              ShippingAddressPhone = r.ShippingAddressPhone,
                              ShippingAddressEmail = r.ShippingAddressEmail,
                              OrderDate = r.OrderDate,
                              Tax = r.Tax,
                              Total = r.Total,
                              OrderDetail = r.orderDetailGroup.DefaultIfEmpty(new OrderDetail { OrderId = r.OrderId, OrderDetailId = 1, ProductId = 1, Amount = 1, Discount = 0, ListPrice = 0, ProductName = "item", Price = 0 }).ToList()

                          });

            if (Search != null)
            {
                var orderList = ovmList.Where(x => x.Company.Contains(Search) || x.SalesRep.Contains(Search) || x.OrderStatusString == Search || x.OrderId.ToString() == Search).ToList();
               
                return View(orderList);
            }
            else
            {
                return View(ovmList);
            }
        }

        public ActionResult Create()
        {
            OrderViewModel ovm = new OrderViewModel();
            ovm.OrderDetail = new List<OrderDetail>();
            ovm.OrderDetail.Add(new OrderDetail() { OrderId = ovm.QuoteId, OrderDetailId = (ovm.OrderDetail.Count + 1), Discount = 0 });

            var customers = db.Customers.ToList();
            ViewBag.Customers = customers;

            var items = db.Products.ToList();
            ViewBag.ProductData = items;

            return View(ovm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel ovm)
        {
            //if (ovm.QuoteDetail == null)
            //{
            //    ovm.QuoteDetail = new List<QuoteDetail>();
            //    ovm.QuoteDetail.Add(new QuoteDetail() { QuoteId = ovm.QuoteId, QuoteDetailId = (ovm.QuoteDetail.Count + 1) });
            //    var customerList = db.Customers.ToList();
            //    ViewBag.Customers = customerList;
            //    return View(ovm);
            //}

            if (ModelState.IsValid)
            {

                foreach (var orderDetail in ovm.OrderDetail)
                {

                    OrderDetail od = db.OrderDetails.FirstOrDefault(o => ((o.OrderId == orderDetail.OrderId) && (o.OrderDetailId == orderDetail.OrderDetailId)));

                    if (od != null)
                    {
                        od.ProductId = orderDetail.ProductId;
                        od.ProductName = orderDetail.ProductName;
                        od.Amount = orderDetail.Amount;
                        od.ListPrice = orderDetail.ListPrice;
                        od.Discount = orderDetail.Discount;
                        od.Price = orderDetail.Price;
                    }
                    else
                    {
                        db.OrderDetails.Add(orderDetail);
                    }

                }
                Order order = new Order();

                order.OrderStatus = OrderStatus.Pending;
                order.OrderStatusString = OrderStatus.Pending.ToString();
                order.CustomerId = ovm.CustomerId;
                order.QuoteId = ovm.QuoteId;
                order.SalesRep = ovm.SalesRep;
                order.BillingAddressContact = ovm.BillingAddressContact;
                order.BillingAddressCompany = ovm.BillingAddressCompany;
                order.BillingAddressStreet1 = ovm.BillingAddressStreet1;
                order.BillingAddressStreet2 = ovm.BillingAddressStreet2;
                order.BillingAddressCity = ovm.BillingAddressCity;
                order.BillingAddressState = ovm.BillingAddressState;
                order.BillingAddressZip = ovm.BillingAddressZip;
                order.BillingAddressPhone = ovm.BillingAddressPhone;
                order.BillingAddressAltPhone = ovm.BillingAddressAltPhone;
                order.BillingAddressEmail = ovm.BillingAddressEmail;
                order.ShippingAddressContact = ovm.ShippingAddressContact;
                order.ShippingAddressCompany = ovm.ShippingAddressCompany;
                order.ShippingAddressStreet1 = ovm.ShippingAddressStreet1;
                order.ShippingAddressStreet2 = ovm.ShippingAddressStreet2;
                order.ShippingAddressCity = ovm.ShippingAddressCity;
                order.ShippingAddressState = ovm.ShippingAddressState;
                order.ShippingAddressZip = ovm.ShippingAddressZip;
                order.ShippingAddressPhone = ovm.ShippingAddressPhone;
                order.ShippingAddressAltPhone = ovm.ShippingAddressAltPhone;
                order.ShippingAddressEmail = ovm.ShippingAddressEmail;
                order.OrderDate = ovm.OrderDate;
                order.DateRequested = ovm.DateRequested;
                order.DateFulfilled = ovm.DateFulfilled;
                order.DateShipped = ovm.DateShipped;
                order.Subtotal = ovm.Subtotal;
                order.ShippingCost = ovm.ShippingCost;
                order.Tax = ovm.Tax;
                order.Total = ovm.Total;

                db.Orders.Add(order);

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

            return View(ovm);
        }

        public ActionResult AddProduct(int orderId, int orderDetailId)
        {
            var items = db.Products.ToList();
            ViewBag.ProductData = items;

            return PartialView("EditOrderDetail", new OrderDetail { OrderId = orderId, OrderDetailId = orderDetailId });
        }

        [HttpGet]
        public ActionResult DisplayCustomerAddress()
        {
            return PartialView("/QuoteViewModel/DisplayCustomerAddress");
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
        public ActionResult DeleteProduct(int orderId, int orderDetailId)
        {
            OrderDetail orderDetail = db.OrderDetails.FirstOrDefault(p => ((p.OrderId == orderId) && (p.OrderDetailId == orderDetailId)));

            if (orderDetail != null)
            {
                db.OrderDetails.Remove(orderDetail);
                db.SaveChanges();
            }

            return Json(true);

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ovmList = (from o in db.Orders
                           join od in db.OrderDetails on o.OrderId equals od.OrderId into orderDetailGroup
                           select new
                           {
                               o.OrderStatus,
                               o.OrderStatusString,
                               o.OrderId,
                               o.CustomerId,
                               o.QuoteId,
                               o.BillingAddressAltPhone,
                               o.BillingAddressCity,
                               o.BillingAddressCompany,
                               o.BillingAddressContact,
                               o.BillingAddressEmail,
                               o.BillingAddressPhone,
                               o.BillingAddressState,
                               o.BillingAddressStreet1,
                               o.BillingAddressStreet2,
                               o.BillingAddressZip,
                               o.DateFulfilled,
                               o.FOB,
                               o.Notes,
                               o.PaymentTerms,
                               o.PODate,
                               o.PONumber,
                               o.SalesRep,
                               o.ShipMethod,
                               o.ShippingAddressAltPhone,
                               o.ShippingAddressCity,
                               o.ShippingAddressCompany,
                               o.ShippingAddressContact,
                               o.ShippingAddressState,
                               o.ShippingAddressStreet1,
                               o.ShippingAddressStreet2,
                               o.ShippingAddressZip,
                               o.ShippingAddressPhone,
                               o.ShippingAddressEmail,
                               o.OrderDate,
                               o.DateRequested,
                               o.DateShipped,
                               o.Subtotal,
                               o.ShippingCost,
                               o.Tax,
                               o.Total,
                               orderDetailGroup
                           }
                          ).ToList().Select(r => new OrderViewModel
                          {
                              CustomerId = r.CustomerId,
                              PaymentTerms = r.PaymentTerms,
                              SalesRep = r.SalesRep,
                              OrderId = r.OrderId,
                              OrderStatus = r.OrderStatus,
                              OrderStatusString = r.OrderStatus.ToString(),
                              QuoteId = (int)r.QuoteId,
                              BillingAddressAltPhone = r.BillingAddressAltPhone,
                              BillingAddressCity = r.BillingAddressCity,
                              BillingAddressCompany = r.BillingAddressCompany,
                              BillingAddressContact = r.BillingAddressContact,
                              BillingAddressEmail = r.BillingAddressEmail,
                              BillingAddressPhone = r.BillingAddressPhone,
                              BillingAddressState = r.BillingAddressState,
                              BillingAddressStreet1 = r.BillingAddressStreet1,
                              BillingAddressStreet2 = r.BillingAddressStreet2,
                              BillingAddressZip = r.BillingAddressZip,
                              DateFulfilled = r.DateFulfilled,
                              FOB = r.FOB,
                              Notes = r.Notes,
                              PODate = r.PODate,
                              PONumber = r.PONumber,
                              ShipMethod = r.ShipMethod,
                              ShippingAddressAltPhone = r.ShippingAddressAltPhone,
                              ShippingAddressCity = r.ShippingAddressCity,
                              ShippingAddressCompany = r.ShippingAddressCompany,
                              ShippingAddressContact = r.ShippingAddressContact,
                              ShippingAddressState = r.ShippingAddressState,
                              ShippingAddressStreet1 = r.ShippingAddressStreet1,
                              ShippingAddressStreet2 = r.ShippingAddressStreet2,
                              ShippingAddressZip = r.ShippingAddressZip,
                              ShippingAddressPhone = r.ShippingAddressPhone,
                              ShippingAddressEmail = r.ShippingAddressEmail,
                              OrderDate = r.OrderDate,
                              Subtotal = r.Subtotal,
                              ShippingCost = r.ShippingCost,
                              Tax = r.Tax,
                              Total = r.Total,
                              OrderDetail = r.orderDetailGroup.DefaultIfEmpty(new OrderDetail { OrderId = r.OrderId, OrderDetailId = 1, ProductId = 1, Amount = 1, Discount = 0, ListPrice = 0, ProductName = "item", Price = 0 }).ToList()

                          });

            OrderViewModel ovm = (OrderViewModel)ovmList.Where(o => o.OrderId == id).FirstOrDefault();
            ovm.OrderDetail = db.OrderDetails.Where(i => i.OrderId == id).ToList();

            //var items = db.Products.ToList();
            //ViewBag.ProductData = items;

            if (ovm == null)
            {
                return HttpNotFound();
            }
            return View(ovm);
        }


        [Authorize(Roles = "Admin, SalesEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ovmList = (from c in db.Customers
                           join o in db.Orders on c.CustomerId equals o.CustomerId
                           join od in db.OrderDetails on o.OrderId equals od.OrderId into orderDetailGroup
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
                               o.OrderId,
                               o.OrderStatus,
                               o.OrderStatusString,
                               o.QuoteId,
                               o.BillingAddressAltPhone,
                               o.BillingAddressCity,
                               o.BillingAddressCompany,
                               o.BillingAddressContact,
                               o.BillingAddressEmail,
                               o.BillingAddressPhone,
                               o.BillingAddressState,
                               o.BillingAddressStreet1,
                               o.BillingAddressStreet2,
                               o.BillingAddressZip,
                               o.DateFulfilled,
                               o.FOB,
                               o.Notes,
                               o.PaymentTerms,
                               o.PODate,
                               o.PONumber,
                               o.SalesRep,
                               o.ShipMethod,
                               o.ShippingAddressAltPhone,
                               o.ShippingAddressCity,
                               o.ShippingAddressCompany,
                               o.ShippingAddressContact,
                               o.ShippingAddressState,
                               o.ShippingAddressStreet1,
                               o.ShippingAddressStreet2,
                               o.ShippingAddressZip,
                               o.ShippingAddressPhone,
                               o.ShippingAddressEmail,
                               o.OrderDate,
                               o.DateRequested,
                               o.DateShipped,
                               o.Subtotal,
                               o.ShippingCost,
                               o.Tax,
                               o.Total,
                               orderDetailGroup
                           }
                          ).ToList().Select(r => new OrderViewModel
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
                              PaymentTerms = r.PaymentTerms,
                              SalesRep = r.SalesRep,
                              OrderId = r.OrderId,
                              OrderStatus = r.OrderStatus,
                              OrderStatusString = r.OrderStatus.ToString(),
                              QuoteId = (int)r.QuoteId,
                              BillingAddressAltPhone = r.BillingAddressAltPhone,
                              BillingAddressCity = r.BillingAddressCity,
                              BillingAddressCompany = r.BillingAddressCompany,
                              BillingAddressContact = r.BillingAddressContact,
                              BillingAddressEmail = r.BillingAddressEmail,
                              BillingAddressPhone = r.BillingAddressPhone,
                              BillingAddressState = r.BillingAddressState,
                              BillingAddressStreet1 = r.BillingAddressStreet1,
                              BillingAddressStreet2 = r.BillingAddressStreet2,
                              BillingAddressZip = r.BillingAddressZip,
                              DateFulfilled = r.DateFulfilled,
                              FOB = r.FOB,
                              Notes = r.Notes,
                              PODate = r.PODate,
                              PONumber = r.PONumber,
                              ShipMethod = r.ShipMethod,
                              ShippingAddressAltPhone = r.ShippingAddressAltPhone,
                              ShippingAddressCity = r.ShippingAddressCity,
                              ShippingAddressCompany = r.ShippingAddressCompany,
                              ShippingAddressContact = r.ShippingAddressContact,
                              ShippingAddressState = r.ShippingAddressState,
                              ShippingAddressStreet1 = r.ShippingAddressStreet1,
                              ShippingAddressStreet2 = r.ShippingAddressStreet2,
                              ShippingAddressZip = r.ShippingAddressZip,
                              ShippingAddressPhone = r.ShippingAddressPhone,
                              ShippingAddressEmail = r.ShippingAddressEmail,
                              OrderDate = r.OrderDate,
                              Subtotal = r.Subtotal,
                              ShippingCost = r.ShippingCost,
                              Tax = r.Tax,
                              Total = r.Total,
                              OrderDetail = r.orderDetailGroup.DefaultIfEmpty(new OrderDetail { OrderId = r.OrderId, OrderDetailId = 1, ProductId = 1, Amount = 1, Discount = 0, ListPrice = 0, ProductName = "item", Price = 0 }).ToList()

                          });

            OrderViewModel ovm = (OrderViewModel)ovmList.Where(o => o.OrderId == id).FirstOrDefault();
            ovm.OrderDetail = db.OrderDetails.Where(i => i.OrderId == id).ToList();

            var items = db.Products.ToList();
            ViewBag.ProductData = items;

            if (ovm == null)
            {
                return HttpNotFound();
            }
            return View(ovm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderViewModel ovm, int id)
        {
            ViewBag.Error = "";

            if (ovm.OrderDetail == null)
            {
                ovm.OrderDetail = new List<OrderDetail>();
                ovm.OrderDetail.Add(new OrderDetail() { OrderId = id });
                var itemList = db.Products.ToList();
                ViewBag.ProductData = itemList;
                ViewBag.Error = "At least one product is required";
                return View(ovm);
            }

            ViewBag.Messages = "";

            if (!ModelState.IsValid)
            {
                string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                ViewBag.Messages = messages;
            }

            if (ModelState.IsValid)
            {
                
                foreach (var orderDetail in ovm.OrderDetail)
                {

                    OrderDetail od = db.OrderDetails.FirstOrDefault(o => ((o.OrderId == orderDetail.OrderId) && (o.OrderDetailId == orderDetail.OrderDetailId)));

                    if (od != null)
                    {
                        od.ProductId = orderDetail.ProductId;
                        od.ProductName = orderDetail.ProductName;
                        od.Amount = orderDetail.Amount;
                        od.ListPrice = orderDetail.ListPrice;
                        od.Discount = orderDetail.Discount;
                        od.Price = orderDetail.Price;
                    }
                    else
                    {
                        db.OrderDetails.Add(orderDetail);
                    }
                    
                }

                Order order = db.Orders.FirstOrDefault(o => ((o.OrderId == id)));

                order.OrderStatus = ovm.OrderStatus;
                order.OrderStatusString = ovm.OrderStatus.ToString();
                order.CustomerId = ovm.CustomerId;
                order.QuoteId = ovm.QuoteId;
                order.SalesRep = ovm.SalesRep;
                order.BillingAddressContact = ovm.BillingAddressContact;
                order.BillingAddressCompany = ovm.BillingAddressCompany;
                order.BillingAddressStreet1 = ovm.BillingAddressStreet1;
                order.BillingAddressStreet2 = ovm.BillingAddressStreet2;
                order.BillingAddressCity = ovm.BillingAddressCity;
                order.BillingAddressState = ovm.BillingAddressState;
                order.BillingAddressZip = ovm.BillingAddressZip;
                order.BillingAddressPhone = ovm.BillingAddressPhone;
                order.BillingAddressAltPhone = ovm.BillingAddressAltPhone;
                order.BillingAddressEmail = ovm.BillingAddressEmail;
                order.ShippingAddressContact = ovm.ShippingAddressContact;
                order.ShippingAddressCompany = ovm.ShippingAddressCompany;
                order.ShippingAddressStreet1 = ovm.ShippingAddressStreet1;
                order.ShippingAddressStreet2 = ovm.ShippingAddressStreet2;
                order.ShippingAddressCity = ovm.ShippingAddressCity;
                order.ShippingAddressState = ovm.ShippingAddressState;
                order.ShippingAddressZip = ovm.ShippingAddressZip;
                order.ShippingAddressPhone = ovm.ShippingAddressPhone;
                order.ShippingAddressAltPhone = ovm.ShippingAddressAltPhone;
                order.ShippingAddressEmail = ovm.ShippingAddressEmail;
                order.OrderDate = ovm.OrderDate;
                order.DateRequested = ovm.DateRequested;
                order.DateFulfilled = ovm.DateFulfilled;
                order.DateShipped = ovm.DateShipped;
                order.Subtotal = ovm.Subtotal;
                order.ShippingCost = ovm.ShippingCost;
                order.Tax = ovm.Tax;
                order.Total = ovm.Total;



                db.Entry(order).State = EntityState.Modified;
               
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

            return View(ovm);
        }

    }
    }