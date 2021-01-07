using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shoping_Cart;

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
            var p = db.tblproes.Where(l => l.pid == id).ToList();
            ViewBag.p = p;
            var imgs = db.tblimages.ToList();
            ViewBag.imgs = imgs;
            var cat = db.tblcats.Where(l => l.cid == id).ToList();
            ViewBag.cat = cat;
            return View();
        }
    }
}