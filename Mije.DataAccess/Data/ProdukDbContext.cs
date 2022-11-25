using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Mije.Models;

namespace Mije.Data
{
    public class ProdukDbContext : IdentityDbContext
    {
        public ProdukDbContext(DbContextOptions<ProdukDbContext> options) : base(options)
        {

        }
        public DbSet<Produk> produks { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Barang> barangs { get; set; }
       
    }
}
