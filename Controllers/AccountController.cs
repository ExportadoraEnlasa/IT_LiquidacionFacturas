using IT_LiquidacionFacturas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_LiquidacionFacturas.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Aquí iría la lógica para validar el usuario y contraseña
                // Por ejemplo, verificar en una base de datos

                // Si el login es exitoso, redirigir a la página de inicio
                return RedirectToAction("Index", "Home");
            }
            // Si llegamos a este punto, algo falló, volver a mostrar el formulario
            return View(model);
        }
    }
}
}