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
        public JsonResult SaveCartItem(string Did,string Pid)
        {
            bool result = false;
            try
            {
                CartsItem cart = new CartsItem();

                cart.proId = int.Parse(Pid);
                cart.devicesId = Did;
                cart.qty = 1;
                cart.Crd = DateTime.Now;
                cart.Crdby = 1;
                cart.IsActive = true;
                cart.IsDelete = false;
                db.CartsItems.Add(cart);
                db.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetCartItems(string DeviceId)
        {
            List<CartsItem> itemList = db.CartsItems.Where(x => x.devicesId == DeviceId).ToList();
            int?[] ids = itemList.Select(x => x.proId).ToArray();
            List<Product> products = db.Products.Where(x => ids.Contains(x.ProId)).ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCartItemsCounts(string DeviceId)
        {
            List<CartsItem> itemList = db.CartsItems.Where(x => x.devicesId == DeviceId).ToList();
            return Json(itemList.Count, JsonRequestBehavior.AllowGet);
        }
        public JsonResult deletealertitem(string DeviceId,int? ProId)
        {
            bool result = false;
            try
            {
                CartsItem item = db.CartsItems.Where(x => x.devicesId == DeviceId && x.proId == ProId).FirstOrDefault();
                db.CartsItems.Remove(item);
                db.SaveChanges();
                result = true;
            }
            catch (Exception)
            {

                throw;
            }
       
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [Filter]
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult SignIN()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIN(string id,string pass)
        {
            Mstr_Login login = db.Mstr_Login.Where(x => x.Email == id && x.Password == pass).FirstOrDefault();
            Customer_Info cus = db.Customer_Info.Where(x => x.LoginID == login.Id).FirstOrDefault();
            Session["LoginDeatails"] = cus;
            if(Session["LoginDeatails"]!=null)
            {
                Response.Redirect("/home/index");
            }
            else
            {
                Response.Redirect("/home/signin");
            }
           
            return View();
        }
        public ActionResult SignUP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUP(string name,string mob,string email,string password)
        {
            bool result = false;
            try
            {
                Mstr_Login cart = new Mstr_Login();
                cart.UserName = name;
                cart.Email = email;
                cart.Password = password;
                cart.CrdBy = 1;
                cart.IsActive = true;
                cart.IsDeleted = false;
                db.Mstr_Login.Add(cart);
                db.SaveChanges();

                int loginid = db.Mstr_Login.OrderByDescending(a=>a.Id).Select(x => x.Id).FirstOrDefault();
                Customer_Info cus = new Customer_Info();
                cus.LoginID = loginid;
                cus.fname = name.Split(' ')[0];
                cus.lname = name.Split(' ')[1];
                cus.email = email;
                cus.mob = mob;
                cus.CrdBy = 1;
                cus.IsActive = true;
                cus.IsDeleted = false;
                db.Customer_Info.Add(cus);
                db.SaveChanges();
                Session["LoginDeatails"] = cus;
                Response.Redirect("/home/index");
                result = true;
            }
            catch (Exception e)
            {

            }
            return View();
        }

        [HttpPost]
        public ActionResult Saveadd(Mstr_Cus_Add add)
        {
            try
            {
                Customer_Info cous = (Customer_Info)Session["LoginDeatails"];
                add.cusId = cous.CusId;
                add.Crdby = 1;
                add.IsActive = false;
                add.IsDelete = false;
                db.Mstr_Cus_Add.Add(add);
                db.SaveChanges();
                Response.Write("<script>alert('Address added..')</script>");
                Response.Redirect("/home/Checkout");

            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        public JsonResult GetAdd(int? CusId)
        {
            List<Mstr_Cus_Add> itemList = db.Mstr_Cus_Add.Where(x => x.cusId == CusId).ToList();
            return Json(itemList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PlaceOrder(string DeviceId, string method)
        {
            int result = 0;
            if(method=="COD")
            {
                result = GenerateOrder(DeviceId);
            }
            else
            {

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public int GenerateOrder(string DeviceId)
        {
            int res = 0;
            try
            {
                Customer_Info cus = (Customer_Info)Session["LoginDeatails"];
                List<CartsItem> listcartitem = db.CartsItems.Where(x => x.devicesId == DeviceId).ToList();
                int?[] proId = listcartitem.Select(x => x.proId).ToArray();
                List<Product> listProducts = db.Products.Where(x => proId.Contains(x.ProId)).ToList();
                int? total = listProducts.Sum(x => x.price);

                Order_Tbl order = new Order_Tbl();
                order.Customer = cus.CusId.ToString();
                order.DateTIme = DateTime.Now;
                order.PaymentMethod = "COD";
                order.PaymentStatus = false;
                order.Amount = total + 150;
                order.Crd = DateTime.Now;
                order.Crdby = 1;
                order.OrderStatus = 1;
                order.IsActive = true;
                order.IsDelete = false;
                db.Order_Tbl.Add(order);
                db.SaveChanges();
                int orderId = db.Order_Tbl.OrderByDescending(x => x.Crd).Select(x => x.OrderID).FirstOrDefault();
                foreach (Product pro in listProducts)
                {
                    Order_Items item = new Order_Items();
                    item.OrderID = orderId;
                    item.proId = pro.ProId;
                    item.devicesId = DeviceId;
                    item.qty = listcartitem.Where(x => x.proId == pro.ProId).Select(x => x.qty).FirstOrDefault();
                    item.Crd = DateTime.Now;
                    item.Crdby = 1;
                    item.IsActive = true;
                    item.IsDelete = false;
                    db.Order_Items.Add(item);
                    db.SaveChanges();

                }

                db.CartsItems.RemoveRange(listcartitem);
                db.SaveChanges();
                res = orderId;
                
            }
            catch (Exception)
            {

                throw;
            }

            return res;
        }


        public ActionResult PlacedOrder(int id)
        {
            @ViewBag.id = id;
            return View();
        }
        [Filter]
        public ActionResult MyOrder()
        {
            Customer_Info cu=(Customer_Info)Session["LoginDeatails"];
            string cusID = cu.CusId.ToString();
            List<Order_Tbl> order = db.Order_Tbl.Where(x => x.Customer == cusID).ToList();
           
            return View(order);
 
        }
    }
}