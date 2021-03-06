﻿using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping
{
    public class SellerViewModel
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDesc { get; set; }
        public int ProductStock { get; set; }
        public byte[] BinaryImage { get; set; }
        public IList<BaseCategory_Table> BaseProducts { get; set; }
        public IList<Image_Table> image { get; set; }
        public int ProductCatId { get; set; }

        public List<SelectListItem> categorylist = new List<SelectListItem>();
    }
}