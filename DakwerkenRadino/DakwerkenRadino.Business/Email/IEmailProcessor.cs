using DakwerkenRadino.Business.Models;
using DakwerkenRadino.Business.AppSetting;

namespace DakwerkenRadino.Business.Email
{
    public interface IEmailProcessor
    {
        IConfigurationReader ConfigurationReader { get; set; }
        void Send(ContactFormModel contactFormModel);
    }
}