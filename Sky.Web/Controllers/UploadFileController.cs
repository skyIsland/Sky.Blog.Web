using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Sky.Common.Web;
using Sky.Core.Login;
using Sky.Models;
using Sky.Web.Filter;

namespace Sky.Web.Controllers
{
    public class UploadFileController : Controller
    {
        /// <summary>
        /// 缩略图根路径
        /// </summary>
        private string BaseThumbUrl = AppDomain.CurrentDomain.BaseDirectory ?? "/";
        
        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// <param name="FileID">文件ID</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <returns></returns>
        public ActionResult GetFile(Guid? id, int? width, int? height, string mode)
        {
            if (!id.HasValue)
            {
                Response.Write("文件不存在。");
                Response.End();
            }
            if (id == null)
            {
                id = Guid.NewGuid();

            }
            UploadFiles file = UploadFiles.FindById(id.Value);
            if (width.HasValue && height.HasValue)
            {
                if (!Directory.Exists(BaseThumbUrl + "tempfiles/imgThumb/"))
                    Directory.CreateDirectory(BaseThumbUrl + "tempfiles/imgThumb/");
                var files = System.IO.Directory.GetFiles(BaseThumbUrl + "tempfiles/imgThumb/", id.Value + "_" + width.Value + "_" + height.Value);
                string imgThumbName = "tempfiles/imgThumb/" + id.Value + "_" + width.Value + "_" + height.Value;
                if (files.Any())
                {
                    System.IO.FileInfo fs = new FileInfo(files[0]);
                    imgThumbName += fs.Extension;

                }
                else
                {

                    if (file == null)
                    {
                        return Content("文件不存在");
                    }
                    try
                    {
                        imgThumbName += file.FilesInfo.FileExt.ToLower();
                        ThumbMode m = ThumbMode.W;
                        if (!string.IsNullOrEmpty(mode))
                            m = ThumbMode.CUT;
                        MakeThumbnail(Server.MapPath(file.FilesInfo.FilePath), BaseThumbUrl + imgThumbName, width.Value, height.Value, m);
                    }
                    catch (Exception ex)
                    {
                        return Content(ex.Message);
                    }
                }
                //byte[] bytes = null;
                //using (FileStream fileStream = new FileStream(BaseThumbUrl + imgThumbName, FileMode.Open, FileAccess.Read, FileShare.Read))
                //{
                //    bytes = new byte[fileStream.Length];
                //    fileStream.Read(bytes, 0, bytes.Length);
                //}
                return File(BaseThumbUrl + imgThumbName, "image/Png");
            }
            if (file == null)
            {

                return Content("文件不存在");

            }
            file.Hits++;
            if (!file.FilesInfo.IsImg && !file.FilesInfo.FileExt.ToLower().EndsWith("swf"))
            {
                Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(file.FilesInfo.FileName.Replace(file.FilesInfo.FileExt, "") + file.FilesInfo.FileExt, System.Text.Encoding.UTF8));
                return File(file.FilesInfo.FilePath, file.FilesInfo.FileType);
            }
            return File(file.FilesInfo.FilePath, file.FilesInfo.FileType);
        }
        [EntityAuthorize]
        public ActionResult SaveFiles(bool isCut=false,bool isMd=false)
        {                    
            var infoId = Guid.NewGuid();
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                if (file == null || file.ContentLength == 0)
                {
                    if (isMd)
                    {
                        return Json(new EditorMdResult() {message = "未选择文件或者文件大小为0"});
                    }
                    return Json(new LayUiResult { msg = "未选择文件或者文件大小为0" });
                }
                FileInfo fo = new FileInfo(file.FileName);
                int intDocLen = file.ContentLength;
                byte[] Docbuffer = new byte[intDocLen];
                file.InputStream.Read(Docbuffer, 0, intDocLen);
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] bytHash = md5.ComputeHash(Docbuffer);
                string FileHash = BitConverter.ToString(bytHash);
                FilesInfo files = FilesInfo.FindBybytHash(FileHash);
                string basePath = "/BaseUploadFiles/" + DateTime.Now.ToString("yyyy/MM/dd/") + FileHash.Replace("-", "") + fo.Extension;
                if (files == null)
                {
                    files = new FilesInfo();
                    files.CreateDate = DateTime.Now;
                    //files.FileContent = Docbuffer;
                    files.FileExt = fo.Extension;
                    files.FileSize = FormatFileSize(file.ContentLength);
                    files.FileName = fo.Name;
                    files.FileType = file.ContentType;
                    files.IsImg = CheckFileIsImg(files.FileExt);
                    files.bytHash = FileHash;
                    files.FilePath = basePath;
                    files.Insert();
                }
                else
                {
                    basePath = files.FilePath;
                }
                System.IO.FileInfo sf = new FileInfo(Server.MapPath(basePath));
                if (!sf.Exists || sf.Length == 0)
                {
                    if (!Directory.Exists(sf.DirectoryName))
                    {
                        Directory.CreateDirectory(sf.DirectoryName);
                    }
                    using (FileStream fs = new FileStream(sf.FullName, FileMode.Create))
                    {
                        BinaryWriter bw = new BinaryWriter(fs);
                        bw.Write(Docbuffer);
                        bw.Close();
                    }
                }
                Docbuffer = null;
                UploadFiles fileInfo;
                fileInfo = new UploadFiles();
                fileInfo.Id = infoId;
                fileInfo.CreatBy = UserLogin.CurrUserData == null ? "" : UserLogin.CurrUserData.LoginName;
                fileInfo.FilesInfoID = files.ID;
                fileInfo.Insert();

