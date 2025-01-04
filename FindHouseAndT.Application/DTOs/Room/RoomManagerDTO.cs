using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FindHouseAndT.Application.DTOs
{
    public class RoomManagerDTO
    {
        public int Id { get; set; }
        [Required]
        public string RoomCode { get; set; }
        public string OldRoomCode { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public double Area { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? Status { get; set; }
        [Required]
        public string Description1 { get; set; }
        public string? Description2 { get; set; }
        public string? UrlImageRoom { get; set; }
        [Required]
        public IFormFile ImageRoom { get; set; }
        [Required]
        public Guid IdMotel { get; set; }
    }
}
