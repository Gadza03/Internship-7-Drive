using Drive.Data.Entities;
using Drive.Domain.Enums;
using Drive.Data.Entities.Models;
using System.Text.RegularExpressions;



namespace Drive.Domain.Repositories
{
    public class UserRepositroy : BaseRepository
    {
        public UserRepositroy(DriveDbContext dbContext) : base(dbContext)
        {
        }
        public ResponseResultType Add(User user)
        {
            DbContext.Users.Add(user);
            return SaveChanges();
        }
        public bool IsPasswordValid(string password, out string errorMessage)
        {
            errorMessage = "";

            if (string.IsNullOrEmpty(password))
            {
                errorMessage = "Password cannot be empty.";
                return false;
            }

            if (password.Length < 4)
            {
                errorMessage = "Password must be at least 4 characters long.";
                return false;
            }

            if (password.Contains(" "))
            {
                errorMessage = "Password must not contain spaces.";
                return false;
            }

            return true;
        }
        public bool IsValidEmail(string email)
        {
            if (email.Contains(" "))
                return false;            
            var pattern = @"^[^@]+@[^@]{2,}\.[^@]{3,}$";
            return Regex.IsMatch(email, pattern);
        }
        public User? EmailExists(string email)
        {
            var foundedUser = DbContext.Users.FirstOrDefault(u => u.Email == email.Trim());
            return foundedUser;  
        }
        public ResponseResultType IsPasswordValid(User user, string password)
        {
            if(VerifyPassword(password, user.PasswordHash))
                return ResponseResultType.Success; 
            return ResponseResultType.NotFound;
        }
        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        public IEnumerable<T> GetFoldersOrFiles<T>(User user)
        {
            if (typeof(T) == typeof(Folder))
                return DbContext.Folders.Where(u => u.OwnerId == user.Id).OrderBy(f => f.Name).Cast<T>().ToList();

            return DbContext.Files.Where(u => u.OwnerId == user.Id).OrderByDescending(f => f.LastModifiedAt).Cast<T>().ToList();
        }
        

        public User? GetUserByMail(string email)
        {
            return DbContext.Users.FirstOrDefault(u => u.Email == email);
        }
       
    }
}
