using MailKit.Security;
using System.Collections.Generic;

namespace OfficeIO.EcHutchCroft.Website.Components.Models.Options
{
    public class SmtpOptions
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Hostname { get; set; }
        public int Port { get; set; }
        public SecureSocketOptions Secure { get; set; }
        public IList<SmtpAddressOptions> From { get; set; } = new List<SmtpAddressOptions>();
        public IList<SmtpAddressOptions> To { get; set; } = new List<SmtpAddressOptions>();
    }
}
