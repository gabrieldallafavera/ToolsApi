using Api.Controllers;
using Api.Models;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests.System.Controllers
{
    public class EmailRequestTest
    {
        [Fact]
        public async Task SendEmail_NoContent_Return()
        {
            // Arrange
            var mockEmailService = new Mock<IEmailService>();

            var emailController = new EmailController(mockEmailService.Object);

            EmailRequest emailRequest = new EmailRequest
            {
                To = "email@test.com",
                Subject = "<p>Example of subject</p>",
                Body = "Example of body as a simple text.",
            };

            // Act
            var result = (NoContentResult)await emailController.SendEmail(emailRequest);

            // Assert
            Assert.Equal(204, result.StatusCode);
        }

        [Fact]
        public void SendEmailHangfire_NoContent_Return()
        {
            // Arrange
            var mockEmailService = new Mock<IEmailService>();

            var emailController = new EmailController(mockEmailService.Object);

            EmailRequest emailRequest = new EmailRequest
            {
                To = "email@test.com",
                Subject = "<p>Example of subject</p>",
                Body = "Example of body as a simple text.",
            };

            // Act
            var result = (NoContentResult)emailController.SendEmailHangfire(emailRequest);

            // Assert
            Assert.Equal(204, result.StatusCode);
        }
    }
}
