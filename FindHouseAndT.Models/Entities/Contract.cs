using FindHouseAndT.Models.Helper;

namespace FindHouseAndT.Models.Entities
{
    public class Contract
    {
        public Guid ContractId { get; set; }
        public Guid IdCustomer { get; set; }
        public required int BookRequestId { get; set; }
        public required int IdRoom { get; set; }
        public required string FullNameHouseOwner { get; set; }
        public required string FullNameCustomer { get; set; }
        public required string PhoneHouseOwner { get; set; }
        public required string PhoneCustomer { get; set; }
		public required DateOnly StartDate { get; set; }
        public required DateOnly EndDate { get; set; }
		public required DateOnly BookDate { get; set; }
		public required decimal Price { get; set; }
        public required string TermsOfContract { get; set; }
		public SignatureStatus StatusHouseOwner { get; set; }
		public SignatureStatus StatusCustomer { get; set; }
        public required string KeyContract { get; set; }
        public required string KeySignatureHouseOwner { get; set; }
        public required string KeySignatureCustomer { get; set; }
        public Customer? Customer { get; set; }
        public Room? Room { get; set; }
    }
}
