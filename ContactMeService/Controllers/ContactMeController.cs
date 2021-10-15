using ContactMeService.Models;
using ContactMeService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContactMeService.Controllers
{
    [ApiController]
    [Route("api/contact")]
    public class ContactMeController : ControllerBase
    {
        private readonly IEmailService emailService;

        public ContactMeController(IEmailService emailService)
        {
            this.emailService = emailService;
        }


        [HttpPost]
        public async Task ContactMe(ContactRequest contactRequest)
        {
            await emailService.SendContactEmail(contactRequest);
        }
    }
}
