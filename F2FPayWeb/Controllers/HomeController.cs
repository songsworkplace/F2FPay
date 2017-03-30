using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Common.F2FPay;
using Common.F2FPay.AliPay;
using Common.F2FPay.AliPay.Domain;
using Common.F2FPay.Domain;
using Common.F2FPay.Weixin;

namespace F2FPayWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewData["resultMsg"] = "";
            return View();
        }
        #region 支付宝
        
        public ActionResult OrderPay()
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var model = new OrderPayDTO();
#if DEBUG
            DateTime dt1 = new DateTime(2016, 6, 6, 11, 10, 50);
            DateTime dt2 = DateTime.Now;
            var num = (int)dt2.Subtract(dt1).TotalMinutes;
            model.Body = "商品测试" + num;
            model.OutTradeNo = num.ToString();
            model.StoreId = "storeid-" + num;
            model.TerminalId = "终端-" + num;
            model.Title = "标题" + num;
            model.TotalAmount = "0.1";
            model.OperatorId = "员工" + num;
#endif
            AlipayConfig config = AlipayConfig.CreateInstance();
            ViewData["resultMsg"] = string.Format("配置：{0}<br/>CurrentAlipayAuthToken:{1}", jss.Serialize(config), Session["CurrentAlipayAuthToken"]);
            return View(model);
        }
        [HttpPost]
        public ActionResult OrderPay(OrderPayDTO model)
        {
            IF2FTradeService service = new AliPayTradeService();
            try
            {
                if (Session["CurrentAlipayAuthToken"] != null && !string.IsNullOrEmpty(Session["CurrentAlipayAuthToken"].ToString()))
                    service.SetAuthToken(Session["CurrentAlipayAuthToken"].ToString());
                var result = service.OrderPay(model);

                ViewData["resultMsg"] = string.Format("http路径：{0}<br/>http请求内容：{1}<br/>响应结果为：{2}<br/>CurrentAlipayAuthToken:{3}", result.RequestUrl, result.RequestContent, result.ResponseBody, Session["CurrentAlipayAuthToken"]);

                ViewData["OnlineTradeNo"] = result.OnlineTradeNo;
            }
            catch (F2FPayException e)
            {
                ViewData["resultMsg"] = string.Format("发生异常为：{0}", e);
            }
            return View(model);
        }
        /// <summary>
        /// 订单退款
        /// </summary>
        /// <returns></returns>
        public ActionResult RefundOrder(RefundDTO dto)
        {
            try
            {
                IF2FTradeService service = new AliPayTradeService();
                if (Session["CurrentAlipayAuthToken"] != null && !string.IsNullOrEmpty(Session["CurrentAlipayAuthToken"].ToString()))
                    service.SetAuthToken(Session["CurrentAlipayAuthToken"].ToString());
                var result = service.Refund(dto);
                return Content(string.Format("传参值：{0}<br/>请求结果：{1}<br/>CurrentAlipayAuthToken:{2}", new JavaScriptSerializer().Serialize(dto), result.ResponseBody, Session["CurrentAlipayAuthToken"]));
            }
            catch (Exception e)
            {
                return Content(string.Format("发生异常：{0}", e.Message));
            }

        }
        /// <summary>
        /// 支付宝回调页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AlipayCallback()
        {
            ViewData["Querys"] = Request.QueryString;
            ViewData["Forms"] = Request.Form;
            //ViewData["Params"] = Request.Params;
            ViewData["HostUrl"] = string.Format("http://{0}", Request.Url.Host);
            return View();
        }
        [HttpPost]
        public ActionResult AlipayCallback(string app_id, string source, string app_auth_code)
        {
            AlipayAuthService service = new AlipayAuthService();
            var result = service.OpenAuthTokenApp(new OpenAuthTokenAppDTO { code = app_auth_code, grant_type = "authorization_code" });
            Session["CurrentAlipayAuthToken"] = result.AppAuthToken;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return Content(string.Format("结果：{0}<br/>CurrentAlipayAuthToken：{1}", jss.Serialize(result), Session["CurrentAlipayAuthToken"]));
        }
        /// <summary>
        /// 授权跳转
        /// </summary>
        /// <returns></returns>
        public ActionResult AlipayRedirect()
        {
            AlipayAuthService service = new AlipayAuthService();
            var url = service.GetAuthUri(string.Format("http://{0}/home/alipaycallback", Request.Url.Host));
            return Redirect(url);
        }

        #endregion

        #region 微信

        public ActionResult WeixinOrderPay()
        {
            var model = new OrderPayDTO();
            DateTime dt1 = new DateTime(2016, 6, 6, 11, 10, 50);
            DateTime dt2 = DateTime.Now;
            var num = (int)dt2.Subtract(dt1).TotalMinutes;
            model.Body = "商品测试" + num;
            model.OutTradeNo = num.ToString();
            model.StoreId = "storeid-" + num;
            model.TerminalId = "8.8.8.8";
            model.Title = "标题" + num;
            model.TotalAmount = "0.1";
            model.OperatorId = "员工" + num;
            return View(model);
        }
        [HttpPost]
        public ActionResult WeixinOrderPay(OrderPayDTO model)
        {
            IF2FTradeService service = new WeixinTradeService();
            service.SetAuthToken("1366316402");
            var result=service.OrderPay(model);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ViewData["resultMessage"] = string.Format("运行结果：{0}", jss.Serialize(result)); ;
            return View(model);
        }

        /// <summary>
        /// 订单退款
        /// </summary>
        /// <returns></returns>
        public ActionResult RefundOrderWeixin(RefundDTO dto)
        {
            try
            {
                IF2FTradeService service = new WeixinTradeService();
                service.SetAuthToken("1366316402");
                dto.OperatorId = "111";
                var result = service.Refund(dto);
                return Content(string.Format("传参值：{0}<br/>请求结果：{1}<br/>子商户:{2}", new JavaScriptSerializer().Serialize(dto), result.ResponseBody, "1366316402"));
            }
            catch (Exception e)
            {
                return Content(string.Format("发生异常：{0}", e.Message));
            }

        }
        #endregion
    }
}
