using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("email")]
    [Produces("application/json")]
    //[ApiExplorerSettings(GroupName = "Email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail(EmailRequest emailRequest)
        {
            await _emailService.SendEmail(emailRequest);

            return NoContent();
        }

        [HttpPost("send-email-hangfire")]
        public IActionResult SendEmailHangfire(EmailRequest emailRequest)
        {
            _emailService.SendEmailHangfire(emailRequest);

            return NoContent();
        }
    }
}
