using System;

namespace Sky.Common.Web
{
    /// <summary>
    /// Ajax返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AjaxResult<T>
    {
        public bool Result { get; set; } = false;
        public T Data { get; set; }
        public string Message { get; set; } = "Success";        
    }
    /// <summary>
    /// Ajax返回结果
    /// </summary>
    public class AjaxResult : AjaxResult<Object> { }
}
