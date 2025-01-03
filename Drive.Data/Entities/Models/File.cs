﻿
namespace Drive.Data.Entities.Models
{
    public class File
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Content { get; set; }
        public int FolderId { get; set; }
        public Folder? Folder { get; set; }
        public int OwnerId { get; set; }
        public User? Owner { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}
