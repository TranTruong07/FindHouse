using FindHouseAndT.Models.Helper;
using FindHouseAndT.Models.MailKit;

namespace FindHouseAndT.Application.ExternalInterface
{
    public interface IEmailService
    {
        Task<ResultStatus> SendMailAsync(MailContent mailContent);
    }
}
