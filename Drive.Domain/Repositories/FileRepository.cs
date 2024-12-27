

using Drive.Data.Entities;
using Drive.Domain.Enums;
using File = Drive.Data.Entities.Models.File;

namespace Drive.Domain.Repositories
{
    public class FileRepository : BaseRepository
    {
        public FileRepository(DriveDbContext dbContext) : base(dbContext)
        {
        }
        public ResponseResultType Add(File file)
        {
            DbContext.Files.Add(file);
            return SaveChanges();
        }
        public void CreateFile(string name, int userId, int parentFolderId)
        {
            var newFile = new File
            {
                Name = name,
                Content = "",
                OwnerId = userId,
                FolderId = parentFolderId,
                CreatedAt = DateTime.UtcNow,
                LastModifiedAt = DateTime.UtcNow,

            };
            Add(newFile);
        }
        public bool IsFileExists(string name, int userId, int folderId)
        {
            return DbContext.Files.Any(f => f.Name == name && f.OwnerId == userId && f.FolderId == folderId);
        }
    }
}
