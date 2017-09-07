using System;
using System.Configuration;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;

namespace Vinyl.Libraries.Tools
{
    public class Email
    {
        public bool SendEmail(string toAddress, string emailBCC, string emailCC, string toName,
                                string subject, string body, bool isBodyHtml = true)
        {
            Configuration configurationFile = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/App.Config");
            MailSettingsSectionGroup mailSettings = configurationFile.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
            var mailMessage = new MailMessage();
            var smtpClient = new SmtpClient { EnableSsl = true };
            bool blnSuccess = false;
            try
            {
                string user = mailSettings.Smtp.Network.UserName;
                string password = mailSettings.Smtp.Network.Password;

                mailMessage.To.Add(toAddress);
                if (emailBCC != null) mailMessage.Bcc.Add(emailBCC);
                mailMessage.CC.Add(user);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = isBodyHtml;

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(user, password);
                smtpClient.Send(mailMessage);

                blnSuccess = true;
            }
            catch (Exception ex)
            {
                blnSuccess = false;
                throw new Exception(ex.Message);
            }
            return blnSuccess;
        }
    }
}
