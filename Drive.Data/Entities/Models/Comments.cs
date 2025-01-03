
namespace Drive.Data.Entities.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int FileId { get; set; }
        public File? File { get; set; }
        public int AuthorId { get; set; }
        public User? Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }

    }
}
