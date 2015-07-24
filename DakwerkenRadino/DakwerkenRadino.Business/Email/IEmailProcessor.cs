using System.Threading.Tasks;
using DakwerkenRadino.Business.Models;

namespace DakwerkenRadino.Business.Email
{
    public interface IEmailProcessor
    {
        Task<bool> Send(ContactFormModel contactFormModel);
    }
}