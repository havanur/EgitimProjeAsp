using EgitimProjeAsp.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EgitimProjeAsp.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly UygulamaDBContext _uygulamaDBContext;

        internal DbSet<T> dbSet; //_uygulamaDBContext.KitapTuruleri

        public Repository(UygulamaDBContext uygulamaDBContext)
        {
            _uygulamaDBContext = uygulamaDBContext;
            this.dbSet = _uygulamaDBContext.Set<T>();
        }

        public void AralikSil(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void Ekle(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filtre)
        {
            IQueryable<T> sorgu = dbSet;
            sorgu=sorgu.Where(filtre);
            return sorgu.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> sorgu = dbSet;
            return sorgu.ToList();
        }

        public void Sil(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
