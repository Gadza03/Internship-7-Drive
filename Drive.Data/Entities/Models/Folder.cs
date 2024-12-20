

namespace Drive.Data.Entities.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ParentFolderId { get; set; }
        public Folder? ParentFolder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModified {  get; set; }
        public ICollection<Folder>? SubFolders { get; set; }
        public ICollection<File>? Files { get; set; }
        public int OwnerId { get; set; }
        public User? Owner { get; set; }
        
    }
}
