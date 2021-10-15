using ContactMeService.Models;
using System.Threading.Tasks;

namespace ContactMeService.Services
{
    public interface IEmailService
    {
        Task SendContactEmail(ContactRequest request);
    }
}
