using DakwerkenRadino.Business.Models;
using DakwerkenRadino.Business.AppSetting;

namespace DakwerkenRadino.Business.Email
{
    public interface IEmailProcessor
    {
        bool Send(ContactFormModel contactFormModel);
    }
}