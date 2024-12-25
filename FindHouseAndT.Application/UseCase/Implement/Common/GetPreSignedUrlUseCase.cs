using Amazon.S3;
using Amazon.S3.Model;
using FindHouseAndT.Models.Helper;

namespace FindHouseAndT.Application.UseCase
{
	public class GetPreSignedUrlUseCase : IGetPreSignedUrlUseCase
	{
		public async Task<string?> ExecuteAsync(string key, IAmazonS3 amazonS3)
		{
			var preSignedRequest = new GetPreSignedUrlRequest()
			{
				BucketName = BucketAWS.BucketName,
				Key = key,
				Expires = DateTime.UtcNow.AddDays(1)
			};
			return await amazonS3.GetPreSignedURLAsync(preSignedRequest);
		}
	}
}
