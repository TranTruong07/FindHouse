namespace FindHouseAndT.WebApp.DTOs
{
    public class ProfileUserDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? UrlAvatar { get; set; }
        public IFormFile? Avatar { get; set; }
    }
}
