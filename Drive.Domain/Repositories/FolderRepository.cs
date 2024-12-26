

using Drive.Data.Entities;
using Drive.Data.Entities.Models;
using Drive.Domain.Enums;

namespace Drive.Domain.Repositories
{
    public class FolderRepository : BaseRepository
    {
        public FolderRepository(DriveDbContext dbContext) : base(dbContext)
        {
        }
       
        public void CreateRootFolder(User user)
        {
            DbContext.Folders.Add(new Folder
            { 
                Name = "Root",
                ParentFolderId = null,
                CreatedAt = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                OwnerId = user.Id,
            });
            DbContext.SaveChanges();
        }
        public Folder? GetRootFolder(IEnumerable<Folder> folders) 
        {
            return folders.FirstOrDefault(f => f.Name == "Root");
        }
    }
}
