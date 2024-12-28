using Amazon.S3;

namespace FindHouseAndT.Application.UseCase
{
	public interface IGetPreSignedUrlUseCase
	{
		// return PreSignedUrl
		Task<string?> ExecuteAsync(string key, IAmazonS3 amazonS3);
	}
}
