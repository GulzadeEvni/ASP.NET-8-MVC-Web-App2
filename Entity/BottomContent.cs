using System.ComponentModel.DataAnnotations.Schema;

namespace StarWars.Entity
{
    [Table("bottom_content")]
    public class BottomContent
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("img_url")]
        public string? ImgUrl { get; set; }
    }
}
