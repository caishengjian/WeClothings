using Senparc.Weixin.MP.AdvancedAPIs.OAuth;//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clothing.IService;//
using Clothing.Model;//
using WeClothings.Filters;//



namespace WeClothings.Controllers
{
    [OAuth]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ICustomerService CustomerService { get; set; }
        public ActionResult Index()
        {
            var userinfo = Session["usrInfo"] as OAuthUserInfo;//????看看开发文档                                 
            var CustomerResult = CustomerService.GetEntityes(x => x.openid == userinfo.openid).ToList();
            if (CustomerResult == null)
            {
                Customer cus = new Customer();
                cus.cid = userinfo.openid;
                cus.image = userinfo.headimgurl;
                cus.nickname = userinfo.nickname;
                cus.openid = userinfo.openid;
                cus.tel = "";
                cus.address = userinfo.country + userinfo.province + userinfo.city;
                CustomerService.Add(cus);
            }

            return View(userinfo);
        }
    }
}