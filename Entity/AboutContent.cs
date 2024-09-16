using System.ComponentModel.DataAnnotations.Schema;

namespace StarWars.Entity
{
    [Table("about_contents")]
    public class AboutContent
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("img_contents")]
        public string ImgContents { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("page_name")]
        public int PageName { get; set; }
    }
}
