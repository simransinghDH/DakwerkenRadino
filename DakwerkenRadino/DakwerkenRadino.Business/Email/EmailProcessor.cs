using DakwerkenRadino.Business.Models;
using DakwerkenRadino.Business.AppSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DakwerkenRadino.Core.Keys;

namespace DakwerkenRadino.Business.Email
{
    public class EmailProcessor : IEmailProcessor
    {
        private IConfigurationReader configurationReader;

        public EmailProcessor(IConfigurationReader configurationReader)
        {
            this.configurationReader = configurationReader;
        }

        public bool Send(ContactFormModel contactFormModel)
        {
            var message = new MailMessage();
            var smtpClient = new SmtpClient();
            var SmtpUser = new NetworkCredential();

            try
            {
                message.From = new MailAddress(contactFormModel.EmailAddres, contactFormModel.Name);
                message.To.Add(new MailAddress(DakwerkenRadino.Core.Keys.Email.Destination, DakwerkenRadino.Core.Keys.Email.Destination));
                message.IsBodyHtml = false;
                message.Subject = DakwerkenRadino.Core.Keys.Email.Subject;
                message.Body = "TEST";

                SmtpUser.UserName = configurationReader.GetValue(AppSettings.Username);
                SmtpUser.Password = configurationReader.GetValue(AppSettings.Password);

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = SmtpUser;
                smtpClient.Host = configurationReader.GetValue(AppSettings.Host);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(message);
            }
            catch (SmtpException smtpException)
            {
                return false;
            }
            catch (Exception exception)
            {
                return false;
            }

            return true;
        }
    }
}