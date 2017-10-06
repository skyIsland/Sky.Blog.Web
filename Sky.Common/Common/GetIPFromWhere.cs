using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace Sky.Common.Common
{
    /// <summary>
    /// 定位Ip(支持国内ip)
    /// </summary>
    public class GetIpFromWhere
    {
        /// <summary>  
        /// Ip异步解析  
        /// </summary>  
        /// <param name="strIp">需要解析的IP地址</param>  
        /// <param name="key">调用接口的key</param>  
        /// <returns></returns>  
        public static async Task<string> GetPositionAsync(string strIp,string key)
        {
            var msg = string.Empty;
            var url = "http://restapi.amap.com/v3/ip?ip="+strIp+"&key="+key;
            var http = new HttpClient();
            var response = await http.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jss=new JavaScriptSerializer();
            var resultStr = await response.Content.ReadAsStringAsync();
            try
            {
                var result = jss.Deserialize<IpPosition>(resultStr);
                if (result.status.Equals("1"))
                {
                    msg = result.province +","+result.city;
                }
            }
            catch (Exception)
            {
                msg = "错误,无法解析Ip来源!";
            }
           
            return msg;                     
        }
        /// <summary>  
        /// Ip解析  
        /// </summary>  
        /// <param name="strIp">需要解析的IP地址</param>  
        /// <param name="key">调用接口的key</param>  
        /// <returns></returns>  
        public static string GetPosition(string strIp, string key)
        {
            var msg = string.Empty;
            var url = "http://restapi.amap.com/v3/ip?ip=" + strIp + "&key=" + key;
            var http = new WebClient {Encoding = Encoding.UTF8};
            var response = http.DownloadString(url);          
            var jss = new JavaScriptSerializer();
            try
            {
                var result = jss.Deserialize<IpPosition>(response);
                if (result.status.Equals("1"))
                {
                    msg = result.province + "," + result.city;
                }
            }
            catch (Exception)
            {
                msg = "错误,无法解析Ip来源!";
            }

            return msg;            
        }
    }
    /// <summary>
    /// 接口返回类
    /// </summary>
    public class IpPosition
    {
        /// <summary>
        /// 返回结果状态值
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 返回状态说明
        /// </summary>
        public string info { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        public string infocode { get; set; }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 城市的adcode编码
        /// </summary>
        public string adcode { get; set; }
        /// <summary>
        /// 所在城市矩形区域范围
        /// </summary>
        public string rectangle { get; set; }
    }

}