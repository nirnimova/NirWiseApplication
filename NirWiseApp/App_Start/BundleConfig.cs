using System.Web;
using System.Web.Optimization;

namespace NirWiseApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include("~/Scripts/angular.min.js",
                                                                      "~/Scripts/angular-route.min.js",
                                                                      "~/Scripts/angular-messages.min.js",
                                                                      "~/Scripts/trNgGrid-3.1.6-master/trNgGrid.min.js",
                                                                      "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                                                                      "~/Scripts/angular-block-ui.min.js"));

            // Use the development version of Modernizr to develop wit~/Scripts/angular-ui/ui-bootstrap-tpls.min.js">h and learn from. Then, when you're
            // ready for production, use the build tool at https://mod~/Scripts/angular-block-ui.min.js"></script>ernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/wise").Include(
                "~/Scripts/custom/WiseMainMdl.js",
                "~/Scripts/custom/WiseProductsSvc.js",
                "~/Scripts/custom/WiseProductsCtrl.js",
                "~/Scripts/custom/WiseAccountsSvc.js",
                "~/Scripts/custom/WiseAccountsCtrl.js",
                "~/Scripts/custom/WiseFeeAgreementsSvc.js",
                "~/Scripts/custom/WiseAgentsSvc.js",
                "~/Scripts/custom/WiseAgentsCtrl.js",
                "~/Scripts/custom/WiseEditAgentCtrl.js"));
        }
    }
}
