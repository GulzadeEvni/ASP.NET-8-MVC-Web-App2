using System.ComponentModel.DataAnnotations.Schema;

namespace StarWars.Entity
{
    [Table("pages")]
    public class Pages
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("page_name")]
        public string? PageName { get; set; }

        [Column("title")]
        public string? Title { get; set;}

       // [Column("redirect_url")]
       // public string? RedirectUrl { get; set; }

        [Column("content")]
        public string? Content { get; set; }


    }
}
