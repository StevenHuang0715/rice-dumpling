using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebsite.Models
{
    public class ProductPage_Model
    {
        /// <summary>
        /// 所選項目的ID
        /// </summary>
        public string SelectItemId { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        public List<ProductPage_Details> Products { get; set; }

        /// <summary>
        /// 商品種類
        /// </summary>
        public List<ProductGroup> GroupItem { get; set; }
    }

    public class ProductPage_Details
    {
        /// <summary>
        /// 商品
        /// </summary>
        public Product Product { get; set; }
    }
}