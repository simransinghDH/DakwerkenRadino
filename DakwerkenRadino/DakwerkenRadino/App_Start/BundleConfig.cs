using System.Web.Optimization;

namespace DakwerkenRadino
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/custom/custom.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/bootstrap-select/bootstrap-select.js",
                        "~/Scripts/ga/ga-custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/headerscripts").Include(
                        "~/Scripts/modernizr-*",
                        "~/Scripts/appInsights.js"));

            bundles.Add(new ScriptBundle("~/bundles/photoswipe").Include(
                      "~/Scripts/photoswipe/photoswipe-ui-default.js",
                      "~/Scripts/photoswipe/photoswipe.js",
                      "~/Scripts/photoswipe/photoswipe-custom.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/photoswipe-styling").Include(
                      "~/Content/photoswipe/photoswipe.css",
                      "~/Content/photoswipe/default-skin/default-skin.css"));
        }
    }
}
