using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Text;
using System.Threading.Tasks;

namespace OfficeIO.EcHutchCroft.Website.Controllers
{
    public class SiteController : Controller
    {
        [HttpGet("~/")]
        public IActionResult ServeHomePage()
        {
            return View("~/Views/Default.cshtml");
        }

        [HttpGet("~/FAQ")]
        public IActionResult ServeFaqPage()
        {
            return View("~/Views/Faq.cshtml");
        }
    }
}
