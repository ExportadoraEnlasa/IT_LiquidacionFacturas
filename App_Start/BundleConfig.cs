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
            // Bundle para todos los archivos CSS de la carpeta ~/vendors/bootstrap
            bundles.Add(new StyleBundle("~/Vendors/bootstrap").Include(
                     "~/vendors/bootstrap/dist/css/bootstrap-grid.css",
                     "~/vendors/bootstrap/dist/css/bootstrap-grid.css.map",
                     "~/vendors/bootstrap/dist/css/bootstrap-grid.min.css",
                     "~/vendors/bootstrap/dist/css/bootstrap-grid.min.css.map",
                     "~/vendors/bootstrap/dist/css/bootstrap-reboot.css",
                     "~/vendors/bootstrap/dist/css/bootstrap-reboot.css.map",
                     "~/vendors/bootstrap/dist/css/bootstrap-reboot.min.css",
                     "~/vendors/bootstrap/dist/css/bootstrap-reboot.min.css.map",
                     "~/vendors/bootstrap/dist/css/bootstrap.css",
                     "~/vendors/bootstrap/dist/css/bootstrap.css.map",
                     "~/vendors/bootstrap/dist/css/bootstrap.min.css",
                     "~/vendors/bootstrap/dist/css/bootstrap.min.css.map",
                     "~/Content/bootstrap/"));

            // Bundle para todos los archivos CSS de la carpeta ~/vendors/bootstrap/dist/css
            bundles.Add(new StyleBundle("~/Vendors/bootstrap/css").Include(
                GetFilesFromFolder("~/vendors/bootstrap/", "*.css")
            ));

            // Bundle para todos los archivos JS de la carpeta ~/vendors/bootstrap/dist/js
            bundles.Add(new ScriptBundle("~/Vendors/bootstrap/js").Include(
                GetFilesFromFolder("~/vendors/bootstrap/", "*.js")
            ));

        }
        private static string[] GetFilesFromFolder(string virtualFolder, string searchPattern)
        {
            // Obtener la ruta física de la carpeta
            string physicalFolder = HttpContext.Current.Server.MapPath(virtualFolder);

            // Obtener todos los archivos que coincidan con el patrón de búsqueda
            var files = Directory.GetFiles(physicalFolder, searchPattern);

            // Convertir las rutas físicas a rutas virtuales
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = virtualFolder + "/" + Path.GetFileName(files[i]);
            }

            return files;
        }
    }
}