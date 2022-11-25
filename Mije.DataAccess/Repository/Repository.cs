using Microsoft.EntityFrameworkCore;
using Mije.Data;
using Mije.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mije.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ProdukDbContext _db;
        internal DbSet<T> dbset;
        public Repository(ProdukDbContext db)
        {
            _db = db;
            //db.barangs.Include(u => u.Produk);
            this.dbset = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
            if(includeProperties != null)
            {
                foreach(var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public T GetFirstorDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
           dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
           dbset.RemoveRange(entity);
        }
    }
}
