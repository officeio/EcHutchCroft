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

        [HttpGet("~/Contact")]
        public IActionResult ServeContactPage()
        {
            return View("~/Views/Contact.cshtml");
        }

        [HttpPost("~/Contact")]
        public async Task<IActionResult> SubmitContactPageAsync(string name, string email, string message)
        {
            // Prepare the mail to send.
            var mail = new MimeMessage();
            mail.From.Add(new MailboxAddress("Website Visitor", "visitor@echutchcroft.com"));
            mail.To.Add(new MailboxAddress("James Harrison", "james@officeio.com"));
            mail.Subject = $"Website message from {name}";
            mail.Body = new TextPart("plain") { Text = message };
            mail.ReplyTo.Add(new MailboxAddress(name, email));

            using (var smtpMail = new SmtpClient()) {

                // Connect to the server.
                await smtpMail.ConnectAsync("smtp-relay.gmail.com", 587, SecureSocketOptions.StartTls);

                try {

                    // Authenticate and send the mail.
                    await smtpMail.AuthenticateAsync(Encoding.ASCII, "system@officeio.com", "System2015!");
                    await smtpMail.SendAsync(mail);

                }
                finally {

                    // Disconnect regardless of error.
                    await smtpMail.DisconnectAsync(true);

                }

            }

            return View("~/Views/Contact.cshtml");
        }

        [HttpGet("~/FAQ")]
        public IActionResult ServeFaqPage()
        {
            return View("~/Views/Faq.cshtml");
        }

    }
}
