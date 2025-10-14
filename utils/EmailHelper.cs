using System;
using System.Net;
using System.Net.Mail;


public static class EmailHelper
{
    public static void SendAppointmentEmail(string toEmail, string subject, string body)
    {
        try
        {
            var fromAddress = new MailAddress("hospital@hospitalapp.com", "Hospital San Vicente");
            var toAddress = new MailAddress(toEmail);

            using (var smtp = new SmtpClient("sandbox.smtp.mailtrap.io", 2525))
            {
                smtp.Credentials = new NetworkCredential("b8499c2504bd96", "2c1aefe56c7e6c");
                smtp.EnableSsl = true;

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"📧 Correo enviado correctamente a {toEmail}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ Error al enviar el correo: {ex.Message}");
            Console.ResetColor();
        }
    }
}
