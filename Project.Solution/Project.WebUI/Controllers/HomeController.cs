using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            CookieOptions cookieOptions = new()
            {
                SameSite = SameSiteMode.Strict
            };
            Response.Cookies.Append("s", "alam", cookieOptions);

            return View();
        }
    }
}
