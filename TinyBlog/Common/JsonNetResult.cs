using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TinyBlog.Common
{
    public class JsonNetResult:JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if(context == null)
            {
                throw new ArgumentException(nameof(context));
            }

            var response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            if(ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            var jsonSerializerSetting = new JsonSerializerSettings();

            jsonSerializerSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSerializerSetting.DateFormatString = "yyyy-MM-dd HH:mm:ss";

            var json = JsonConvert.SerializeObject(Data, Formatting.None, jsonSerializerSetting);

            response.Write(json);
        }
    }
}