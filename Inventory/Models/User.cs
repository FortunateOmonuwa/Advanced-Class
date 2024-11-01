namespace Inventory.Models
{
    public class User
    {
        [Key]
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Document> Documents { get; set; } = [];
    }
}
