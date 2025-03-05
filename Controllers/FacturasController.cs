using IT_LiquidacionFacturas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeOpenXml; // Librería EPPlus para leer archivos Excel
using System.Diagnostics;
namespace IT_LiquidacionFacturas.Controllers
{
    public class FacturasController : Controller
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        // GET: Facturas/Cargar
        public ActionResult Cargar()
        {
            return View();
        }
        // POST: Facturas/Cargar
        [HttpPost]
        public ActionResult Cargar(HttpPostedFileBase archivo)
        {
            if (archivo != null && archivo.ContentLength > 0)
            {
                // Verifica el nombre y el tamaño del archivo
                Debug.WriteLine("Archivo recibido: " + archivo.FileName);
                Debug.WriteLine("Tamaño del archivo: " + archivo.ContentLength);
                try
                {
                    List<Factura> facturas = LeerArchivoExcel(archivo);
                    Session["Facturas"] = facturas;
                    return RedirectToAction("MostrarFacturas");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error al cargar el archivo: " + ex.Message;
                }
            }
            else
            {
                ViewBag.Error = "Por favor, seleccione un archivo.";
            }
            return View();
        }
        // GET: Facturas/MostrarFacturas
        public ActionResult MostrarFacturas()
        {
            // Obtener los datos de la sesión
            List<Factura> facturas = Session["Facturas"] as List<Factura>;

            if (facturas == null)
            {
                return RedirectToAction("Cargar");
            }

            return View(facturas);
        }

        // POST: Facturas/GuardarEnBaseDeDatos
        [HttpPost]
        public ActionResult GuardarEnBaseDeDatos()
        {
            // Obtener los datos de la sesión
            List<Factura> facturas = Session["Facturas"] as List<Factura>;

            if (facturas != null)
            {
                try
                {
                    // Lógica para guardar en la base de datos
                    GuardarFacturasEnBaseDeDatos(facturas);

                    ViewBag.Mensaje = "Facturas guardadas correctamente.";
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error al guardar en la base de datos: " + ex.Message;
                }
            }
            else
            {
                ViewBag.Error = "No hay datos para guardar.";
            }

            return View("MostrarFacturas", facturas);
        }

