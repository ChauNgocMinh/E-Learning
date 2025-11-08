using E_Learning.Helper.CustomAttributes;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers.SystemControllers;

[Route("/[controller]/[action]")]
[CustomValidateModel]
public class BaseController : Controller
{
}
