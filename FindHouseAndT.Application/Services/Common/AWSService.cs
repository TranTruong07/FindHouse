using Amazon.S3;
using FindHouseAndT.Application.UseCase;
using Microsoft.AspNetCore.Http;

namespace FindHouseAndT.Application.Services
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

		public Task<string?> UploadImageToAWSAsync(IFormFile? file)
		{
			if (file == null)
			{
				return Task.FromResult<string?>(null);
			}
			return _uploadImageUseCase.ExecuteAsync(file, _amazonS3);
		}

		public Task<string?> GetPreSignedUrl(string key)
		{
			if (string.IsNullOrEmpty(key))
			{
				return Task.FromResult<string?>(null);
			}
			return _getPreSignedUrlUseCase.ExecuteAsync(key, _amazonS3);
		}
	}
}
