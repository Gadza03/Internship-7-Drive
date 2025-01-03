﻿
using Drive.Data.Entities;
using Drive.Data.Entities.Models;
using Drive.Data.Enums;
using Drive.Domain.Enums;

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
        public ResponseResultType Update(Folder folder)
        {
            DbContext.Folders.Update(folder);
            return SaveChanges();
        }
        public ResponseResultType Delete(Folder folder)
        {
            DbContext.Folders.Remove(folder);
            return SaveChanges();
        }
        public void CreateFolder(string name, int userId, int parentFolderId)
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
        public ResponseResultType ValidateItemName(ItemType type, string name, int userId, int? parentFolderId, FileRepository _fileRepository)
        {
            if (string.IsNullOrEmpty(name))
                return ResponseResultType.ValidationError;

            if (name.Length < 2 || name.StartsWith(" ") || name.EndsWith(" "))
                return ResponseResultType.ValidationError;

            if (IsFolderExistsInParent(name, userId, parentFolderId))
                return ResponseResultType.AlreadyExists;

            if (type == ItemType.Folder)
            {
                if (name == "Root")
                    return ResponseResultType.ValidationError;
                
            }
            if (type == ItemType.File)
            {
                if (_fileRepository.IsFileExistsInFolder(name,userId,parentFolderId))                
                    return ResponseResultType.AlreadyExists;                
            }

            return ResponseResultType.Success;
        }
        public bool IsFolderExistsInParent(string name, int userId, int? parentFolderId)
        {
            return DbContext.Folders.Any(f => f.Name == name && f.OwnerId == userId && f.ParentFolderId == parentFolderId);
        }
        public List<Folder> GetFileByParentFolderAndOwner(Folder parentFolder, User owner)
        {
            return DbContext.Folders.Where(f => f.ParentFolderId == parentFolder.Id && f.OwnerId == owner.Id).ToList();
        }
        public Folder? GetFolderByNameAndParentFolder(string name, User user, int parentFolderId)
        {
            return DbContext.Folders.FirstOrDefault(f => f.Name == name && f.OwnerId == user.Id && f.ParentFolderId == parentFolderId);
        }
        public Folder? GetRootFolder(string name, User user)
        {
            return DbContext.Folders.FirstOrDefault(f => f.Name == name && f.OwnerId == user.Id);
        }
        
    }
}
