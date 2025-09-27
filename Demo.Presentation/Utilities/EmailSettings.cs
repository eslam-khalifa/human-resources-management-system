using System.Net;
using System.Net.Mail;

namespace Demo.Presentation.Utilities
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("khalifaeslam754@gmail.com", "txotsgfhcybxlpav");
            smtpClient.Send("khalifaeslam754@gmail.com", email.To, email.Subject, email.Body);
        }
    }
}
