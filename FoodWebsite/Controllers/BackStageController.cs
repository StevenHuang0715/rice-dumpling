using FoodWebsite.Models;
using FoodWebsite.Models.BackStage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWebsite.Controllers
{
    public class BackStageController : Controller
    {
        // GET: BackStage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProductPage()
        {
            AddProductPage_Model model = new AddProductPage_Model();
            DBEntities ctx = new DBEntities();

            var groups = ctx.ProductGroups.ToList();
            model.GroupList = new List<SelectListItem>();
            foreach (var item in groups)
            {
                SelectListItem s = new SelectListItem();
                s.Text = item.Name;
                s.Value = item.ProductGroupsId.ToString();
                model.GroupList.Add(s);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AddProductPage02(AddProductPage_Model Model, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3)
        {
            DBEntities ctx = new DBEntities();
            foreach (HttpPostedFileBase item in new List<HttpPostedFileBase> { Image1, Image2, Image3 })
            {
                if (item != null)
                {
                    string FileName = Path.GetFileName(item.FileName);
                    string FilePath = Path.Combine(Server.MapPath("~/images/Food/"), FileName);
                    item.SaveAs(FilePath);
                }
            }

            Product prod = new Product
            {
                Name = Model.Product.Name,
                Price = Model.Product.Price,
                Stock = Model.Product.Stock,
                Descrition = Model.Product.Descrition,
                Group = Model.Product.Group,
                Image1 = Image1 != null ? "/images/Food/" + Path.GetFileName(Image1.FileName) : null,
                Image2 = Image2 != null ? "/images/Food/" + Path.GetFileName(Image2.FileName) : null,
                Image3 = Image3 != null ? "/images/Food/" + Path.GetFileName(Image3.FileName) : null
            };

            ctx.Products.Add(prod);
            ctx.SaveChanges();

            return View();
        }

        public ActionResult ProductListPage()
        {
            DBEntities ctx = new DBEntities();
            ProductList_Model model = new ProductList_Model
            {
                Products = ctx.Products.ToList()
            };

            //轉換商品類別
            for (int i = 0; i < model.Products.Count; i++)
            {
                int index = int.Parse(model.Products[i].Group);
                model.Products[i].Group = ctx.ProductGroups.SingleOrDefault(g => g.ProductGroupsId == index).Name;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult EditProductPage(int ProdId)
        {
            DBEntities ctx = new DBEntities();

            EditProductPage_Model model = new EditProductPage_Model
            {
                Product = ctx.Products.SingleOrDefault(p => p.Id == ProdId)
            };
            if (ctx.ProductGroups.SingleOrDefault(p => p.ProductGroupsId.ToString() == model.Product.Group) != null)
            {
                model.Group = ctx.ProductGroups.SingleOrDefault(p => p.ProductGroupsId.ToString() == model.Product.Group).Name;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditProductPage02(EditProductPage_Model Model, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3)
        {
            DBEntities ctx = new DBEntities();
            foreach (HttpPostedFileBase item in new List<HttpPostedFileBase> { Image1, Image2, Image3 })
            {
                if (item != null)
                {
                    string FileName = Path.GetFileName(item.FileName);
                    string FilePath = Path.Combine(Server.MapPath("~/images/Food/"), FileName);
                    item.SaveAs(FilePath);
                }
            }


            Product editProd = ctx.Products.SingleOrDefault(m => m.Id == Model.Product.Id);
            if (editProd != null)
            {
                editProd.Name = Model.Product.Name ?? editProd.Name;
                editProd.Group = Model.Product.Group ?? editProd.Group;
                editProd.Price = Model.Product.Price == 0 ? editProd.Price : Model.Product.Price;
                editProd.Stock = Model.Product.Stock == 0 ? editProd.Stock : Model.Product.Stock;
                editProd.Descrition = Model.Product.Descrition ?? editProd.Descrition;
                editProd.Image1 = Image1 == null ? Model.Product.Image1 : "/images/Food/" + Path.GetFileName(Image1.FileName);
                editProd.Image2 = Image2 == null ? Model.Product.Image2 : "/images/Food/" + Path.GetFileName(Image2.FileName);
                editProd.Image3 = Image3 == null ? Model.Product.Image3 : "/images/Food/" + Path.GetFileName(Image3.FileName);

                ctx.SaveChanges();
            }

            return RedirectToAction("ProductListPage");
        }

        [HttpPost]
        public ActionResult DelProduct(int ProdId)
        {
            DBEntities ctx = new DBEntities();
            Product delProd = ctx.Products.SingleOrDefault(p => p.Id == ProdId);
            ctx.Products.Remove(delProd);
            ctx.SaveChanges();

            return RedirectToAction("ProductListPage");
        }
    }
}