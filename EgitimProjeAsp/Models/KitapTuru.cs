using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EgitimProjeAsp.Models
{
    public class KitapTuru
    {
        [Key] //primary key
        public int id { get; set; }

        [Required(ErrorMessage ="Kitap Tür Adı boş bırakılamaz!")] //not null
        [MaxLength(25)]    
        [DisplayName("Kitap Türü Adı")]
        public required string Ad { get; set; }
    }
}
