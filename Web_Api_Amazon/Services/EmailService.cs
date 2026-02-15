using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using MVC_App_SPD311.Helpers;
using Newtonsoft.Json.Linq;

public class EmailService : IEmailSender
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        MailJetSettings? settings =
            _configuration.GetSection(nameof(MailJetSettings))
            .Get<MailJetSettings>();

        if (settings == null)
            throw new ArgumentNullException(nameof(settings));

        MailjetClient client =
            new MailjetClient(settings.ApiKey, settings.ApiSecret);

        MailjetRequest request = new MailjetRequest
        {
            Resource = Send.Resource,
        }
        .Property(Send.FromEmail, "vikajurchyk@gmail.com")
        .Property(Send.FromName, "Allora HELP")
        .Property(Send.Subject, subject)
        .Property(Send.HtmlPart, htmlMessage)
        .Property(Send.Recipients, new JArray {
            new JObject {
                {"Email", email}
            }
        });

        await client.PostAsync(request);
    }
}
