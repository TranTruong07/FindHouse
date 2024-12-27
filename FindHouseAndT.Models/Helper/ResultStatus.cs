using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Models.Helper
{
	public class ResultStatus
	{
		public string Content { get; set; }
		public int ResultCode { get; set; }
		public static ResultStatus Success = new ResultStatus() { Content = "Success", ResultCode = Helper.ResultCode.Success };
		public static ResultStatus Failure = new ResultStatus() { Content = "Failure", ResultCode = Helper.ResultCode.Failure };
	}
}
