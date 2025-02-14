using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.DTOs
{
    public class SignatureDTO
    {
        public string SignatureImage { get; set; } 
        public string SignedBy { get; set; }
        public DateTime SignedDate { get; set; }
    }
}
