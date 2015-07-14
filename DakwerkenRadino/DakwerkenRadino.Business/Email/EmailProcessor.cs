using DakwerkenRadino.Business.Models;
using DakwerkenRadino.Business.AppSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DakwerkenRadino.Business.Email
{
    public class EmailProcessor : IEmailProcessor
    {
        public IConfigurationReader ConfigurationReader { get; set; }

        public void Send(ContactFormModel contactFormModel)
        {
            var message = new MailMessage();
            var smtpClient = new SmtpClient();
            var SmtpUser = new NetworkCredential();

            message.From = new MailAddress(contactFormModel.EmailAddres, contactFormModel.Name);
            message.To.Add(new MailAddress(DakwerkenRadino.Core.Keys.Email.Destination, DakwerkenRadino.Core.Keys.Email.DestinationName));
            message.IsBodyHtml = false;
            message.Subject = DakwerkenRadino.Core.Keys.Email.Subject;
            message.Body = "Voorbeeld tekst body";

            SmtpUser.UserName = "info@dakwerken-radino.be";
            SmtpUser.Password = "Kenzo.456";

            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = SmtpUser;
            smtpClient.Host = "smtp.mijnhostingpartner.nl";
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Send(message);
        }
    }
}