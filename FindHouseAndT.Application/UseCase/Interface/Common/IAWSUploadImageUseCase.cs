using Amazon.S3;
using Microsoft.AspNetCore.Http;


namespace FindHouseAndT.Application.UseCase
{
	public interface IAWSUploadImageUseCase
	{
		// return key of object: PutObjectRequest
		Task<string?> ExecuteAsync(IFormFile file, IAmazonS3 amazonS3);
	}
}
