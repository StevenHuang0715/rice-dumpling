using FoodWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWebsite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DBEntities ctx = new DBEntities();
            Index_Model model = new Index_Model();

            #region 行銷版面
            model.MarketItem = ctx.Marketings.ToList();
            #endregion

            #region 我們的商品版面
            model.GroupItem = ctx.ProductGroups.ToList();

            #endregion
            model.GalleryItem = ctx.Galleries.ToList();

            #region 商品圖片
            

            #endregion
            return View(model);
        }

        /// <summary>
        /// 產品頁
        /// </summary>
        /// <param name="selectId">要預設顯示的商品種類Id</param>
        /// <returns></returns>
        public ActionResult ProductPage(string selectId)
        {
            DBEntities ctx = new DBEntities();
            ProductPage_Model model = new ProductPage_Model
            {
                Products = new List<ProductPage_Details>()
            };
            model.SelectItemId = selectId ?? "1";
            foreach (Product item in ctx.Products)
            {
                ProductPage_Details m = new ProductPage_Details
                {
                    Product = item
                };
                model.Products.Add(m);
            }
            #region 小圖示資料
            model.GroupItem = ctx.ProductGroups.ToList();
            #endregion

            return View(model);
        }

        public ActionResult TestPage()
        {

            return View();
        }

        public ActionResult ContactPage()
        {

            return View();
        }

        public ActionResult AboutPage()
        {

            return View();
        }

        public ActionResult BuyPage01(BuyPage02_Model Model)
        {
            DBEntities ctx = new DBEntities();
            BuyPage01_Model model = new BuyPage01_Model
            {
                Products = new List<BuyAPge01_Details>()
            };

            var allProducts = new List<Product>();
            if (Session["allProducts"] == null)
            {
                allProducts = ctx.Products.ToList();
                Session["allProducts"] = allProducts;
            }
            else
            {
                allProducts = (List<Product>)Session["allProducts"];
            }
            
            foreach (Product item in allProducts)
            {
                BuyAPge01_Details prod = new BuyAPge01_Details
                {
                    Produdt = item
                };

                model.Products.Add(prod);
            }
            
            #region 從上一頁傳來的
            if (Model.Id != null)
            {
                //TODO:輸入數量
                string[] idList = Model.Id.Split(',');
                string[] qtyList = Model.Qty.Split(',');
                for (int i = 0; i < idList.Count()-1; i++)
                {
                    BuyAPge01_Details selectProd = model.Products.Find(m => m.Produdt.Id == int.Parse(idList[i]));
                    int index = model.Products.IndexOf(selectProd);
                    model.Products.ElementAt(index).Amount = qtyList[i];
                }
            }
            #endregion
            return View(model);
        }
        [HttpPost]
        public ActionResult BuyPage02(BuyPage01_Model Model)
        {
            BuyPage02_Model model = new BuyPage02_Model();
            model.Products = new List<Product>();

            List<Product> allProducts = (List<Product>)Session["allProducts"];
            List<string> qtyList = Model.Qty.Split(',').ToList();
            List<string> idList = Model.Id.Split(',').ToList();

            for (int i = 0; i < qtyList.Count - 1; i++)
            {
                if (qtyList[i] != ""&& qtyList[i] != "0")
                {
                    int index;
                    if (int.TryParse(idList[i], out index))
                    {
                        Product product = allProducts.SingleOrDefault(p => p.Id == index);
                        model.Qty += qtyList[i] + ",";
                        model.Id += index.ToString() + ",";
                        model.Products.Add(product);
                    }
                }
            }
            return View(model);
        }
    }
}