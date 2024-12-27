
using File = Drive.Data.Entities.Models.File;

using Drive.Data.Entities;
using Drive.Data.Entities.Models;
using Drive.Data.Enums;
using Drive.Domain.Enums;
using Drive.Domain.Factories;

namespace Drive.Domain.Repositories
{
    public class FolderRepository : BaseRepository
    {      
        public FolderRepository(DriveDbContext dbContext) : base(dbContext)
        {
           
        }
        public ResponseResultType Add(Folder folder)
        {
            DbContext.Folders.Add(folder);
            return SaveChanges();

        }
        public ResponseResultType CreateFolderOrFile(ItemType type, string name, int userId, int parentFolderId, FileRepository _fileRepository)
        {
            var responseResult = ValidateItemName(type,name, userId, parentFolderId, _fileRepository);
            if (responseResult != ResponseResultType.Success)            
                return responseResult;
            
            if (type == ItemType.Folder)
            {
                var newFolder = new Folder
                {
                    Name = name,
                    ParentFolderId = parentFolderId,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    OwnerId = userId,
                };
                Add(newFolder);
            }
            else
                _fileRepository.CreateFile(name, userId, parentFolderId);
                           
            return ResponseResultType.Success;            
        }
        public ResponseResultType ValidateItemName(ItemType type, string name, int userId, int parentFolderId, FileRepository _fileRepository)
        {
            if (string.IsNullOrEmpty(name))
                return ResponseResultType.ValidationError;
            if (name.Length < 2 || name.StartsWith(" ") || name.EndsWith(" "))
                return ResponseResultType.ValidationError;
            if (type == ItemType.Folder)
            {
                if (name == "Root")
                    return ResponseResultType.ValidationError;
                if (IsFolderExistsInParent(name, userId, parentFolderId))
                    return ResponseResultType.AlreadyExists;
            }
            if (type == ItemType.File)
            {
                if (_fileRepository.IsFileExists(name,userId,parentFolderId))                
                    return ResponseResultType.AlreadyExists;                
            }

            return ResponseResultType.Success;
        }
        public bool IsFolderExistsInParent(string name, int userId, int parentFolderId)
        {
            return DbContext.Folders.Any(f => f.Name == name && f.OwnerId == userId && f.ParentFolderId == parentFolderId);
        }
        public bool IsFolderExists(string name, int userId)
        {
            return DbContext.Folders.Any(f => f.Name == name && f.OwnerId == userId);
        }
        public Folder? GetFolderByName(string name, int userId)
        {
            return DbContext.Folders.FirstOrDefault(f => f.Name == name && f.OwnerId == userId);
        }
        public Folder? GetRootFolder(IEnumerable<Folder> folders) 
        {
            return folders.FirstOrDefault(f => f.Name == "Root");
        }
    }
}