                var fileUrl = fileInfo.FilesInfo.IsImg
                    ? "/UploadFile/GetFile/?id=" + fileInfo.Id + (isCut ? "&width=300&height=150" : "")
                    : "/UploadFile/GetFile/" + fileInfo.Id;
                if (isMd)
                {
                    return Json(new EditorMdResult() {success = 1, message = "上传成功", url = fileUrl });
                }
                var data=new MyData
                {
                    src =fileUrl,
                    title = files.FileName
                };
                return Json(new LayUiResult {
                    code = 0,
                    data= data,
                    msg = "上传成功"
                });
            }
            if (isMd)
            {
                return Json(new EditorMdResult() {message = "请选择要上传的文件"});
            }          
            return Json(new LayUiResult { msg = "请选择要上传的文件" });
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelFileInfos(Guid id)
        {
            UploadFiles file = UploadFiles.FindById(id);
            if (file != null)
            {
                var lst = UploadFiles.FindAll("bytHash", file.FilesInfo.bytHash);
                if (lst.Count == 1)
                {
                    System.IO.FileInfo sf = new FileInfo(Server.MapPath(file.FilesInfo.FilePath));
                    if (sf.Exists)
                        sf.Delete();
                    //  file.MyFilesInfo.Delete();
                    FilesInfo f = FilesInfo.FindByID(file.FilesInfoID);
                    if (f != null)
                        f.Delete();
                }
                file.Delete();
            }
            return Json(null);
        }

        #region 方法 -- 生成缩略图
        /**/
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图（二进制数据）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>   
        public static void MakeThumbnail(String originalImagePath, string thumbnailPath, int width, int height, ThumbMode mode = ThumbMode.AUTO)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);
            FileInfo f = new FileInfo(thumbnailPath);
            if (!Directory.Exists(f.DirectoryName))
                Directory.CreateDirectory(f.DirectoryName);
            int towidth = width;
            int toheight = height;
            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            if (ow < towidth && oh < toheight)
            {
                originalImage.Save(thumbnailPath);
            }
            else
            {

                switch (mode)
                {
                    case ThumbMode.HW://指定高宽缩放（可能变形）           
                        break;
                    case ThumbMode.W://指定宽，高按比例
                        toheight = originalImage.Height * width / originalImage.Width;
                        break;
                    case ThumbMode.H://指定高，宽按比例
                        towidth = originalImage.Width * height / originalImage.Height;
                        break;
                    case ThumbMode.CUT://指定高宽裁减（不变形）           
                        if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                        {
                            oh = originalImage.Height;
                            ow = originalImage.Height * towidth / toheight;
                            y = 0;
                            x = (originalImage.Width - ow) / 2;
                        }
                        else
                        {
                            ow = originalImage.Width;
                            oh = originalImage.Width * height / towidth;
                            x = 0;
                            y = (originalImage.Height - oh) / 2;
                        }
                        break;
                    case ThumbMode.AUTO: //自动适应高度
                        if (ow > oh)
                        {
                            //newwidth = 200;
                            toheight = (int)((double)oh / (double)ow * (double)towidth);
                        }
                        else
                        {
                            //newheight = 200;
                            towidth = (int)((double)ow / (double)oh * (double)toheight);
                        }
                        break;
                    default:
                        break;
                }

                //进行缩图
                Bitmap img = new Bitmap(towidth, toheight);
                img.SetResolution(72f, 72f);
                Graphics gdiobj = Graphics.FromImage(img);
                gdiobj.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                gdiobj.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gdiobj.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gdiobj.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                gdiobj.FillRectangle(new SolidBrush(Color.White), 0, 0,
                                towidth, toheight);
                Rectangle destrect = new Rectangle(0, 0,
                                towidth, toheight);
                gdiobj.DrawImage(originalImage, destrect, 0, 0, ow,
                                oh, GraphicsUnit.Pixel);
                System.Drawing.Imaging.EncoderParameters ep = new System.Drawing.Imaging.EncoderParameters(1);
                ep.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)100);
                System.Drawing.Imaging.ImageCodecInfo ici = GetEncoderInfo("image/jpeg");
                try
                {

                    if (ici != null)
                    {
                        img.Save(thumbnailPath, ici, ep);
                    }
                    else
                    {
                        img.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                catch (System.Exception e)
                {
                    throw e;
                }
                finally
                {
                    gdiobj.Dispose();
                    img.Dispose();
                }
            }
            originalImage.Dispose();
        }


        private static System.Drawing.Imaging.ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            System.Drawing.Imaging.ImageCodecInfo[] encoders;
            encoders = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        #endregion

        #region"方法--通过文件后缀名判断是否是图片"
        private bool CheckFileIsImg(string filetype)
        {
            if (string.IsNullOrEmpty(filetype))
                return false;
            filetype = filetype.ToLower().Replace(".", "");
            switch (filetype)
            {
                case "gif":
                case "png":
                case "jpg":
                case "jpeg":
                case "bmp":
                    return true;
                default:
                    return false;
            }
        }
        #endregion
        #region "格式化文件大小样式"
        /// <summary>
        /// 格式化文件大小样式
        /// </summary>
        /// <param name="fileSize">文件大小</param>
        /// <returns></returns>
        public static string FormatFileSize(int fileSize)
        {
            return FormatFile(fileSize);
        }
        /// <summary>
        /// 返回文件大小KB
        /// </summary>
        /// <param name="_filepath">文件相对路径</param>
        /// <returns>int</returns>
        public static int GetFileSize(string _filepath)
        {
            if (string.IsNullOrEmpty(_filepath))
            {
                return 0;
            }
            string fullpath = GetMapPath(_filepath);
            if (System.IO.File.Exists(fullpath))
            {
                FileInfo fileInfo = new FileInfo(fullpath);
                return ((int)fileInfo.Length) / 1024;
            }
            return 0;
        }
        #endregion
        #region 获得当前绝对路径
        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (strPath.ToLower().StartsWith("http://"))
            {
                return strPath;
            }
            if (System.Web.HttpContext.Current != null)
            {
                return System.Web.HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }
        #endregion
        #region "格式化文件大小样式"
        /// <summary>
        /// 格式化文件大小样式（返回MB、KB或者Byte)
        /// </summary>
        /// <param name="fileSize">文件大小</param>
        /// <returns></returns>
        public static string FormatFile(long fileSize)
        {
            string str;
            if (fileSize > 1048576)
            {
                str = Math.Round(Convert.ToDouble(fileSize / 1048576), 2).ToString() + " MB";
            }
            else if (fileSize > 1024)
            {
                str = Math.Round(Convert.ToDouble(fileSize / 1024), 2).ToString() + " KB";
            }
            else
            {
                str = fileSize.ToString() + " byte";
            }
            return str;
        }
        #endregion
        /// <summary>
        /// 返回文件扩展名，不含“.”
        /// </summary>
        /// <param name="_filepath">文件全名称</param>
        /// <returns>string</returns>
        public static string GetFileExt(string _filepath)
        {
            if (string.IsNullOrEmpty(_filepath))
            {
                return "";
            }
            if (_filepath.LastIndexOf(".") > 0)
            {
                return _filepath.Substring(_filepath.LastIndexOf(".") + 1); //文件扩展名，不含“.”
            }
            return "";
        }
        /// <summary>
        /// 获取图片拍摄时间
        /// </summary>
        /// <param name="parr"></param>
        /// <returns></returns>
        private DateTime? GetTakePicDateTime(System.Drawing.Imaging.PropertyItem[] parr)
        {
            DateTime? d = null;
            Encoding ascii = Encoding.ASCII;
            //遍历图像文件元数据，检索所有属性
            foreach (System.Drawing.Imaging.PropertyItem p in parr)
            {
                //如果是PropertyTagDateTime，则返回该属性所对应的值
                if (p.Id == 306)
                {
                    var m = ascii.GetString(p.Value).Replace("\0", "");
                    DateTime dt;
                    var arr = m.Split(' ');
                    if (DateTime.TryParse(arr[0].Replace(":", "-") + " " + arr[1], out dt))
                    {
                        d = dt;
                    }
                    break;
                }
            }
            //若没有相关的EXIF信息则返回N/A
            return d;
        }
        /// <summary>
        /// 获取图片相关属性
        /// </summary>
        /// <param name="parr">图片文件属性集合</param>
        /// <param name="id">获取的属性（271相机制造商，272相机型号）</param>
        /// <returns></returns>
        private string GetImagesPropertyItem(System.Drawing.Imaging.PropertyItem[] parr, int id = 271)
        {
            string str = "";
            Encoding ascii = Encoding.ASCII;
            //遍历图像文件元数据，检索所有属性
            foreach (System.Drawing.Imaging.PropertyItem p in parr)
            {
                //如果是PropertyTagDateTime，则返回该属性所对应的值
                if (p.Id == id)
                {
                    str = ascii.GetString(p.Value);
                    if (!string.IsNullOrEmpty(str))
                        str = str.Replace("\0", "");
                    break;
                }
            }
            //若没有相关的EXIF信息则返回N/A
            return str;
        }
    }
    /// <summary>
    /// 缩略图生成方式
    /// </summary>
    public enum ThumbMode
    {
        /// <summary>
        /// 指定高宽缩放（可能变形）
        /// </summary>
        HW,
        /// <summary>
        /// 指定宽，高按比例
        /// </summary>
        W,
        /// <summary>
        /// 指定高，宽按比例
        /// </summary>
        H,
        /// <summary>
        /// 指定高宽裁减（不变形）
        /// </summary>
        CUT,
        /// <summary>
        /// 自动适应高度
        /// </summary>
        AUTO

    }
}