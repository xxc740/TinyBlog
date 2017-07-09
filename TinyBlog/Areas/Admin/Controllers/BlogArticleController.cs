using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TinyBlog.Areas.Admin.Controllers
{
    public class BlogArticleController : Controller
    {
        // GET: Admin/BlogArticle
        public ActionResult Index()
        {
            return View();
        }
    }
}