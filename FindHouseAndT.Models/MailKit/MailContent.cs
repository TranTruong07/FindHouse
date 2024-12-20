using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Models.MailKit
{
	public class MailContent
	{
		public required string Email { get; set; }
		public required string Subject { get; set; }
		public required string Content { get; set; }
	}
}
