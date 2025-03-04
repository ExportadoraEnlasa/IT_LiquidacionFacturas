﻿using IT_LiquidacionFacturas.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_LiquidacionFacturas.Controllers
{
    public class UsuariosController : Controller
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        // GET: Usuarios
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_Usuarios", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usuarios.Add(new Usuario
                    {
                        IdUsuario = (long)reader["IdUsuario"],
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        UsuarioNombre = reader["Usuario"].ToString(),
                        IdRol = (int)reader["IdRol"],
                        FechaCrea = (DateTime)reader["FechaCrea"],
                        FechaModifica = (DateTime)reader["FechaModifica"],
                        Estado = (bool)reader["Estado"]
                    });
                }
            }
            return View(usuarios);
        }
        // GET: Usuarios/Create
        public ActionResult Create()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_CrearUsuarios", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("@Usuario", usuario.UsuarioNombre);
                    cmd.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Usuarios/Modificar/5
        public ActionResult Modificar(long id)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Usuario usuario = new Usuario();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE IdUsuario = @IdUsuario", conn);
                cmd.Parameters.AddWithValue("@IdUsuario", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    usuario.IdUsuario = (long)reader["IdUsuario"];
                    usuario.Nombre = reader["Nombre"].ToString();
                    usuario.Apellido = reader["Apellido"].ToString();
                    usuario.UsuarioNombre = reader["Usuario"].ToString();
                    usuario.IdRol = (int)reader["IdRol"];
                    usuario.Estado = (bool)reader["Estado"];
                }
            }
            return View(usuario);
        }
        // POST: Usuarios/Modificar/5
        [HttpPost]
        public ActionResult Modificar(Usuario usuario)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_ModificarUsuarios", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("@Usuario", usuario.UsuarioNombre);
                    cmd.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Usuarios/Eliminar/5
        public ActionResult Eliminar(long id)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_EliminarUsuarios", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", id);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}