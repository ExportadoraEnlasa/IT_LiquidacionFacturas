using IT_LiquidacionFacturas.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace IT_LiquidacionFacturas.Controllers
{
    public class AccountController : Controller
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        // GET: /Account/Login
        public ViewResult Login()
        {
            return View();
        }
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_LoginUsuarios", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Usuario", model.Usuario);
                        command.Parameters.AddWithValue("@Contrasena", model.Contrasena);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Session["Usuario"] = reader["Usuario"].ToString();
                                Session["Nombre"] = reader["Nombre"].ToString();
                                Session["Apellido"] = reader["Apellido"].ToString();
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
                TempData["ErrorMessage"] = "Usuario y contraseña no coinciden!";
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}