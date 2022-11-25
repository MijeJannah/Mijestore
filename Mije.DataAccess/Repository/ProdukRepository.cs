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
    public class ProdukRepository : Repository<Produk>, IProdukRespository
    {
        private ProdukDbContext _db;
        public ProdukRepository(ProdukDbContext db) : base(db)
        {
            _db = db;
        }


        public void update(Produk obj)
        {
            _db.produks.Update(obj);
        }
    }
}
