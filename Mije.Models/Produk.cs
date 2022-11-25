using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mije.Models
{
    public class Produk
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Stock")]
        public int Stock { get; set; }

    }
}
