using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.ExternalInterface
{
	public interface IFileStorageService
	{
		Task<string?> UploadImageAsync(IFormFile? file);
		Task<string?> GetPreSignedUrlAsync(string? key);
	}
}
