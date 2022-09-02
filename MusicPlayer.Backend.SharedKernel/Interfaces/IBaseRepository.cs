using System.Linq.Expressions;

namespace MusicPlayer.Backend.SharedKernel.Interfaces;

public interface IBaseRepository<T>
    where T : BaseEntity
{
    bool Insert(T entity);

    bool Update(T item);

    bool DeleteById(object id);

    bool Delete(T entity);

    T? GetByID(object id);

    IEnumerable<T>? Get(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
}