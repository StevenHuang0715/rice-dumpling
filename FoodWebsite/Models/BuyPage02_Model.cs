using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebsite.Models
{
    public class BuyPage02_Model
    {
        public bool isSuccess { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        public List<Product> Products { get; set; }

        /// <summary>
        /// 送回前一頁的數量
        /// </summary>
        public string Qty { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
    }
}