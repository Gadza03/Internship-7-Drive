using Drive.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Drive.Data.Entities.Models
{
    public class Share
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public ItemType ItemType { get; set; }
        public int SharedById { get; set; }
        public int SharedWithId { get; set; }
        public User SharedWith { get; set; } = null!;
        public User SharedBy { get; set; } = null!;


    }
}
