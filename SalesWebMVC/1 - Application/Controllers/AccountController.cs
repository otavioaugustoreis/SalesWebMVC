using Microsoft.AspNetCore.Mvc;
using SalesWebMVC._1___Application.Models;

namespace SalesWebMVC._1___Application.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Simulação de validação de credenciais
            if (model.Username == "admin" && model.Password == "123")
            {
                return RedirectToAction("Index", "Home"); // Redireciona para a Home em caso de sucesso
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(model); // Retorna à tela de login com mensagem de erro
        }
    }
}
