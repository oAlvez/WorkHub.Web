using Microsoft.AspNetCore.Mvc;
using WorkHub.Web.Models.Authentication;
using WorkHub.Web.Models.Extensions;
using WorkHub.Web.Models.User;
using WorkHub.Web.Services.Interfaces;

namespace WorkHub.Web.Controllers;

public class AuthenticationController(IAuthenticationService _authenticationService) : Controller
{
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Authenticate(AuthenticationRequest request)
    {
        if (!ModelState.IsValid)
            return View("Login", request);

        try
        {
            var result = await _authenticationService.LoginAsync(request);

            var userSession = new UserSessionData
            {
                FullName = result?.Username ?? "-",
            };

            HttpContext.Session.SetObject("UserSession", userSession);
            
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View("Login", request);
        }
    }

    [HttpPost]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        return RedirectToAction("Login", "Authentication");
    }
}
