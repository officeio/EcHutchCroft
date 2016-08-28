using Microsoft.AspNetCore.Mvc;

namespace OfficeIO.EcHutchCroft.Website.Controllers
{
    public class SiteController : Controller
    {
        [HttpGet("~/")]
        public IActionResult ServeHomePage()
        {
            return View("~/Views/Default.cshtml");
        }

        [HttpGet("~/Contact")]
        public IActionResult ServeContactPage()
        {
            return View("~/Views/Contact.cshtml");
        }

        //[HttpPost("~/Contact")]
        //public IActionResult SubmitContactPage()
        //{
        //    using (var smtpMail = new SmtpClient("smtp-relay.gmail.com", 587)) {

        //        smtpMail.UseDefaultCredentials = false;
        //        smtpMail.Credentials = new NetworkCredential("system@officeio.com", "System2015!");
        //        smtpMail.EnableSsl = true;

        //        var message = new MailMessage(
        //            from: "visitor@echutchcroft.com",
        //            to: "edward@echutchcroft.com",
        //            subject: string.Format("Website message from {0}", Request["name"]),
        //            body: Request["message"]);

        //        message.ReplyToList.Add(new MailAddress(Request["email"], Request["name"]));

        //        smtpMail.Send(message);

        //    }

        //    return View("~/Views/Contact.cshtml");
        //}

        [HttpGet("~/FAQ")]
        public IActionResult ServeFaqPage()
        {
            return View("~/Views/Faq.cshtml");
        }

    }
}
