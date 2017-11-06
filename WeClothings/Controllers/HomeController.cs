using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clothing.IService;//
using Clothing.Model;//


namespace WeClothings.Controllers
{
    //微商城首页
    //注意UI下WeClothings要下载Autofac  Autofac.Mvc5
    public class HomeController : Controller
    {
        // GET: Home
        //查询Banner,从数据库中查询
        public IBannerService BannerService { get; set; }
        public IProductInfoService ProductInfoService { get; set; }
        public INoticeService NoticeService { get; set; }      
        public ActionResult Index()
        {
            var BannerResult = BannerService.GetEntityes(x => true);
            ViewBag.Banner = BannerResult.ToList();
            
            var ProductInfoResult = ProductInfoService.GetEntityes(x => true);
            ViewBag.ProductInfo = ProductInfoResult.ToList();

            var NoticeResult = NoticeService.GetEntityes(x => true);
            ViewBag.Notice = NoticeResult.ToList();
            return View();
        }
        //搜索
        //public ActionResult Search()
        //{
        //    return PartialView();
        //}     
    }
}