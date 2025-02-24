using Commercium.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Classes
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer = "mail.commercium.com.tr";
        private readonly int _smtpPort = 6708;
        private readonly string _smtpUser = "info@commercium.com.tr";
        private readonly string _smtpPassword = "5c65e5b89fab0f";

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            using (var client = new SmtpClient(_smtpServer, _smtpPort))
            {
                client.Credentials = new NetworkCredential(_smtpUser, _smtpPassword);
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpUser),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true

                };
                mailMessage.To.Add(email);
                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
