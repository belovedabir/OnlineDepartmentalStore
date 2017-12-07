using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineDepartmentalStore.Models
{
    public class ProductController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowData()
        {
            return View(db.Products.ToList());
        }
        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerName,Rice,Egg,Milk,Biscuit,Chocolate,IceCream,Dal,Sugar,Oil,Flour,Total")] Products products)
        {
            Price(products);

            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products);
        }

        private static void Price(Products products)
        {
            double rice = 50, egg = 8, milk = 70, biscuit = 100, chocolate = 100, iceCream = 50, dal = 50, sugar = 50, oil = 50, flour = 50,
                    riceTotal = 0.0, eggTotal = 0.0, milkTotal = 0.0, biscuitTotal = 0.0, chocolateTotal = 0.0, iceCreamTotal = 0.0, dalTotal = 0.0, sugarTotal = 0.0, oilTotal = 0.0, flourTotal = 0.0, total = 0.0;

            if (products.Rice != null)
            {
                riceTotal = Convert.ToDouble(products.Rice) * rice;
                products.Rice = Convert.ToString(products.Rice) + " Kg" + " - " + Convert.ToString(riceTotal) + " Tk";
            }
            else
                products.Rice = " ";

            if (products.Egg != null)
            {
                eggTotal = Convert.ToDouble(products.Egg) * egg;
                products.Egg = Convert.ToString(products.Egg) + " Piece" + " - " + Convert.ToString(eggTotal) + " Tk";
            }
            else
                products.Egg = " ";

            if (products.Milk != null)
            {
                milkTotal = Convert.ToDouble(products.Milk) * milk;
                products.Milk = Convert.ToString(products.Milk) + " Litre" + " - " + Convert.ToString(milkTotal) + " Tk";
            }
            else
                products.Milk = " ";

            if (products.Biscuit != null)
            {
                biscuitTotal = Convert.ToDouble(products.Biscuit) * biscuit;
                products.Biscuit = Convert.ToString(products.Biscuit) + " Packet" + " - " + Convert.ToString(biscuitTotal) + " Tk";
            }
            else
                products.Biscuit = " ";

            if (products.Chocolate != null)
            {
                chocolateTotal = Convert.ToDouble(products.Chocolate) * chocolate;
                products.Chocolate = Convert.ToString(products.Chocolate) + " Piece" + " - " + Convert.ToString(chocolateTotal) + " Tk";
            }
            else
                products.Chocolate = " ";

            if (products.IceCream != null)
            {
                iceCreamTotal = Convert.ToDouble(products.IceCream) * iceCream;
                products.IceCream = Convert.ToString(products.IceCream) + " Piece" + " - " + Convert.ToString(iceCreamTotal) + " Tk";
            }
            else
                products.IceCream = " ";

            if (products.Dal != null)
            {
                dalTotal = Convert.ToDouble(products.Dal) * dal;
                products.Dal = Convert.ToString(products.Dal) + " Kg" + " - " + Convert.ToString(dalTotal) + " Tk";
            }
            else
                products.Dal = " ";

            if (products.Sugar != null)
            {
                sugarTotal = Convert.ToDouble(products.Sugar) * sugar;
                products.Sugar = Convert.ToString(products.Sugar) + " Kg" + " - " + Convert.ToString(sugarTotal) + " Tk";
            }
            else
                products.Sugar = " ";

            if (products.Oil != null)
            {
                oilTotal = Convert.ToDouble(products.Oil) * oil;
                products.Oil = Convert.ToString(products.Oil) + " Litre" + " - " + Convert.ToString(oilTotal) + " Tk";
            }
            else
                products.Oil = " ";

            if (products.Flour != null)
            {
                flourTotal = Convert.ToDouble(products.Flour) * flour;
                products.Flour = Convert.ToString(products.Flour) + " Kg" + " - " + Convert.ToString(flourTotal) + " Tk";
            }
            else
                products.Flour = " ";

            total = riceTotal + eggTotal + milkTotal + biscuitTotal + chocolateTotal + iceCreamTotal + dalTotal + sugarTotal + oilTotal
                  + flourTotal;
            products.Total = Convert.ToString(total) + " TK";
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerName,Rice,Egg,Milk,Biscuit,Chocolate,IceCream,Dal,Sugar,Oil,Flour")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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
