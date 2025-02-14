using FindHouseAndT.Application.DTOs;
using FindHouseAndT.Application.ExternalInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Infrastructure.ExternalServices
{
    public class PDFContractService : IPDFContractService
    {
        public Task<byte[]> AddSignatureAsync(Guid contractId, SignatureDTO signatureData)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GenerateContractAsync(CreateContractDTO contractData)
        {
            throw new NotImplementedException();
        }
    }
}
