using Microsoft.AspNetCore.Mvc;
using WorkHub.Web.Models.User;
using WorkHub.Web.Services.Interfaces;

namespace WorkHub.Web.Controllers;

public class UserController(IUserService _userService) : Controller
{
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var response = await _userService.CreateUserAsync(model);

        if (response?.Success is true)
        {
            TempData["Success"] = response.Message;
            return RedirectToAction("Create");
        }

        ModelState.AddModelError(string.Empty, "Erro ao cadastrar usuário.");
        return View(model);
    }
}
