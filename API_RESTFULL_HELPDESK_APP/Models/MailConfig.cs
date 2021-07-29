using System;
using System.Net.Mail;
using System.Text;

namespace API_RESTFULL_HELPDESK_APP.Models
{
    public class MailConfig
    {
        public bool CustomMail(string destinatario, string asunto, string mensaje)
        {
            bool status;
            MailMessage correo = new MailMessage();
            SmtpClient Protocolo = new SmtpClient();
            correo.To.Add(destinatario);
            correo.From = new MailAddress("soporte@raciti.com.mx", "Soporte Técnico RACI TI", Encoding.UTF8);
            correo.Subject = asunto;
            correo.SubjectEncoding = Encoding.UTF8;

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString("<html><body>" + mensaje + "</body></html>", null, System.Net.Mime.MediaTypeNames.Text.Html);
            correo.BodyEncoding = UTF8Encoding.UTF8;
            //correo.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            var aa = AppDomain.CurrentDomain.BaseDirectory;
            string path = AppDomain.CurrentDomain.DynamicDirectory;
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine(path);
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////");

            // ORIGINAL
            //LinkedResource addfile = new LinkedResource(aa + @"..\..\..\Assets\Images\addfile.png");
            //LinkedResource bell = new LinkedResource(aa + @"..\..\..\Assets\images\bell.png");
            //LinkedResource bubble = new LinkedResource(aa + @"..\..\..\Assets\images\bubble.png");
            //LinkedResource category = new LinkedResource(aa + @"..\..\..\Assets\images\category.png");
            //LinkedResource user = new LinkedResource(aa + @"..\..\..\Assets\images\user.png");
            //LinkedResource logo_app = new LinkedResource(aa + @"..\..\..\Assets\images\logo_app.png");

            LinkedResource addfile = new LinkedResource(aa + @"..\..\Assets\Images\addfile.png");
            LinkedResource bell = new LinkedResource(aa + @"..\..\Assets\images\bell.png");
            LinkedResource bubble = new LinkedResource(aa + @"..\..\Assets\images\bubble.png");
            LinkedResource category = new LinkedResource(aa + @"..\..\Assets\images\category.png");
            LinkedResource user = new LinkedResource(aa + @"..\..\Assets\images\user.png");
            LinkedResource logo_app = new LinkedResource(aa + @"..\..\Assets\images\logo_app.png");

            addfile.ContentId = "addfile";
            bell.ContentId = "bell";
            bubble.ContentId = "bubble";
            category.ContentId = "category";
            user.ContentId = "user";
            logo_app.ContentId = "logo_app";
            htmlView.LinkedResources.Add(addfile);
            htmlView.LinkedResources.Add(bell);
            htmlView.LinkedResources.Add(bubble);
            htmlView.LinkedResources.Add(category);
            htmlView.LinkedResources.Add(user);
            htmlView.LinkedResources.Add(logo_app);
            correo.AlternateViews.Add(htmlView);

            //correo.Body = mensaje;
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            correo.BodyEncoding = UTF8Encoding.UTF8;

            Protocolo.Port = 587;
            Protocolo.Host = "smtp.office365.com";
            Protocolo.EnableSsl = true;
            Protocolo.UseDefaultCredentials = false;
            //Protocolo.Credentials = new System.Net.NetworkCredential("capitalhumano@gruposeri.com", "cH*150519");
            Protocolo.Credentials = new System.Net.NetworkCredential("soporte@raciti.com.mx", "Inicio.123");

            try
            {
                Protocolo.Send(correo);
                status = true;
            }
            catch (SmtpException error)
            {
                status = false;
                Console.WriteLine("----------------------------------------------------- ERROR ------------------------------------------------------");
                Console.WriteLine(error.Message);
            }
            return status;
        }
    }
}
