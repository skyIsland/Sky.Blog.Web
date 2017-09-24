using System;

namespace Sky.Common.Web
{
    /// <summary>
    /// Ajax返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AjaxResult<T>
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public bool Result { get; set; } = false;
        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; } = "Success";        
    }
    /// <summary>
    /// Ajax返回结果
    /// </summary>
    public class AjaxResult : AjaxResult<Object> { }

    public class DataResult : AjaxResult<Object>
    {
        /// <summary>
        /// 数据数量
        /// </summary>
        public int  Count { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>

        public int PageNo { get; set; }
    }
}
