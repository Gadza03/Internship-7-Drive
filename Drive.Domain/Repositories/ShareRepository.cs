using Drive.Data.Entities;
using Drive.Data.Entities.Models;
using Drive.Data.Enums;
using Drive.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using File = Drive.Data.Entities.Models.File;

namespace Drive.Domain.Repositories
{
    public class ShareRepository : BaseRepository
    {
        public ShareRepository(DriveDbContext dbContext) : base(dbContext)
        {            
        }
        public ResponseResultType Add(Share share)
        {
            DbContext.SharedItems.Add(share);
            return SaveChanges();
        }
        public ResponseResultType Delete(Share share)
        {
            DbContext.SharedItems.Remove(share);
            return SaveChanges();
        }
        public Share? GetShare(User sharedBy, User sharedWith, int itemId)
        {
            return DbContext.SharedItems.FirstOrDefault(s => s.SharedById == sharedBy.Id && s.SharedWithId == sharedWith.Id && s.ItemId == itemId);
        }
        public IEnumerable<Folder> GetSharedFoldersWithUser(User user)
        {
            return DbContext.SharedItems
                .Where(s => s.SharedWithId == user.Id && s.ItemType == ItemType.Folder)
                .Join(
                    DbContext.Folders.Include(f => f.Owner),
                    share => share.ItemId,
                    folder => folder.Id,
                    (share, folder) => folder
                )
                .OrderBy(folder => folder.Name)
                .ToList();
        }
        public ResponseResultType DeleteFolderFromShareWith(Folder folder, User sharedWithUser)
        {
            var sharedItems = DbContext.SharedItems.Where(si => si.ItemId == folder.Id && si.SharedWithId == sharedWithUser.Id).ToList();
            foreach (var share in sharedItems)            
                Delete(share); 

            var filesInFolder = DbContext.Files.Where(f => f.FolderId == folder.Id).ToList();
            foreach (var file in filesInFolder)
            {
                var fileShare = DbContext.SharedItems
                    .FirstOrDefault(si => si.ItemId == file.Id && si.SharedWithId == sharedWithUser.Id && si.ItemType == ItemType.File);

                if (fileShare != null)                                 
                    Delete(fileShare);                
            }            

            var childFolders = DbContext.Folders.Where(f => f.ParentFolderId == folder.Id).ToList();
            foreach (var childFolder in childFolders)            
                DeleteFolderFromShareWith(childFolder, sharedWithUser); 

            return ResponseResultType.Success;
        }
        public ResponseResultType DeleteFileFromShareWith(File file, User sharedWithUser)
        {
            var share = DbContext.SharedItems.FirstOrDefault(si => si.ItemId == file.Id && si.SharedWithId == sharedWithUser.Id && si.ItemType == ItemType.File);

            if (share != null)            
                return Delete(share);            

            return ResponseResultType.NotFound;
        }        
        public IEnumerable<File> GetSharedFilesWithUser(User user)
        {
            return DbContext.SharedItems
                .Where(s => s.SharedWithId == user.Id && s.ItemType == ItemType.File)
                .Join(
                    DbContext.Files.Include(f => f.Owner).Include(f => f.Folder),
                    share => share.ItemId,
                    file => file.Id,
                    (share, file) => file
                )
                .OrderByDescending(file => file.LastModifiedAt)
                .ToList();
        }
        public bool IsSharedItemExists(ItemType type, int itemId, User sharedBy, User sharedWith)
        {
            return DbContext.SharedItems.Any(s => s.ItemId == itemId && s.ItemType == type &&
                                                s.SharedById == sharedBy.Id && s.SharedWithId == sharedWith.Id);
        }
        public ResponseResultType DeleteShareByTypeAndItemId(ItemType type, int itemId)
        {
            var share = DbContext.SharedItems.FirstOrDefault(s => s.ItemType == type && s.ItemId == itemId);
            if (share != null)
            { 
                return Delete(share);
            }
            return ResponseResultType.NotFound;
        }
        public File? GetSharedFileByNameAndParentFolder(IEnumerable<File> sharedFiles, string name, int parentFolderId)
        {
            if (parentFolderId == 0)
            {
                return sharedFiles.FirstOrDefault(f => f.Name == name);
            }
            return sharedFiles.FirstOrDefault(f => f.Name == name && f.FolderId == parentFolderId);
        }
        public Folder? GetSharedFolderByNameAndParentFolder(IEnumerable<Folder> sharedFolders, string name, int parentFolderId)
        {
            if (parentFolderId == 0)
            {
                return sharedFolders.FirstOrDefault(f => f.Name == name);
            }
            return sharedFolders.FirstOrDefault(f => f.Name == name && f.ParentFolderId == parentFolderId);
        }
    }
}
