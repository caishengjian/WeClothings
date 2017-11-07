using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.AdvancedAPIs;//
using System.Configuration;//
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;//
using Senparc.Weixin.MP.Helpers;//

namespace WeClothings.Controllers
{
    /// <summary>
    /// 用来授权验证的类
    /// </summary>
    public class OAuthController : Controller
    {
        // GET: OAuth
        //生成授权页,同意授权
        //web.config中需要配置appID appsecret(方法中需要)
        public static readonly string appID = ConfigurationManager.AppSettings["appID"];
        public static readonly string appsecret = ConfigurationManager.AppSettings["appsecret"];
        public static readonly string Domin = "http://wx.caishengjian.xin";

        public ActionResult Index(string returnUrl)
        {
            //微信中使用的地址是外网 域名/returnUrl
            //构造带有域名的回调函数url 地址需要在函数中带有 $ 符号表示变量的占位符
            //var urr = "Domin/returnUrl";
            var redirect_uri = $"http://wx.caishengjian.xin{Url.Action("CallBack", new { returnUrl })}";
            //state可自定义，相当于一个验证码
            string state = "wx" + DateTime.Now.Millisecond;
            //把state保存下来
            Session["state"] = state;//验证比较之后清空
            string redirect = OAuthApi.GetAuthorizeUrl(appID, redirect_uri, state, Senparc.Weixin.MP.OAuthScope.snsapi_userinfo);//静默登录只能获得openid
                                                                                                                                 //此处授权验证地址是内置好的，只需要跳转请求即可
            return Redirect(redirect);//用户可以点击授权登录
        }
        //写回调函数，相当于用户点击授权之后返回的一个授权的凭证，状态码以及最初请求的第三方url
        public ActionResult CallBack(string code, string state, string returnUrl)
        {
            //比较state是否相同（相当于验证码的比较）
            if (Session["state"]?.ToString() != state)
            {
                Session["state"] = null;
                return Content("验证失败");
            }
            Session["state"] = null;
            //判断凭证code
            if (string.IsNullOrEmpty(code))
            {
                //返回授权页面
                return Content("你拒绝了授权");
            }
            //如果code存在则需要拿code换取oauthAccessToken  返回一个对象包含有oauthAccessToken
            var oauthAccessToken = OAuthApi.GetAccessToken(appID, appsecret, code);
            if (oauthAccessToken.errcode != Senparc.Weixin.ReturnCode.请求成功)
            {
                return Content($"错误消息：{oauthAccessToken.errmsg}");
            }
            Session["oauthAccessToken"] = oauthAccessToken;//保存共供过滤器判断
            try
            {
                OAuthUserInfo usrInfo = OAuthApi.GetUserInfo(oauthAccessToken.access_token, oauthAccessToken.openid);
                Session["usrInfo"] = usrInfo;
                return Redirect(returnUrl);
            }

            catch (Exception)
            {
                //如果获取用户信息异常，则需要用户重新请求授权页面
                var redirect_uri = $"http://wx.caishengjian.xin{Url.Action("CallBack", new { returnUrl })}";
                //state可自定义，相当于一个验证码
                state = "wx" + DateTime.Now.Millisecond;
                //把state保存下来
                Session["state"] = state;//验证比较之后清空
                var redirect = OAuthApi.GetAuthorizeUrl(appID, redirect_uri, state, Senparc.Weixin.MP.OAuthScope.snsapi_userinfo);//静默登录只能获得openid
                                                                                                                                  //此处授权验证地址是内置好的，只需要跳转请求即可
                return Redirect(redirect);//用户可以点击授权登录
            }
        }
        //配置js-sdk 
        public ActionResult JsSdkConfig()
        {
            //方法中的参数就是每一个需要使用的页面地址
            string url = $"{Domin}{Request.RawUrl}";
            JsSdkUiPackage jssdkpackage = JSSDKHelper.GetJsSdkUiPackage(appID, appsecret, url);
            return PartialView(jssdkpackage);
        }
    }
}