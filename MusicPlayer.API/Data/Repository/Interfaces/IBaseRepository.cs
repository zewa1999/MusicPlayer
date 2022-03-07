using System.Linq.Expressions;

namespace MusicPlayer.API.Data.Repository.Interfaces;

public interface IBaseRepository<T>
{
    /// <summary>
    /// Inserts the specified entity.
    /// </summary>
    /// <param name="entity"> The entity. </param>
    bool Insert(T entity);

    /// <summary>
    /// Updates the specified item.
    /// </summary>
    /// <param name="item"> The item. </param>
    bool Update(T item);

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id"> The identifier. </param>
    bool DeleteById(object id);

    /// <summary>
    /// Deletes the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    bool Delete(T entity);

    /// <summary>
    /// Deletes all entities from table.
    /// </summary>
    /// <param name="tableName">Name of the table.</param>
    bool DeleteAllEntitiesFromTable();

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id"> The identifier. </param>
    T GetByID(object id);

    /// <summary>
    /// Gets the specified filter.
    /// </summary>
    /// <param name="filter"> The filter. </param>
    /// <param name="orderBy"> The order by. </param>
    /// <param name="includeProperties"> The include properties. </param>
    IEnumerable<T> Get(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "");
}