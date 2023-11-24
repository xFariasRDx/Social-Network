using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers.Amigos
{
    public class AmigosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
