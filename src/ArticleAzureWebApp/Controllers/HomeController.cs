using System.Diagnostics;
using ArticleAzureWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArticleWebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "p-web-api-with-roles-user")]
        public async Task<IActionResult> UserPrivacy()
        {
            return View();
        }

        [Authorize(Policy = "p-web-api-with-roles-admin")]
        public async Task<IActionResult> AdminPrivacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}