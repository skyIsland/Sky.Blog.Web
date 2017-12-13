using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Common.Web
{
    public class EditorMdResult
    {
        /// <summary>
        /// 返回状态码1成功
        /// </summary>
        public int success { get; set; }
        /// <summary>
        /// 提示的信息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 图片地址 上传成功时才返回
        /// </summary>
        public string url { get; set; }
    }
}
