using System.Linq.Expressions;

namespace EgitimProjeAsp.Models
{
    public interface IRepository<T> where T : class
    {
        // T -> KitapTuru
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T,bool>> filtre);

        void Ekle(T entity);

        void Sil(T entity);

        void AralikSil(IEnumerable<T> entities);
    }
}
