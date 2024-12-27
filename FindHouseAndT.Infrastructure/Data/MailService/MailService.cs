using FindHouseAndT.Models.Helper;
using FindHouseAndT.Models.MailKit;
using Microsoft.Extensions.Options;
using MimeKit;

namespace FindHouseAndT.Infrastructure.Data.MailService
{
	public class MailService : IMailService
	{
		private MailSetting _setting;

		public MailService(IOptions<MailSetting> setting)
		{
			_setting = setting.Value;
		}

		public async Task<ResultStatus> SendMailAsync(MailContent mailContent)
		{
			var email = new MimeMessage();
			email.Sender = new MailboxAddress(_setting.DisplayName, _setting.Mail);
			email.From.Add(new MailboxAddress(_setting.DisplayName, _setting.Mail));
			email.To.Add(new MailboxAddress(mailContent.Email, mailContent.Email));
			email.Subject = mailContent.Subject;

			var body = new BodyBuilder();
			body.HtmlBody = mailContent.Content;
			email.Body = body.ToMessageBody();

			var smtp = new MailKit.Net.Smtp.SmtpClient();
			try
			{
				await smtp.ConnectAsync(_setting.Host, _setting.Port, MailKit.Security.SecureSocketOptions.StartTls);
				await smtp.AuthenticateAsync(_setting.Mail, _setting.Password);
				await smtp.SendAsync(email);
				return ResultStatus.Success;
			}catch(Exception ex)
			{
				var result = ResultStatus.Failure;
				result.Content = ex.Message;
				return result;
			}
		}
	}
}
