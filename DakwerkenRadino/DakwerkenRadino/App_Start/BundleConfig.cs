using System.Web.Optimization;

namespace DakwerkenRadino
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Scripts
            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/custom/custom.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/bootstrap-select/bootstrap-select.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/headerscripts").Include(
                        "~/Scripts/modernizr-*",
                        "~/Scripts/appInsights.js"));

            bundles.Add(new ScriptBundle("~/bundles/photoswipe").Include(
                      "~/Scripts/photoswipe/photoswipe-ui-default.js",
                      "~/Scripts/photoswipe/photoswipe.js",
                      "~/Scripts/photoswipe/photoswipe-custom.js"));

            //Styles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/photoswipe-styling").Include(
                      "~/Content/photoswipe/photoswipe.css",
                      "~/Content/photoswipe/default-skin/default-skin.css"));
        }
    }
}
