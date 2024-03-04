using AV.ForeignExchangeRates.Front.Helpers;
using AV.ForeignExchangeRates.Front.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AV.ForeignExchangeRates.Front.Controllers;

public class LoginController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        if(User.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(Account account)
    {
        if(!ModelState.IsValid)
        {
            return View(account);
        }

        if(account.ClientId == "admin" 
            && account.UserId == "user" 
            && account.Password == "pwd")
        {
            await SaveSessionCookie("admin");

            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Client id, user id or password invalid");

        return View(account);
    }

    public async Task<IActionResult> SignOut()
    {
        await HttpContext.SignOutAsync(Constants.COOKIE_NAME);

        return RedirectToAction("Index");
    }

    private async Task SaveSessionCookie(string userName)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userName)
        };

        var identity = new ClaimsIdentity(claims, Constants.COOKIE_NAME);

        await HttpContext.SignInAsync(Constants.COOKIE_NAME, new ClaimsPrincipal(identity));
    }
}
