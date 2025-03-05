using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Web;
using System.Web.Helpers;
using System.Web.Optimization;
using System.Web.UI.WebControls;

namespace IT_LiquidacionFacturas
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/VENDORS/CSS").Include(
            "~/vendors/bootstrap/dist/css/bootstrap.min.css",
            "~/vendors/font-awesome/css/font-awesome.min.css",
            "~/vendors/nprogress/nprogress.css",
            "~/vendors/iCheck/skins/flat/green.css",
            "~/vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css",
            "~/vendors/jqvmap/dist/jqvmap.min.css",
            "~/vendors/bootstrap-daterangepicker/daterangepicker.css"
           ));
            bundles.Add(new ScriptBundle("~/VENDORS/JS").Include(
            "~/vendors/jquery/dist/jquery.min.js",
            "~/vendors/bootstrap/dist/js/bootstrap.bundle.min.js",
            "~/vendors/fastclick/lib/fastclick.js",
            "~/vendors/nprogress/nprogress.js",
            "~/vendors/Chart.js/dist/Chart.min.js",
            "~/vendors/gauge.js/dist/gauge.min.js",
            "~/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
            "~/vendors/iCheck/icheck.min.js",
            "~/vendors/skycons/skycons.js",
            "~/vendors/Flot/jquery.flot.js",
            "~/vendors/Flot/jquery.flot.pie.js",
            "~/vendors/Flot/jquery.flot.time.js",
            "~/vendors/Flot/jquery.flot.stack.js",
            "~/vendors/Flot/jquery.flot.resize.js",
            "~/vendors/flot.orderbars/js/jquery.flot.orderBars.js",
            "~/vendors/flot-spline/js/jquery.flot.spline.min.js",
            "~/vendors/flot.curvedlines/curvedLines.js",
            "~/vendors/DateJS/build/date.js",
            "~/vendors/jqvmap/dist/jquery.vmap.js",
            "~/vendors/jqvmap/dist/maps/jquery.vmap.world.js",
            "~/vendors/jqvmap/examples/js/jquery.vmap.sampledata.js",
            "~/vendors/moment/min/moment.min.js",
            "~/vendors/bootstrap-daterangepicker/daterangepicker.js",
            "~/vendors/pnotify/dist/pnotify.history.js"
           ));
            bundles.Add(new StyleBundle("~/BUILD/CSS").Include(
                "~/build/css/custom.css",
                "~/build/css/custom.min.css"
           ));
            bundles.Add(new ScriptBundle("~/BUILD/JS").Include(
                "~/build/js/custom.js",
                "~/build/js/custom.min.js"
            ));
        }
    }
}