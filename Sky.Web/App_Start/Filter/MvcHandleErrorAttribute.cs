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
            XTrace.WriteException(filterContext.Exception);
            //判断是不是ajax请求
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {

                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.StatusCode = 200;
                filterContext.Result = new JsonResult { Data = new AjaxResult { Result = false, Message = filterContext.Exception.Message } };
            }
            base.OnException(filterContext);
        }
    }
}