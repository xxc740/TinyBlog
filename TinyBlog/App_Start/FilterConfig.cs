using System.Web;
using System.Web.Mvc;
using TinyBlog.Common;

namespace TinyBlog
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new ExpFilter());
        }
    }
}
