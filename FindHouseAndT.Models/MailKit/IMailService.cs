
using FindHouseAndT.Models.Helper;

namespace FindHouseAndT.Models.MailKit
{
	public interface IMailService
	{
		Task<ResultStatus> SendMailAsync(MailContent mailContent);
	}
}
