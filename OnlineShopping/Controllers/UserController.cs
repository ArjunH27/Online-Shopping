using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.Controllers
{
    public class UserController : Controller
    {
        ShoppingCartDbEntities db = new ShoppingCartDbEntities();
        // GET: User
        public ActionResult create()
        {
            List<Role_Table> role = new List<Role_Table>();
            role = db.Role_Table.Where(x=>x.RoleIsDeleted==false).ToList();
            var rolelist = new List<SelectListItem>();
            foreach(var item in role)
            { rolelist.Add(new SelectListItem
                {
                    Text = item.RoleName.ToString(),
                    Value = item.RoleId.ToString()
                });
            }
            ViewBag.rolename = rolelist;
            return View();
        }

        [HttpPost]
        public ActionResult create(User_Table obj,string x)
        {
            if(ModelState.IsValid)
            { 
            obj.UserCreatedDate = System.DateTime.Now;
            obj.UserUpdatedDate = System.DateTime.Now;
            if(obj.Roleid==1|| obj.Roleid == 2|| obj.Roleid == 3)
            {

            }
            else 
            {
                obj.UserCreatedBy = obj.UserName;

            db.User_Table.Add(obj);
            db.SaveChanges();
            return RedirectToAction("login");
            }
            else
            {
                return RedirectToAction("errror");
            }
        }


        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(string user,string password)
        {
            User_Table obj = db.User_Table.Where(x => x.UserName == user).FirstOrDefault();
            if(obj!=null)
            {
                if(obj.Password==password)
      {
                        Session["user"] = obj.UserName;
                        return RedirectToAction("Index", "Admin");
                    }

                    {
                        Session["user"] = obj.UserName;
                        return RedirectToAction("Index", "Seller");
                    }

                    {
                        Session["user"] = obj.UserName;
                        return RedirectToAction("Index", "Service");
                    }
                    else if(obj.Roleid==4)
                    {
                        Session["user"] = obj.UserName;
                        return RedirectToAction("Index", "Buyer");
                    }
                    else
                    {
                        return RedirectToAction("errror");
                    }

                }
                else
                {
                    return View();
                   
                   
                }
            }
            else
            {
                return View();
            }


            //return View();
        }


        [HttpGet]
        public ActionResult errror()
        {
            return View();
        }
    }
}