using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebsite.Models
{
    public class EditProductPage_Model
    {
        /// <summary>
        /// 商品
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// 商品種類
        /// </summary>
        public string Group { get; set; }
    }
}