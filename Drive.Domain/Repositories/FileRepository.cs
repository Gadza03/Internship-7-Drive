

using Drive.Data.Entities;

namespace Drive.Domain.Repositories
{
    public class FileRepository : BaseRepository
    {
        public FileRepository(DriveDbContext dbContext) : base(dbContext)
        {
        }
    }
}
