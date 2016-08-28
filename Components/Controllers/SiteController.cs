using Microsoft.AspNetCore.Mvc;

namespace OfficeIO.EcHutchCroft.Website.Components.Controllers
{
    public class SiteController : Controller
    {
        [HttpGet("~/FAQ")]
        public IActionResult ServeFaqPage()
        {
            return View("Faq");
        }
    }
}
