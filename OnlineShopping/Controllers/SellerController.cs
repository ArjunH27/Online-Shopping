using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.Controllers
{
    public class SellerController : Controller
    {
        ShoppingCartDbEntities db = new ShoppingCartDbEntities();
        SellerViewModel svm = new SellerViewModel();
        // GET: Seller
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {

           

                List<BaseCategory_Table> category = new List<BaseCategory_Table>();
                category = db.BaseCategory_Table.ToList();
                var productlist = new List<SelectListItem>();
                foreach (var item in category)
                {
                    productlist.Add(new SelectListItem
                    {
                        Text = item.BaseCatName.ToString(),
                        Value = item.BaseCatId.ToString(),

                    });
                
                ViewBag.basecategory = productlist;
            }
                return View();     
        }
        public ActionResult GetProductCat(string id)
        {
            int BaseCatId;
            List<SelectListItem> ProductcategoryList = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(id))
            {
                BaseCatId = Convert.ToInt32(id);
                List<ProductCategory_Table> productCategory = db.ProductCategory_Table.Where(x => x.BaseCatid == BaseCatId).ToList();
                foreach (var item in productCategory)
                {
                    ProductcategoryList.Add(new SelectListItem
                    {
                        Text = item.ProductCatName.ToString(),
                        Value = item.ProductCatId.ToString(),

                    });
                }
            }
            return Json(ProductcategoryList, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Create(Image_Table model, Product_Table product)
        {
            int j;
            Image_Table image = new Image_Table();
            if (ModelState.IsValid)
            {
                ShoppingCartDbEntities db = new ShoppingCartDbEntities();

                product.SellerId = 1;
                product.ProductCreatedBy = "swathy";//put session
                product.ProductCreatedDate = DateTime.Now;
                product.ProductUpdatedBy = "swathy";
                product.ProductUpdatedDate = DateTime.Now;
                product.ProductIsDeleted = false;
                db.Product_Table.Add(product);

                db.SaveChanges();


                object[] imgarray = new object[5];
                int p=product.ProductId;
                HttpPostedFileBase file = Request.Files["ImageData"];
                for (j = 0; j < Request.Files.Count; j++)
                {
                    file = Request.Files[j];

                    ContentRepository service = new ContentRepository();
                    image = service.UploadImageInDataBase(file, model);

                    Image_Table imageObj = new Image_Table();


                    imageObj.BinaryImage = image.BinaryImage;
                    imageObj.Productid = product.ProductId;
                    imageObj.ImageCreatedBy = "swathy";//put session
                    imageObj.ImageCreatedDate = DateTime.Now;
                    imageObj.ImageUpdatedBy = "swathy";
                    imageObj.ImageUpdatedDate = DateTime.Now;
                    imageObj.ImageIsDeleted = false;
                    db.Image_Table.Add(imageObj);
                    db.SaveChanges();
                }
            }
            return View("Index");

        }

    
    }

}