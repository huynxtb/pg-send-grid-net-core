using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMegaSendMail
{
    public static class SendMail
    {
        public static async Task SendAsync()
        {
            var apiKey = "YOUR_KEY"; // YOUR API KEY

            var from = new EmailAddress("support@code-mega.com", "Code Mega"); // Sender Info

            //var to = new EmailAddress("test@example.com", "Example User"); // Single Receiver Info

            var tos = new List<EmailAddress>()
            {
                new EmailAddress("huynx11.dev@gmail.com", "Code Mega User")
            }; // List Receiver Info

            var subject = "Test Send Mail"; // Email Subject

            var client = new SendGridClient(apiKey);

            var htmlContent = "<strong>Hello world</strong>" +
                "<br>" +
                "<img src='https://www.code-mega.com/images/theme/logo.png' alt='Logo' width='500' height='500'>";

            //var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent); // For Send Email To Single Receiver

            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, "", htmlContent); // For Send Email To Multi Receiver

            var response = await client.SendEmailAsync(msg);

            Console.WriteLine(response.StatusCode.ToString());
        }
    }
}