        // Método para leer el archivo Excel
        private List<Factura> LeerArchivoExcel(HttpPostedFileBase archivo)
        {
            List<Factura> facturas = new List<Factura>();

            using (var package = new ExcelPackage(archivo.InputStream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++) // Empieza desde la fila 2 para omitir la cabecera
                {
                    Factura factura = new Factura
                    {
                        FechaEmision = DateTime.Parse(worksheet.Cells[row, 1].Text),
                        NumeroAutorizacion = worksheet.Cells[row, 2].Text,
                        TipoDTEnombre = worksheet.Cells[row, 3].Text,
                        Serie = worksheet.Cells[row, 4].Text,
                        NumeroDTE = long.Parse(worksheet.Cells[row, 5].Text),
                        NitEmisor = worksheet.Cells[row, 6].Text,
                        NombreEmisor = worksheet.Cells[row, 7].Text,
                        CodigoEstablecimiento = int.Parse(worksheet.Cells[row, 8].Text),
                        NombreEstablecimiento = worksheet.Cells[row, 9].Text,
                        IdReceptor = int.Parse(worksheet.Cells[row, 10].Text),
                        NombreReceptor = worksheet.Cells[row, 11].Text,
                        NitCertificador = int.Parse(worksheet.Cells[row, 12].Text),
                        NombreCertificador = worksheet.Cells[row, 13].Text,
                        Moneda = worksheet.Cells[row, 14].Text,
                        MontoTotal = decimal.Parse(worksheet.Cells[row, 15].Text),
                        Estado = worksheet.Cells[row, 16].Text,
                        MarcaAnulado = worksheet.Cells[row, 17].Text,
                        FechaAnulacion = DateTime.Parse(worksheet.Cells[row, 18].Text),
                        IvaMontoImpuesto = decimal.Parse(worksheet.Cells[row, 19].Text),
                        PetroleoMontoImpuesto = decimal.Parse(worksheet.Cells[row, 20].Text),
                        TurismoHospedajeMontoImpuesto = decimal.Parse(worksheet.Cells[row, 21].Text),
                        TurismoPasajesMontoImpuesto = decimal.Parse(worksheet.Cells[row, 22].Text),
                        TimbrePrensaMontoImpuesto = decimal.Parse(worksheet.Cells[row, 23].Text),
                        BomberosMontoImpuesto = decimal.Parse(worksheet.Cells[row, 24].Text),
                        TasaMunicipalMontoImpuesto = decimal.Parse(worksheet.Cells[row, 25].Text),
                        BebidasAlcoholicasMontoImpuesto = decimal.Parse(worksheet.Cells[row, 26].Text),
                        TabacoMontoImpuesto = decimal.Parse(worksheet.Cells[row, 27].Text),
                        CementoMontoImpuesto = decimal.Parse(worksheet.Cells[row, 28].Text),
                        BebidasNoAlcoholicasMontoImpuesto = decimal.Parse(worksheet.Cells[row, 29].Text),
                        TarifaPortuariaMontoImpuesto = decimal.Parse(worksheet.Cells[row, 30].Text),
                        EstadoFact = bool.Parse(worksheet.Cells[row, 31].Text),
                        Reclamado = bool.Parse(worksheet.Cells[row, 32].Text)
                    };
                    facturas.Add(factura);
                }
            }
            return facturas;
        }
        // Método para guardar las facturas en la base de datos
        private void GuardarFacturasEnBaseDeDatos(List<Factura> facturas)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var factura in facturas)
                {
                    using (SqlCommand cmd = new SqlCommand("SP_InsertarFactura", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FechaEmision", factura.FechaEmision);
                        cmd.Parameters.AddWithValue("@NumeroAutorizacion", factura.NumeroAutorizacion);
                        cmd.Parameters.AddWithValue("@TipoDTEnombre", factura.TipoDTEnombre);
                        cmd.Parameters.AddWithValue("@Serie", factura.Serie);
                        cmd.Parameters.AddWithValue("@NumeroDTE", factura.NumeroDTE);
                        cmd.Parameters.AddWithValue("@NitEmisor", factura.NitEmisor);
                        cmd.Parameters.AddWithValue("@NombreEmisor", factura.NombreEmisor);
                        cmd.Parameters.AddWithValue("@CodigoEstablecimiento", factura.CodigoEstablecimiento);
                        cmd.Parameters.AddWithValue("@NombreEstablecimiento", factura.NombreEstablecimiento);
                        cmd.Parameters.AddWithValue("@IdReceptor", factura.IdReceptor);
                        cmd.Parameters.AddWithValue("@NombreReceptor", factura.NombreReceptor);
                        cmd.Parameters.AddWithValue("@NitCertificador", factura.NitCertificador);
                        cmd.Parameters.AddWithValue("@NombreCertificador", factura.NombreCertificador);
                        cmd.Parameters.AddWithValue("@Moneda", factura.Moneda);
                        cmd.Parameters.AddWithValue("@MontoTotal", factura.MontoTotal);
                        cmd.Parameters.AddWithValue("@Estado", factura.Estado);
                        cmd.Parameters.AddWithValue("@MarcaAnulado", factura.MarcaAnulado);
                        cmd.Parameters.AddWithValue("@FechaAnulacion", factura.FechaAnulacion);
                        cmd.Parameters.AddWithValue("@IvaMontoImpuesto", factura.IvaMontoImpuesto);
                        cmd.Parameters.AddWithValue("@PetroleoMontoImpuesto", factura.PetroleoMontoImpuesto);
                        cmd.Parameters.AddWithValue("@TurismoHospedajeMontoImpuesto", factura.TurismoHospedajeMontoImpuesto);
                        cmd.Parameters.AddWithValue("@TurismoPasajesMontoImpuesto", factura.TurismoPasajesMontoImpuesto);
                        cmd.Parameters.AddWithValue("@TimbrePrensaMontoImpuesto", factura.TimbrePrensaMontoImpuesto);
                        cmd.Parameters.AddWithValue("@BomberosMontoImpuesto", factura.BomberosMontoImpuesto);
                        cmd.Parameters.AddWithValue("@TasaMunicipalMontoImpuesto", factura.TasaMunicipalMontoImpuesto);
                        cmd.Parameters.AddWithValue("@BebidasAlcoholicasMontoImpuesto", factura.BebidasAlcoholicasMontoImpuesto);
                        cmd.Parameters.AddWithValue("@TabacoMontoImpuesto", factura.TabacoMontoImpuesto);
                        cmd.Parameters.AddWithValue("@CementoMontoImpuesto", factura.CementoMontoImpuesto);
                        cmd.Parameters.AddWithValue("@BebidasNoAlcoholicasMontoImpuesto", factura.BebidasNoAlcoholicasMontoImpuesto);
                        cmd.Parameters.AddWithValue("@TarifaPortuariaMontoImpuesto", factura.TarifaPortuariaMontoImpuesto);
                        cmd.Parameters.AddWithValue("@EstadoFact", factura.EstadoFact);
                        cmd.Parameters.AddWithValue("@Reclamado", factura.Reclamado);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}