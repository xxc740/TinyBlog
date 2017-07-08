using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TinyBlog.Common;

namespace TinyBlog.Controllers
{
    public class BaseController : Controller
    {
        protected override JsonResult Json(object data, string contentType, Encoding contentConding,JsonRequestBehavior behavior)
        {
            return new JsonNetResult { Data = data, ContentType = contentType, ContentEncoding = contentConding, JsonRequestBehavior = behavior };
        }
    }
}