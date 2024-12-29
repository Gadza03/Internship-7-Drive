using Drive.Data.Entities;
using Drive.Data.Entities.Models;
using Drive.Domain.Enums;


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
    }
}
