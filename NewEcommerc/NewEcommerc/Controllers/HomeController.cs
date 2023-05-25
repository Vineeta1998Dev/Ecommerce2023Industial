using NewEcommerc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewEcommerc.Controllers
{
    public class HomeController : Controller
    {
        ECOMMERCEEntities db = new ECOMMERCEEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductsGrid()
        {
            return View();
        }
        public JsonResult GetProductBysubcategoryId(int? ID)
        {
            List<Product> lst = db.Products.Where(x => x.ProSubCat == ID).ToList();
            return Json(lst,JsonRequestBehavior.AllowGet);
        }
        public ActionResult shopsingle(int? PID)
        {
            Product pro = db.Products.Where(x => x.ProId == PID).FirstOrDefault();
            return View(pro);
        }
     
    }
}