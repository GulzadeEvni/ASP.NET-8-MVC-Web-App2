using System.ComponentModel.DataAnnotations.Schema;

namespace StarWars.Entity
{
    [Table("footer")]
    public class Footer
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("link_title")]
        public string? LinkTitle { get; set; }

        [Column("link_url")]
        public string? LinkUrl { get; set; }

        [Column("description")]
        public string? Description { get; set; }
    }
}
