
namespace Drive.Data.Entities.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }   
        public string? PasswordHash { get; set; }
        public ICollection<Folder>? Folders { get; set; }
        public ICollection<File>? Files { get; set; }
        public ICollection<Share>? SharedItems { get; set; }
        public User(int id, string name, string surname, string email, string passwordHash)
        {
            this.Id = id;
            this.Name = name;       
            this.Surname = surname;
            this.Email = email;
            this.PasswordHash = passwordHash;
        }
        public User(string name, string surname, string email, string passwordHash)
        {           
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.PasswordHash = passwordHash;
        }
    }
}
