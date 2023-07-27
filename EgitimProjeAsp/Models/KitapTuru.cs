using System.ComponentModel.DataAnnotations;

namespace EgitimProjeAsp.Models
{
    public class KitapTuru
    {
        [Key] //primary key
        public int id { get; set; }

        [Required] //not null
        public required string Ad { get; set; }
    }
}
