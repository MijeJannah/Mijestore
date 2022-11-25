using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mije.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IProdukRespository Produk { get; }
        ICoverTypeRepository CoverType { get; } 
        IBarangRepository Barang { get; }
        void Save();
    }
}
