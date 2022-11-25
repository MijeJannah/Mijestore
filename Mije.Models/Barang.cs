using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mije.Models
{
    public class Barang
    {
        public int Id { get; set; }
        [Required]
        [ValidateNever]
        public string Name { get; set; }
        [Required]
        [ValidateNever]
        public int ProdukID { get; set; }
        [ForeignKey("ProdukID")]
        [ValidateNever]
        public Produk Produk { get; set; }
        [Required]
        [ValidateNever]
        public string desk { get;set; }
        [ValidateNever]
        public string photo { get;set; }
        [ValidateNever]
        public int Harga { get;set; }

    }
}
