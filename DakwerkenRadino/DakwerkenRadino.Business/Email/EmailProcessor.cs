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

        public async Task<bool> Send(ContactFormModel contactFormModel)
        {
            try
            {
                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(contactFormModel.EmailAddres, contactFormModel.Name);
                    message.To.Add(new MailAddress(DakwerkenRadino.Core.Keys.Email.Destination, DakwerkenRadino.Core.Keys.Email.Destination));
                    message.IsBodyHtml = false;
                    message.Subject = DakwerkenRadino.Core.Keys.Email.Subject;
                    message.Body = string.Format(DakwerkenRadino.Core.Keys.Email.Message,
                        contactFormModel.Name, contactFormModel.EmailAddres, contactFormModel.PhoneNumber, contactFormModel.StreetAndNumber,
                        contactFormModel.Zipcode, contactFormModel.City, string.Join(", ", contactFormModel.SelectedSortOfJob),
                        contactFormModel.Message);

                    var smtpUser = new NetworkCredential
                    {
                        UserName = configurationReader.GetValue(AppSettings.Username),
                        Password = configurationReader.GetValue(AppSettings.Password)
                    };

                    using (var smtpClient = new SmtpClient())
                    {
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = smtpUser;
                        smtpClient.Host = configurationReader.GetValue(AppSettings.Host);
                        smtpClient.Port = 26;
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        await smtpClient.SendMailAsync(message);
                    }
                }
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