

using Drive.Data.Entities;
using Drive.Data.Entities.Models;
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
        public ResponseResultType Update(File file)
        {
            DbContext.Files.Update(file);
            return SaveChanges();
        }
        public ResponseResultType Delete(File file)
        {
            DbContext.Files.Remove(file);
            return SaveChanges();
        }
        public void CreateFile(string name, int userId, int folderId)
        {
            var newFile = new File
            {
                Name = name,
                Content = "",
                OwnerId = userId,
                FolderId = folderId,
                CreatedAt = DateTime.UtcNow,
                LastModifiedAt = DateTime.UtcNow,

            };
            Add(newFile);
        }
        public List<File> GetFileByFolderAndOwner(Folder folder, User owner)
        {
            return DbContext.Files.Where(f => f.FolderId == folder.Id && f.OwnerId == owner.Id).ToList();
        }
        public File? GetFileByNameAndFolder(string name, User user, int folderId)
        {
            return DbContext.Files.FirstOrDefault(f => f.Name == name && f.OwnerId == user.Id && f.FolderId == folderId);
        }
        public bool IsFileExistsInFolder(string name, int userId, int? folderId)
        {
            return DbContext.Files.Any(f => f.Name == name && f.OwnerId == userId && f.FolderId == folderId);
        }
        public bool IsFileExistsInDrive(string name, int userId)
        {
            return DbContext.Files.Any(f => f.Name == name && f.OwnerId == userId);
        }
    }
}
