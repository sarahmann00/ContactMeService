using ContactMeService.Models;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ContactMeService.Services
{
    public class EmailService : IEmailService
    {
        private readonly string smtpHost;
        private readonly int smtpPort;
        private readonly string smtpUser;
        private readonly string smtpPassword;
        private readonly string contactEmail;

        public EmailService(IConfiguration config)
        {
            smtpHost = config["smtpHost"];
            smtpPort = config.GetValue<int>("smtpPort");
            smtpUser = config["smtpUser"];
            smtpPassword = config["smtpPassword"];
            contactEmail = config["contactEmail"];
        }

        public async Task SendContactEmail(ContactRequest request)
        {
            var client = new SmtpClient(smtpHost, smtpPort);
            client.Credentials = new NetworkCredential(smtpUser, smtpPassword);
            client.EnableSsl = true;

            var message = new MailMessage(new MailAddress(smtpUser), new MailAddress(contactEmail));
            message.Subject = "Contact Request from " + request.Name;
            message.Body = $"Email: {request.Email} \nPhone: {request.PhoneNumber} \nMessage:\n{request.Message}"; 

            await client.SendMailAsync(message);
        }
    }
}
