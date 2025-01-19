using Amazon.S3;
using Amazon.S3.Model;
using FindHouseAndT.Application.ExternalInterface;
using FindHouseAndT.Models.Helper;
using Microsoft.AspNetCore.Http;

namespace FindHouseAndT.Infrastructure.ExternalServices
{
	public class AWSFileStorageService : IFileStorageService
	{
		private readonly IAmazonS3 _amazonS3;

		public AWSFileStorageService(IAmazonS3 amazonS3)
		{
			_amazonS3 = amazonS3;
		}

		public Task<string?> GetPreSignedUrlAsync(string? key)
		{
			if (string.IsNullOrEmpty(key))
			{
				return Task.FromResult<string?>(null);
			}
			var preSignedRequest = new GetPreSignedUrlRequest()
			{
				BucketName = BucketAWS.BucketName,
				Key = key,
				Expires = DateTime.UtcNow.AddDays(1)
			};
			return _amazonS3.GetPreSignedURLAsync(preSignedRequest);
		}

		public async Task<string?> UploadImageAsync(IFormFile? file)
		{
			if (file == null)
			{
				return null;
			}
			var IsExistBucket = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_amazonS3, BucketAWS.BucketName);
			if (IsExistBucket)
			{
				var key = $"{DateTime.Now:yyyy\\/MM\\/dd\\/hhmmss}-{file.FileName}";
				var putObjectRq = new PutObjectRequest()
				{
					BucketName = BucketAWS.BucketName,
					Key = key,
					InputStream = file.OpenReadStream()
				};
				var responseStatus = await _amazonS3.PutObjectAsync(putObjectRq);
				if (responseStatus.HttpStatusCode == System.Net.HttpStatusCode.OK)
				{
					return key;
				}
			}
			return null;
		}
	}
}
