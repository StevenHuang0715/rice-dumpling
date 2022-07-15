using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebsite.Models
{
    public class BuyPage01_Model
    {
        public bool isSuccess { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        public List<BuyAPge01_Details> Products { get; set; }

        /// <summary>
        /// 商品數量
        /// </summary>
        public string Qty { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
    }

    public class BuyAPge01_Details
    {
        /// <summary>
        /// 數量
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        public Product Produdt { get; set; }
    }
}