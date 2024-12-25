using Amazon.S3;
using Amazon.S3.Model;
using FindHouseAndT.Models.Helper;
using Microsoft.AspNetCore.Http;

namespace FindHouseAndT.Application.UseCase.Implement.Common
{
	public class AWSUploadImageUseCase : IAWSUploadImageUseCase
	{
		public async Task<string?> ExecuteAsync(IFormFile file, IAmazonS3 amazonS3)
		{
			var IsExistBucket = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(amazonS3, BucketAWS.BucketName);
			if(IsExistBucket)
			{
				var key = $"{DateTime.Now:yyyy\\/MM\\/dd\\/hhmmss}-{file.FileName}";
				var putObjectRq = new PutObjectRequest()
				{
					BucketName = BucketAWS.BucketName,
					Key = key,
					InputStream = file.OpenReadStream() 
				};
				var responseStatus = await amazonS3.PutObjectAsync(putObjectRq);
				if(responseStatus.HttpStatusCode == System.Net.HttpStatusCode.OK)
				{
					return key;
				}
			}
			return null;
		}
	}
}
