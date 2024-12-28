namespace FindHouseAndT.WebApp.DTOs
{
    public class RoomManagerDTO
    {
        public string? RoomCode { get; set; }
        public int Floor { get; set; }
        public double Area { get; set; }
        public decimal Price { get; set; }
        public string? Status { get; set; }
        public string? Description1 { get; set; }
        public string? Description2 { get; set; }
        public string? UrlImageRoom { get; set; }
        public IFormFile? ImageRoom { get; set; }
        public Guid IdMotel { get; set; }
    }
}
