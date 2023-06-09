﻿using NewEcommerc.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult SubCategory()
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
        public JsonResult SaveSubCatagory(string Name, string TypeId,string CatId)
        {
            bool result = false;
            try
            {
                Mstr_categories cat = new Mstr_categories();
                cat.Name = Name;
                if (string.IsNullOrEmpty(CatId))
                    cat.Pid = 0;
                else
                    cat.Pid = int.Parse(CatId);
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
        public JsonResult BindCategoryByPid(int Pid)
        {
            MainPageData main = new MainPageData();

            return Json(main.GetAllCategoriesByPId(Pid), JsonRequestBehavior.AllowGet);
        }
        
         
        public JsonResult BindSubCategoryLst()
        {
            int[] typeIds = db.Mstr_categories.Where(x => x.Pid == 0).Select(x => x.Id).ToArray();
            int[] catIds= db.Mstr_categories.Where(x => typeIds.Contains((int)x.Pid)).Select(x => x.Id).ToArray(); ;
            List<Mstr_categories> lst = db.Mstr_categories.Where(x => catIds.Contains((int)x.Pid)).ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }


        #region for product

        public ActionResult Addproduct()
        {
            return View();
        }

        public JsonResult SaveProduct(Product pro)
        {
            string msg = "Product No Saved!";
            if (pro.ProId != 0)
            {

            }
            else
            {
                pro.Crd = DateTime.Now;
                pro.Crdby = 1;
                pro.IsActive = true;
                pro.IsDelete = false;
                db.Products.Add(pro);
                db.SaveChanges();
                msg = "Product Saved.";
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult productlist()
        {

            return View(db.Products.ToList());
        }
        #endregion
        [HttpPost]
        public ActionResult UploadFiles()
        {
            if (Request.Files.Count > 0)
            {
                string finalimgnams = "";
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        finalimgnams += file.FileName + ",";
                        string fname;
                        fname = Path.Combine(Server.MapPath("~/Uploads/"), file.FileName);
                        file.SaveAs(fname);
                    }
                    finalimgnams = finalimgnams.Trim(',');
                    return Json(finalimgnams, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }

        }

        public  ActionResult neworder()
        {
            //OrderStatus plased =1
            List<Order_Tbl> neworder = db.Order_Tbl.Where(x => x.OrderStatus == 1 && x.IsActive == true && x.IsDelete == false).ToList();
            return View(neworder);
        }
        public ActionResult confirmorder()
        {
            //OrderStatus Confirm =2
            List<Order_Tbl> neworder = db.Order_Tbl.Where(x => x.OrderStatus == 2 && x.IsActive == true && x.IsDelete == false).ToList();
            return View(neworder);
        }
        public ActionResult shippedorder()
        {
            //OrderStatus shipped =3
            List<Order_Tbl> neworder = db.Order_Tbl.Where(x => x.OrderStatus == 3 && x.IsActive == true && x.IsDelete == false).ToList();
            return View(neworder);
        }
        public ActionResult deleverdorder()
        {
            //OrderStatus deleverd =4
            List<Order_Tbl> neworder = db.Order_Tbl.Where(x => x.OrderStatus ==4 && x.IsActive == true && x.IsDelete == false).ToList();
            return View(neworder);
        }

        public JsonResult changeOrderstatus(int Orderid,int status)
        {
            Order_Tbl order = db.Order_Tbl.Where(x => x.OrderID == Orderid).FirstOrDefault();
            order.OrderStatus = status;
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }

        public ActionResult GenerateInvoic(int ordId)
        {
         
            Order_Tbl order = db.Order_Tbl.Where(x => x.OrderID == ordId).FirstOrDefault();
            int cusid = int.Parse(order.Customer);
            List<Order_Items> itemlst = db.Order_Items.Where(x => x.OrderID == order.OrderID).ToList();
            int?[] ids = db.Order_Items.Where(x => x.OrderID == order.OrderID).Select(x => x.proId).ToArray();
            List<Product> prolst = db.Products.Where(x => ids.Contains(x.ProId)).ToList();
            Mstr_Cus_Add add = db.Mstr_Cus_Add.Where(x => x.cusId == cusid && x.IsActive==true).FirstOrDefault();
            Tuple<Order_Tbl, List<Product>, Mstr_Cus_Add> obj = new Tuple<Order_Tbl, List<Product>, Mstr_Cus_Add>(order, prolst, add);
            return View(obj);
        }
    }
}