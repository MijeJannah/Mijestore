using Mije.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mije.DataAccess.Repository.IRepository
{
    public interface IProdukRespository : IRepository<Produk>
    {
        void update(Produk obj);
    }
}
