using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shoping_Cart;
using Shoping_Cart.Models;

namespace Shoping_Cart.Controllers
{
    public class HomeController : Controller
    {
        myshopDBEntities db = new myshopDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            
            var p = db.tblproes.ToList();
            ViewBag.p = p;

            var imgs = db.tblimages.ToList();
            ViewBag.imgs = imgs;
            return View();
        }

        public ActionResult Category(int id)
        {
            var p = db.tblproes.Where(l => l.cid == id).ToList();
            ViewBag.p = p;
            var imgs = db.tblimages.ToList();
            ViewBag.imgs = imgs;    
            return View();
        }

        public ActionResult DetailProduct(int id)
        {
            var q = db.tblproes.ToList();
            ViewBag.q = q;
            var p = db.tblproes.Where(l => l.pid == id).ToList();
            ViewBag.p = p;
            var imgs = db.tblimages.ToList();
            ViewBag.imgs = imgs;
            var cat = db.tblcats.Where(l => l.cid == id).ToList();
            ViewBag.cat = cat;
            return View();
        }

        public ActionResult Cart()
        {
            ViewBag.c = Fix.c;
            return View();
        }


        [HttpPost]
        public ActionResult Cart(string pid,string pqty)
        {
            foreach (var item in Fix.c)
            {
                if(item.iid == int.Parse(pid))
                {
                    item.iqty += int.Parse(pqty);
                    ViewBag.c = Fix.c;
                    return View();
                }
            }

            CartItem i = new CartItem() { iid = int.Parse(pid), iqty = int.Parse(pqty) };
            Fix.c.Add(i);
            ViewBag.c = Fix.c;
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(string total)
        {
            ViewBag.t = total;
            return View();
        }

        [HttpPost]
        public ActionResult Orderdone(tblorder tb, string total)
        {
            tblorder obj = new tblorder();
            obj.odate = DateTime.Now;
            obj.opname = tb.opname;
            obj.opphone = tb.opphone;
            obj.opaddress = tb.opaddress;
            obj.opsaddress = tb.opaddress;
            obj.ostatus = 0;
            obj.oamount = decimal.Parse(total);
            db.tblorders.Add(obj);
            db.SaveChanges();

            return RedirectToAction("index");
        }
    }
}