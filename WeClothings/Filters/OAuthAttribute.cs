using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeClothings.Filters
{
    /// <summary>
    /// 先判断用户是否拥有访问第三方网站的权限
    /// </summary>
    public class OAuthAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["oauthAccessToken"] == null)
            {
                //如果不满足条件跳转到授权页面，要带有一个参数returnUrl
                //1.获取用户当前需要访问的页面的url,本地的
                string returnUrl = filterContext.HttpContext.Request.RawUrl;//RawUrl是获取当前请求的完整url
                //2.带参数地址进入授权页面
                UrlHelper url = new UrlHelper(filterContext.RequestContext);
                filterContext.Result = new RedirectResult(url.Action("Index", "OAuth", new { returnUrl }));
            }
        }
    }
}