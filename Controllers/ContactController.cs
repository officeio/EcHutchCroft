using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using OfficeIO.EcHutchCroft.Website.Models.Options;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeIO.EcHutchCroft.Website.Controllers
{
    public class ContactController : Controller
    {
        #region Constructor
        public ContactController(IOptions<SmtpOptions> options)
        {
            Options = options.Value;
        } 
        #endregion

        #region Properties
        public SmtpOptions Options { get; private set; } 
        #endregion

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
            mail.From.AddRange(Options.From.Select(f => new MailboxAddress(f.Name, f.Address)));
            mail.To.AddRange(Options.To.Select(f => new MailboxAddress(f.Name, f.Address)));
            mail.Subject = $"Website message from {name}";
            mail.Body = new TextPart("plain") { Text = message };
            mail.ReplyTo.Add(new MailboxAddress(name, email));

            using (var smtpMail = new SmtpClient()) {

                // Connect to the server.
                await smtpMail.ConnectAsync(Options.Hostname, Options.Port, Options.Secure);

                try {

                    // Authenticate and send the mail.
                    await smtpMail.AuthenticateAsync(Options.Username, Options.Password);
                    await smtpMail.SendAsync(mail);

                }
                finally {

                    // Disconnect regardless of error.
                    await smtpMail.DisconnectAsync(true);

                }

            }

            return View("~/Views/Contact.cshtml");
        }
    }
}
