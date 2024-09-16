using System.ComponentModel.DataAnnotations.Schema;

namespace StarWars.Entity
{
    [Table("top_content")]
    public class TopContent
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("img_url")]
        public string? ImgUrl { get; set; }

        [Column("alt_text")]
        public string? AltText { get; set; }

        [Column("page_id")]
        public int PageId { get; set; }
    }
}
