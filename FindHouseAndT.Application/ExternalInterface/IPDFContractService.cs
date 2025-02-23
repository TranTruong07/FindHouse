
using FindHouseAndT.Application.DTOs;

namespace FindHouseAndT.Application.ExternalInterface
{
    public interface IPDFContractService
    {
        Task<byte[]> GenerateContractAsync(CreateContractDTO contractData);
        Task<byte[]> AddSignatureAsync(Guid contractId, SignatureDTO signatureData);
    }
}
