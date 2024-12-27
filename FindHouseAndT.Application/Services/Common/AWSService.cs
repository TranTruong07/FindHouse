using Amazon.S3;
using FindHouseAndT.Application.UseCase;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.Services.Common
{
	public class AWSService
	{
		private readonly IAmazonS3 _amazonS3;
		private readonly IAWSUploadImageUseCase _uploadImageUseCase;
		private readonly IGetPreSignedUrlUseCase _getPreSignedUrlUseCase;

		public AWSService(IAmazonS3 amazonS3, IAWSUploadImageUseCase uploadImageUseCase, IGetPreSignedUrlUseCase getPreSignedUrlUseCase)
		{
			_amazonS3 = amazonS3;
			_uploadImageUseCase = uploadImageUseCase;
			_getPreSignedUrlUseCase = getPreSignedUrlUseCase;
		}

		public async Task<string?> UploadImageToAWSAsync(IFormFile? file)
		{
			if (file == null)
				return null;
			return await _uploadImageUseCase.ExecuteAsync(file, _amazonS3);
		}

		public async Task<string?> GetPreSignedUrl(string key)
		{
			if (string.IsNullOrEmpty(key))
			{
				return null;
			}
			return await _getPreSignedUrlUseCase.ExecuteAsync(key, _amazonS3);
		}
	}
}
