using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using DakwerkenRadino.Business.AppSetting;
using DakwerkenRadino.Business.Models;
using DakwerkenRadino.Core.Keys;
using log4net;

namespace DakwerkenRadino.Business.Email
{
    public class EmailProcessor : IEmailProcessor
    {
        private readonly IConfigurationReader configurationReader;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(EmailProcessor));

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
                    message.To.Add(new MailAddress(Core.Keys.Email.Destination, Core.Keys.Email.Destination));
                    message.IsBodyHtml = false;
                    message.Subject = Core.Keys.Email.Subject;
                    message.Body = contactFormModel.ToString();

                    var smtpUser = new NetworkCredential
                    {
                        UserName = configurationReader.GetValue(AppSettings.Username),
                        Password = configurationReader.GetValue(AppSettings.Password)
                    };

                    string host = configurationReader.GetValue(AppSettings.Host);

                    Logger.Debug(string.Format("Current mail settings. Username: {0} - Password: {1} - Host:{2}", smtpUser.UserName, 
                        smtpUser.Password, host));

                    using (var smtpClient = new SmtpClient())
                    {
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = smtpUser;
                        smtpClient.Host = host;
                        smtpClient.Port = 26;
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        await smtpClient.SendMailAsync(message);
                    }
                }
            }
            catch (SmtpException smtpException)
            {
                Logger.Error("A SMTP exception occurred while sending the mail. Details: " + smtpException.GetBaseException(), smtpException);
                return false;
            }
            catch (Exception exception)
            {
                Logger.Error("A regular exception occurred while sending the mail. Details: " + exception.GetBaseException(), exception);
                return false;
            }

            Logger.Info("An offerte was requested: " + contactFormModel);
            return true;
        }
    }
}