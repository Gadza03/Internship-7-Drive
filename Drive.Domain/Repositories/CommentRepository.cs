
using File = Drive.Data.Entities.Models.File;
using Drive.Data.Entities;
using Drive.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Drive.Domain.Enums;

namespace Drive.Domain.Repositories
{
    public class CommentRepository : BaseRepository
    {
        public CommentRepository(DriveDbContext dbContex) : base(dbContex) { }
        public ResponseResultType Add(Comment comment)
        {
            DbContext.Comments.Add(comment);
            return SaveChanges();
        }
        public ResponseResultType Delete(Comment comment)
        {
            DbContext.Comments.Remove(comment);
            return SaveChanges();
        }
        public ResponseResultType Update(Comment comment)
        {
            DbContext.Comments.Update(comment);
            return SaveChanges();
        }
        public List<Comment> GetAllComments(File file)
        {
            return DbContext.Comments.Where(c => c.FileId == file.Id).Include(c => c.Author).ToList();
        }
        public Comment? GetCommentById(File file, int? id)
        {
            return DbContext.Comments.FirstOrDefault(c => c.FileId == file.Id && c.Id == id);
        }
        public int? ValidId(string commentId)
        {
            if (int.TryParse(commentId, out int parsedInt))
            {
                return parsedInt;
            }
            return null;
        }
    }
}
