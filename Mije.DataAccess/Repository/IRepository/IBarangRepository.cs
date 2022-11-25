using Mije.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mije.DataAccess.Repository.IRepository
{
    public interface IBarangRepository : IRepository<Barang>
    {
        void update(Barang obj);
    }
}
