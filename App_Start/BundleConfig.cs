using System.IO;
using System.Web;
using System.Web.Optimization;

namespace IT_LiquidacionFacturas
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Vendors/bootstrap").Include(
                "~/vendors/bootstrap/dist/css/bootstrap.min.css",
                "~/vendors/bootstrap/dist/js/bootstrap.bundle.min.js"
            ));
            bundles.Add(new StyleBundle("~/Vendors/font-awesome").Include(
                "~/vendors/font-awesome/css/font-awesome.min.css"
            ));
            bundles.Add(new StyleBundle("~/Vendors/nprogress").Include(
                "~/vendors/nprogress/nprogress.css",
                "~/vendors/nprogress/nprogress.js"
            ));
            bundles.Add(new StyleBundle("~/Vendors/iCheck").Include(
                "~/vendors/iCheck/skins/flat/green.css",
                "~/vendors/iCheck/icheck.min.js"
            ));
            bundles.Add(new StyleBundle("~/Vendors/bootstrap-progressbar").Include(
                "~/vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css",
                "~/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js"
            ));
            bundles.Add(new StyleBundle("~/Vendors/jqvmap").Include(
                "~/vendors/jqvmap/dist/jqvmap.min.css"
            ));
            bundles.Add(new StyleBundle("~/Vendors/bootstrap-daterangepicker").Include(
                "~/vendors/bootstrap-daterangepicker/daterangepicker.css"
            ));
            bundles.Add(new StyleBundle("~/build/css").Include(
               "~/build/css/custom.min.css"
           ));
            bundles.Add(new StyleBundle("~/vendors/jquery").Include(
               "~/vendors/jquery/dist/jquery.min.js"
           ));
            bundles.Add(new StyleBundle("~/vendors/fastclick").Include(
               "~/vendors/fastclick/lib/fastclick.js"
           ));
            bundles.Add(new StyleBundle("~/vendors/Chart.js").Include(
               "~/vendors/Chart.js/dist/Chart.min.js"
           ));
            bundles.Add(new StyleBundle("~/vendors/gauge.js").Include(
               "~/vendors/gauge.js/dist/gauge.min.js"
           ));
            bundles.Add(new StyleBundle("~/vendors/skycons").Include(
               "~/vendors/skycons/skycons.js"
           ));
            bundles.Add(new StyleBundle("~/vendors/Flot").Include(
              "~/vendors/Flot/jquery.flot.js",
              "~/vendors/Flot/jquery.flot.pie.js",
              "~/vendors/Flot/jquery.flot.time.js",
              "~/vendors/Flot/jquery.flot.stack.js",
              "~/vendors/Flot/jquery.flot.resize.js"
          ));
            bundles.Add(new StyleBundle("~/vendors/flot.orderbars").Include(
               "~/vendors/flot.orderbars/js/jquery.flot.orderBars.js"
           ));
            bundles.Add(new StyleBundle("~/vendors/flot-spline").Include(
               "~/vendors/flot-spline/js/jquery.flot.spline.min.js"
           ));
            bundles.Add(new StyleBundle("~/vendors/flot.curvedlines").Include(
              "~/vendors/flot.curvedlines/curvedLines.js"
          ));
            bundles.Add(new StyleBundle("~/vendors/DateJS").Include(
              "~/vendors/DateJS/build/date.js"
          ));
            bundles.Add(new StyleBundle("~/vendors/jqvmap").Include(
              "~/vendors/jqvmap/dist/jquery.vmap.js",
              "~/vendors/jqvmap/dist/maps/jquery.vmap.world.js",
              "~/vendors/jqvmap/examples/js/jquery.vmap.sampledata.js"
          ));
            bundles.Add(new StyleBundle("~/vendors/moment").Include(
             "~/vendors/moment/min/moment.min.js"
          ));
            bundles.Add(new StyleBundle("~/vendors/moment").Include(
             "~/vendors/moment/min/moment.min.js"
          ));
            bundles.Add(new StyleBundle("~/vendors/bootstrap-daterangepicker").Include(
             "~/vendors/bootstrap-daterangepicker/daterangepicker.js"
          ));
            bundles.Add(new StyleBundle("~/build/js").Include(
             "~/build/js/custom.min.js"
          ));
        }
    }
}