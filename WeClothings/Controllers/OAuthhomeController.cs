using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.AdvancedAPIs;//
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;//
using WeClothings.Filters;//

namespace WeClothings.Controllers
{
    /// <summary>
    /// 这是用户请求的第三方网站（客户端）
    /// </summary>
    public class OAuthhomeController : Controller
    {
        // GET: OAuthhome
        public ActionResult Index()
        {
            var userinfo = Session["userinfo"] as OAuthUserInfo;
            return View(userinfo);
        }
    }
}