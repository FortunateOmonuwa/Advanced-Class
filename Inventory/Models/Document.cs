global using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    public class Document
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public DateTime UploadedOn { get; set; } = DateTime.Now.Date;
    }
}
