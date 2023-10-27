using Microsoft.AspNetCore.Mvc;

namespace ArticleWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
