using Common.Log;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TinyBlog.Common
{
    public class ExpFilter:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception exp = filterContext.Exception;

            Exception innerEx = exp.InnerException == null ? exp : exp.InnerException;

            while(innerEx.InnerException != null)
            {
                innerEx = innerEx.InnerException;
            }

            NLogLogger nlog = new NLogLogger();
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                nlog.Error(innerEx.Message);
                JsonConvert.SerializeObject(new { status = 1, msg = "Request Error, please contract Admin" });
            }
            else
            {
                nlog.Error("Error", exp);
                ViewResult viewResult = new ViewResult();
                viewResult.ViewName = "/Views/Shared/Error.cshtml";
                filterContext.Result = viewResult;
            }

            filterContext.ExceptionHandled = true;
            base.OnException(filterContext);
        }
    }
}