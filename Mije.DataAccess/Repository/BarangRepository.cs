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
    public class BarangRepository : Repository<Barang>, IBarangRepository
    {
        private ProdukDbContext _db;
        public BarangRepository(ProdukDbContext db) : base(db)
        {
            _db = db;
        }


        public void update(Barang obj)
        {
            _db.barangs.Update(obj);
        }
    }
}
