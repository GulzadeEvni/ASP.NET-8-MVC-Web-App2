
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWars.Entity
{
    [Table("contacts")]
    public class Contacts
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("img_url")]
        public string? ImgUrl { get; set; }
    }
}
