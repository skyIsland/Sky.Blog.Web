using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Common.Web
{
    /// <summary>
    /// LayUi编辑器图片上传返回接口
    /// </summary>
    public class LayUiResult
    {
        /// <summary>
        /// 返回结果 0表示成功，其它失败
        /// </summary>
        public int code { get; set; } = -1;
        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public MyData data { get; set; }
    }

    public class MyData
    {
        /// <summary>
        /// 图片路径
        /// </summary>
        public string src { get; set; }
        /// <summary>
        /// 图片标题
        /// </summary>

        public  string title { get; set; }
    }
}
