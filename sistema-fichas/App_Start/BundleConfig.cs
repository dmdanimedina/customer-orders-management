using System.Web;
using System.Web.Optimization;

namespace sistema_fichas
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/bootstrapBundler").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/style.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/DateTimePicker").Include(
                 "~/Content/bootstrap-datetimepicker.css"
                ));

            bundles.Add(new StyleBundle("~/Content/BoostrapSwitch").Include(
                "~/Content/bootstrap-switch/bootstrap3/bootstrap-switch.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/DateTimePicker").Include(
                "~/Scripts/moment.js",
                "~/Scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/BoostrapSwitch").Include(
                "~/Scripts/bootstrap-switch.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrap.js"));

        }
    }
}