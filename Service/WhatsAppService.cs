namespace WhatsAppChatbot.Service;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

public class WhatsAppService
{
    private readonly IConfiguration _configuration;

    public WhatsAppService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void SendMessage(string to, string message)
    {
        TwilioClient.Init(
            _configuration["Twilio:AccountSid"],
            _configuration["Twilio:AuthToken"]
        );

        var messageOptions = new CreateMessageOptions(new PhoneNumber(_configuration["Twilio:WhatsAppTo"]))
        {
            From = new PhoneNumber(_configuration["Twilio:WhatsAppFrom"]),
            Body = message
        };

        MessageResource.Create(messageOptions);
    }
}
