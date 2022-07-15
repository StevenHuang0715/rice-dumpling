using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebsite.Models
{
    public class Index_Model
    {
        /// <summary>
        /// 行銷版面
        /// </summary>
        public List<Marketing> MarketItem { get; set; }

        /// <summary>
        /// 我們的商品版面
        /// </summary>
        public List<ProductGroup> GroupItem { get; set; }

        /// <summary>
        /// 商品磚
        /// </summary>
        public List<Gallery> GalleryItem { get; set; }
    }
}