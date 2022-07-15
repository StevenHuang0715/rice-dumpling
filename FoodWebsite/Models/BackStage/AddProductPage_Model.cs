using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWebsite.Models.BackStage
{
    public class AddProductPage_Model
    {

        public Product Product { get; set; }

        /// <summary>
        /// 商品類別列表
        /// </summary>
        public List<SelectListItem> GroupList { get; set; }
    }
}