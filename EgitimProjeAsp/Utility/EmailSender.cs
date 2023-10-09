using Microsoft.AspNetCore.Identity.UI.Services;

namespace EgitimProjeAsp.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //email gonderme işlemlerinizi yapabilirsiniz.
           return Task.CompletedTask;
        }
    }
}
