using MusicPlayer.Backend.SharedKernel;
using System.Linq.Expressions;

namespace MusicPlayer.Backend.Core.Interfaces;

public interface IBaseService<TModel>
    where TModel : BaseEntity
{
    bool Insert(TModel entity);

    bool Update(TModel item);

    bool DeleteById(object id);

    TModel? GetByID(object id);

    IEnumerable<TModel>? Get(
        Expression<Func<TModel, bool>>? filter = null,
        Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orderBy = null);
}