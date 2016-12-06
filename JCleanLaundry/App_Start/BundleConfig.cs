using System.Web;
using System.Web.Optimization;

namespace JCleanLaundry
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/global").Include(
                     "~/Scripts/JCleanLaundry/loading.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                    "~/Scripts/JQuery/jquery.dataTables.min.js",
                    "~/Scripts/Bootstrap/dataTables.bootstrap.min.js",
                    "~/Scripts/JCleanLaundry/datatable-helper.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/transaksi").Include(
                      "~/Scripts/JCleanLaundry/transaksi_pelanggan.js",
                      "~/Scripts/JCleanLaundry/transaksi_cucian.js"));

            #endregion

            #region StyleSheets

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/main.css",

                      "~/Content/JCleanLaundry/dataTables.bootstrap.min.css",

                      "~/Content/JCleanLaundry/loading.css",
                      "~/Content/JCleanLaundry/menu-utama.css",
                      "~/Content/JCleanLaundry/pengambilan.css",
                      "~/Content/JCleanLaundry/status.css",
                      "~/Content/JCleanLaundry/transaksi.css"));

            #endregion
        }
    }
}
