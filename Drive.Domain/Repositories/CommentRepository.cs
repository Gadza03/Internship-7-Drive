

using Drive.Data.Entities;

namespace Drive.Domain.Repositories
{
    public class CommentRepository : BaseRepository
    {
        public CommentRepository(DriveDbContext dbContex) : base(dbContex) { }

    }
}
