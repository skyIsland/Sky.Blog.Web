using System.Web.Mvc;
using NewLife.Log;
using Sky.Common.Web;

namespace Sky.Web.Filter
{
    /// <inheritdoc />
    /// <summary>
    /// 拦截错误的特性
    /// </summary>
    public class MvcHandleErrorAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// 在发生异常时调用
        /// </summary>
        /// <param name="filterContext">异常上下文</param>
        public override void OnException(ExceptionContext filterContext)
        {
            var context = filterContext;
            //获取当前的请求对象
            var request = context.RequestContext.HttpContext.Request;
            #region 记录日志
            XTrace.WriteException(context.Exception);
            #endregion

            #region 处理错误
            //如果请求方式为AJax，将返回Json格式数据
            if (request.IsAjaxRequest())
            {
                var result = new JsonResult
                {
                    Data = new AjaxResult { Result = false, Message = context.Exception.Message },
                    ContentEncoding = System.Text.Encoding.UTF8,
                    ContentType = "text/plain"
                };
                if (request.HttpMethod.ToUpper() == "GET")
                    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

                context.Result = result;
            }
            else//非ajax
            {
                context.Result = new RedirectResult("/Error/Error500");
            }
            #endregion
            //设置为已处理
            context.ExceptionHandled = true;
            base.OnException(filterContext);
        }
    }
}