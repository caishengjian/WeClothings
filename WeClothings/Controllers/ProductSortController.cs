using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clothing.IService;
using Clothing.Model;

namespace WeClothings.Controllers
{
    public class ProductSortController : Controller
    {
        // GET: ProductSort
        public IProductSortService ProductSortService { get; set; }
        public IProductInfoService ProductInfoService { get; set; }
        public ActionResult Index()
        {           
            List<ProductSort> Sorts = ProductSortService.GetEntityes(x => true).ToList();
            ViewBag.Sortresult = Sorts;
            var s = ProductInfoService.GetEntityes(y => y.ProductSortId == Sorts[0].code);
            ViewBag.s = s;
            return View();//1235
        }
        public ActionResult ProSortdata()
        {
            string id = Request["id"];
            List<ProductInfo> s = ProductInfoService.GetEntityes(y => y.ProductSortId == id).ToList();
            string shtml = "";
            foreach (ProductInfo item in s)
            {
                shtml += "<li>" +
                            "<a class='imga' href='#'><img src = '/images/" + @item.images.ToString().Split(',')[1] + "' ></a>" +
                             "<a class='txta' href='search_list.aspx'>" +
                                "<span>" + @item.name + "</span>" +
                                "<i>" + @item.describe+ "</i>" +
                            "</a>" +
                        "</li>";
            }
            return Content(shtml);
        }
    }
}