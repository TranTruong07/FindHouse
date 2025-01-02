using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FindHouseAndT.Application.DTOs
{
    public class MotelManagerDTO
    {
        public Guid IdMotel { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int QuantityRoom { get; set; }
        public Guid IdHouseOwner { get; set; }
        [Required]
        public string Description1 { get; set; }
        public string? Description2 { get; set; }
        public IFormFile? ImageFIle { get; set; }
        public string? ImageMotel { get; set; }
    }
}
