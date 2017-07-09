using System.Web;
using System.Web.Optimization;

namespace TinyBlog
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/js/jquery").Include(
           "~/bower_components/jquery/dist/jquery.js"));

            bundles.Add(new ScriptBundle("~/js/jqueryval").Include(
                        "~/bower_components/jquery-validation/dist/jquery.validate"));

            bundles.Add(new ScriptBundle("~/js/bootstrap").Include("~/bower_components/bootstrap/dist/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/js/tether").Include("~/bower_components/tether/dist/js/tether.js"));

            bundles.Add(new ScriptBundle("~/js/zui").Include("~/bower_components/zui/dist/js/zui.js"));

            bundles.Add(new ScriptBundle("~/js/metisMenu").Include("~/bower_components/metisMenu/dist/metisMenu.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/css/bootstrap").Include("~/bower_components/bootstrap/dist/css/bootstrap.css"));

            bundles.Add(new StyleBundle("~/css/tether").Include("~/bower_components/tether/dist/css/tether.css"));

            bundles.Add(new StyleBundle("~/css/zui").Include("~/bower_components/zui/dist/css/zui-theme.css", "~/bower_components/zui/dist/css/zui.css"));

            bundles.Add(new StyleBundle("~/css/metisMenu").Include("~/bower_components/metisMenu/dist/metisMenu.css"));

            bundles.Add(new StyleBundle("~/css/font-awesome").Include("~/bower_components/font-awesome/css/font-awesome.css"));
        }
    }
}
