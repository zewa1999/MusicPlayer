using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicPlayer.API.Data.Repository.Interfaces;
using System.Linq.Expressions;

namespace MusicPlayer.API.Data.Repository.Concretes;

public abstract class BaseRepository<T> : IBaseRepository<T>
   where T : class
{
    /// <summary>
    /// Gets or sets the CTX.
    /// </summary>
    /// <value>The CTX.</value>
    protected MusicPlayerContext Ctx { get; set; }

    /// <summary>
    /// Gets or sets the logger.
    /// </summary>
    /// <value>The logger.</value>
    protected ILogger Logger { get; set; }

    public BaseRepository(MusicPlayerContext ctx, ILogger logger)
    {
        Logger = logger;
        Ctx = ctx;
    }

    /// <summary>
    /// Gets the specified filter.
    /// </summary>
    /// <param name="filter"> The filter. </param>
    /// <param name="orderBy"> The order by. </param>
    /// <param name="includeProperties"> The include properties. </param>
    public virtual IEnumerable<T> Get(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "")
    {
        try
        {
            var databaseSet = this.Ctx.Set<T>();

            IQueryable<T> query = databaseSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        catch (Exception ex)
        {
            this.Logger.LogError(ex.Message + "The query will return an empty list!");
        }

        return null;
    }

    /// <summary>
    /// Inserts the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public virtual bool Insert(T entity)
    {
        try
        {
            var databaseSet = this.Ctx.Set<T>();
            databaseSet.Add(entity);
            this.Ctx.SaveChanges();

            entity = null;
        }
        catch (Exception ex)
        {
            this.Logger.LogError(ex.Message + ex.InnerException + "The INSERT could not been made!");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Updates the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    public virtual bool Update(T item)
    {
        try
        {
            var databaseSet = this.Ctx.Set<T>();
            databaseSet.Attach(item);
            this.Ctx.Entry(item).State = EntityState.Modified;

            this.Ctx.SaveChanges();
        }
        catch (Exception ex)
        {
            this.Logger.LogError(ex.Message + ex.InnerException + "The UPDATE could not been made!");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    public virtual bool DeleteById(object id)
    {
        try
        {
            this.Delete(this.GetByID(id));
        }
        catch (Exception ex)
        {
            this.Logger.LogError(ex.Message + ex.InnerException + "The DELETE could not been made!");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Deletes the specified entity to delete.
    /// </summary>
    /// <param name="entityToDelete">The entity to delete.</param>
    public virtual bool Delete(T entityToDelete)
    {
        try
        {
            var dbSet = this.Ctx.Set<T>();

            if (this.Ctx.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }

            dbSet.Remove(entityToDelete);

            this.Ctx.SaveChanges();
        }
        catch (Exception ex)
        {
            this.Logger.LogError(ex.Message + ex.InnerException + "The DELETE could not been made!");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id"> The identifier. </param>
    public virtual T GetByID(object id)
    {
        try
        {
            return this.Ctx.Set<T>().Find(id);
        }
        catch (Exception ex)
        {
            this.Logger.LogError(ex.Message + ex.InnerException + "The GetByID could not been made. Will return null!");
        }

        return null;
    }

    /// <summary>
    /// Deletes all entities from table.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public bool DeleteAllEntitiesFromTable()
    {
        try
        {
            var dbSet = this.Ctx.Set<T>();
            dbSet.RemoveRange(dbSet);
            this.Ctx.SaveChanges();
        }
        catch (Exception ex)
        {
            this.Logger.LogError(ex.Message + ex.InnerException + "The DeleteAllEntitiesFromTable could not been made.");
            return false;
        }

        return true;
    }
}