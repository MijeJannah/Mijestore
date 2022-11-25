using Mije.Data;
using Mije.DataAccess.Repository.IRepository;
using Mije.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mije.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProdukDbContext _db;
        public UnitOfWork(ProdukDbContext db)
        {
            _db = db;
            Produk = new ProdukRepository(_db);
            CoverType = new CoverTypeRepository(_db);
            Barang = new BarangRepository(_db);
        }
        public IProdukRespository Produk { get; private set; }
        public ICoverTypeRepository CoverType {get; private set; }
        public IBarangRepository Barang { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
