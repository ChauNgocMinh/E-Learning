using E_Learning.Helper.CustomAttributes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Learning.Controllers.SystemControllers;

[Route("/[controller]/[action]")]
[CustomValidateModel]
public class BaseController : Controller
{
    protected Guid? GetUserId()
    {
        var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier)
                    ?? User?.FindFirstValue("sub")
                    ?? User?.FindFirstValue("uid");

        return userId != null ? Guid.Parse(userId) : (Guid?)null;
    }
}
