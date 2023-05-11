using NewEcommerc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewEcommerc.Controllers
{
    public class AdminController : Controller
    {
        ECOMMERCEEntities db = new ECOMMERCEEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProType()
        {
            return View();
        }
        public JsonResult SaveCatagory(string Name,string Pid)
        {
            bool result = false;
            try {
                Mstr_categories cat = new Mstr_categories();
                cat.Name = Name;
                if (string.IsNullOrEmpty(Pid))
                    cat.Pid = 0;
                else
                    cat.Pid = int.Parse(Pid);
                cat.Crd = DateTime.Now;
                cat.Crdby = 1;
                cat.IsActive = true;
                cat.IsDelete = false;
                db.Mstr_categories.Add(cat);
                db.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BindProTypeLst()
        {
            return Json(db.Mstr_categories.Where(x=>x.Pid==0).ToList(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult Category()
        {
            return View();
        }
        public JsonResult BindCategoryLst()
        {
            int[] typeIds = db.Mstr_categories.Where(x => x.Pid == 0).Select(x => x.Id).ToArray();

            List<Mstr_categories> lst = db.Mstr_categories.Where(x => typeIds.Contains((int)x.Pid)).ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}