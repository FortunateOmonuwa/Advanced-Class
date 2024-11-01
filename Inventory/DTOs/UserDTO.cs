namespace Inventory.DTOs
{
    public class UserDTO
    {
    }
    public class UserRegisterDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required IFormFile IdentificationDocument { get; set; }
    }
}
