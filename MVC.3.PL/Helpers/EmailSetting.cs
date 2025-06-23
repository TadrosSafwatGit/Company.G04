using System.Net;
using System.Net.Mail;

namespace MVC._3.PL.Helpers
{
    public static class EmailSetting
    {

        public static bool SendEmail(Email email)
        {
            try
            {
                // mail server  :Gmail
                // SMTP 


                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("tadrossafwat001@gmail.com", "xxplipzqzkthhywy");
                client.Send("tadrossafwat001@gmail.com", email.To, email.Subject, email.Body);



                return true;

            }
            catch (Exception e)
            {

                return false;
            }
        
        }

    }
}
