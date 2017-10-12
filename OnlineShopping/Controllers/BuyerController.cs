using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.Controllers
{
    public class BuyerController : Controller
    {
        ShoppingCartDbEntities db = new ShoppingCartDbEntities();
        // GET: Buyer
        public ActionResult Index()
        {
            List<BaseCategory_Table> cato = new List<BaseCategory_Table>();
            cato = db.BaseCategory_Table.Where(x => x.BaseCatIsDeleted == false).ToList();

            return View(cato);
        }

        [HttpGet]
        public ActionResult profile()
        {
            string name = Session["user"].ToString();
            User_Table obj = db.User_Table.Where(x => x.UserName == name).FirstOrDefault();
            return View(obj);
        }

        [HttpPost]
        public ActionResult profile(User_Table obj)
        {
           
            string name = Session["user"].ToString();
            User_Table user = db.User_Table.Where(x => x.UserName == name).FirstOrDefault();
            user.FirstName = obj.FirstName;
            user.LastName = obj.LastName;
            user.UserEmail = obj.UserEmail;
            user.UserAddress = obj.UserAddress;
            user.UserUpdatedDate = System.DateTime.Now;
            db.SaveChanges();
            
            return View();
        }

        public ActionResult Product_cat()
        {
         
            int id = (int)Session["base_cat"];
           
                List<ProductCategory_Table> pcato = new List<ProductCategory_Table>();
            pcato = db.ProductCategory_Table.Where(x => x.BaseCatid == id).ToList();
            return View(pcato);

        }

        public ActionResult Product_page()
        {
            int id = (int)Session["prod_cat"];
            List<Product_Table> prods = new List<Product_Table>();
            prods = db.Product_Table.Where(x => x.ProductCatid == id).ToList();
            return View(prods);
        }

        [HttpPost]
        public JsonResult search(string name)
        {
            bool val = false;
            BaseCategory_Table obj = db.BaseCategory_Table.Where(x => x.BaseCatName == name).FirstOrDefault();
            ProductCategory_Table obj1 = db.ProductCategory_Table.Where(x => x.ProductCatName == name).FirstOrDefault();
            if(obj!=null)
            {
                Session["base_cat"] = obj.BaseCatId;
                Session["prod_cat"] = 0;
                 val = true;
                return Json (new {val}, JsonRequestBehavior.AllowGet);
            }
            else if (obj1 != null)
            {
                Session["base_cat"] = 0;
                Session["prod_cat"] = obj1.ProductCatId;
                val = true;
                return Json(new { val }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["prod_cat"] = 0;
                Session["base_cat"] = 0;
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult search_action()
        {
            int id= (int)Session["base_cat"];
            int id1= (int)Session["prod_cat"];

            if (id != 0)
            {
                return RedirectToAction("Product_cat");
            }
            else if (id1 != 0)
            {
                return RedirectToAction("Product_page");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


    }
}