using Microsoft.AspNetCore.Mvc;
using WorkHub.Web.Models.Authentication;
using WorkHub.Web.Services.Interfaces;

namespace WorkHub.Web.Controllers;

public class AuthenticationController(IAuthenticationService _authenticationService) : Controller
{
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Authenticate(LoginRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        try
        {
            var result = await _authenticationService.LoginAsync(request);
            // Armazenar o token, redirecionar, etc.
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(request);
        }
    }

    [HttpPost]
    public IActionResult Logout()
    {
        // Se estiver usando cookies
        //HttpContext.SignOutAsync();

        // Se estiver usando JWT e salvando em memória, limpe os dados da sessão
        // HttpContext.Session.Clear();

        return RedirectToAction("Login", "Authentication");
    }
}
