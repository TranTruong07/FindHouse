using Amazon.S3;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.UseCase
{
	public interface IGetPreSignedUrlUseCase
	{
		// return PreSignedUrl
		Task<string?> ExecuteAsync(string key, IAmazonS3 amazonS3);
	}
}
