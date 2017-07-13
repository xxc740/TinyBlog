using Common.Log;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TinyBlog.Areas.Admin.Controllers
{
    public class BlogArticleController : Controller
    {
        private static NLogLogger log = new NLogLogger();

        // GET: Admin/BlogArticle
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult upload()
        {
            string savePath = "~/Areas/BlogPic";

            Hashtable extTable = new Hashtable();
            extTable.Add("img", "gif,jpg,jpeg,png,bmp");
            extTable.Add("flash", "swf,flv");
            extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
            extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");

            int maxSize = 102400000;

            HttpPostedFileBase imgFile = Request.Files["imgFile"];

            if(imgFile == null)
            {
                return Content("error|请选择文件！");
            }

            string dirPath = Server.MapPath(savePath);
            if (!Directory.Exists(dirPath))
            {
                log.Error("上传目录不存在");
                return Content("error|服务器内部错误！");
            }

            string dirName = Request.QueryString["dir"];
            if (string.IsNullOrEmpty(dirName))
            {
                dirName = "image";
            }
            if (!extTable.ContainsKey(dirName))
            {
                log.Error("目录名不正确");
                return Content("服务器内部错误！");
            }

            string fileName = imgFile.FileName;
            string fileExt = Path.GetExtension(fileName).ToLower();

            if(imgFile.InputStream == null || imgFile.InputStream.Length > maxSize){
                return Content("error|上传文件大小超过限制！");
            }

            if(string.IsNullOrEmpty(fileExt) || Array.IndexOf(((string)extTable[dirName]).Split(','),fileExt.Substring(1).ToLower()) == -1)
            {
                
                return Content("error|上传文件扩展名是不允许的扩展名。\n只允许" +((string)extTable[dirName]) + "格式");
            }

            dirPath += dirPath + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            string ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            dirPath += ymd + "/";

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;

            string filePath = dirPath + newFileName;
            imgFile.SaveAs(filePath);

            string fileUrl = savePath + "image/" + ymd + "/" + newFileName;
            return Content(fileUrl);
        }
    }
}