using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using E_Learning.Domain.Entities;
using System.Security.Claims;
namespace E_Learning.Controllers;
public class ExternalAuthController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager) : Controller
{

    public IActionResult Login()
    {
        var properties = _signInManager.ConfigureExternalAuthenticationProperties(
            GoogleDefaults.AuthenticationScheme,
            Url.Action("Callback"));

        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    public async Task<IActionResult> Callback()
    {
        var info = await _signInManager.GetExternalLoginInfoAsync();
        if (info == null) return RedirectToAction("Login", "Auth");

        var signInResult = await _signInManager.ExternalLoginSignInAsync(
            info.LoginProvider,
            info.ProviderKey,
            false);

        if (signInResult.Succeeded)
            return RedirectToAction("Index", "Home");

        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true,
            FullName = info.Principal.FindFirstValue(ClaimTypes.Name)
        };

        await _userManager.CreateAsync(user);
        await _userManager.AddLoginAsync(user, info);
        await _signInManager.SignInAsync(user, false);

        return RedirectToAction("Index", "Home");
    }
}
