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
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ProdukDbContext _db;
        public CoverTypeRepository(ProdukDbContext db) : base(db)
        {
            _db = db;
        }


        public void update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
        }
    }
}
