using Microsoft.AspNetCore.Mvc;

namespace PescaArtesanalAPI.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
