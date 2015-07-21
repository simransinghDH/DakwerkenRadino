using DakwerkenRadino.Business.Models;
using DakwerkenRadino.Business.AppSetting;
using System.Threading.Tasks;

namespace DakwerkenRadino.Business.Email
{
    public interface IEmailProcessor
    {
        Task<bool> Send(ContactFormModel contactFormModel);
    }
}