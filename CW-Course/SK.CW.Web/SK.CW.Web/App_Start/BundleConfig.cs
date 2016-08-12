using System.Web.Optimization;

namespace SK.CW.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery-ui-{version}.js")
                .Include("~/Scripts/jquery.unobtrusive-ajax.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/modernizr-{version}.js"));

            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/Content/Site.css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/themes/base/jquery-ui.css"));
        }
    }
}