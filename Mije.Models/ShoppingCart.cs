using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mije.Models
{
    public class ShoppingCart
    {
        public Barang barang { get; set; }
        [Range(1,1000, ErrorMessage ="Please enter a value ba")]
        public int count { get; set; }
    }
}
