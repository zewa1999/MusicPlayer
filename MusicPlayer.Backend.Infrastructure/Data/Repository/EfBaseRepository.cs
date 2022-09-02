using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicPlayer.Backend.SharedKernel;
using MusicPlayer.Backend.SharedKernel.Interfaces;
using System.Linq.Expressions;

namespace MusicPlayer.Backend.Infrastructure.Data.Repository;

public abstract class EfBaseRepository<T> : IBaseRepository<T>
    where T : BaseEntity
{
    protected MusicPlayerContext Ctx { get; set; }
    protected ILogger Logger { get; set; }

    public EfBaseRepository(MusicPlayerContext ctx, ILogger logger)
    {
        Logger = logger;
        Ctx = ctx;
    }

    public virtual IEnumerable<T>? Get(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
        try
        {
            var databaseSet = Ctx.Set<T>();

            IQueryable<T> query = databaseSet;

            if (filter != null)
            {
                query = query.Where(filter);
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
            Logger.LogError(ex.Message + "The query will return an empty list!");
        }

        return null;
    }

    public virtual bool Insert(T entity)
    {
        try
        {
            var databaseSet = Ctx.Set<T>();
            databaseSet.Add(entity);
            Ctx.SaveChanges();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message + ex.InnerException + "The INSERT could not been made!");
            return false;
        }

        return true;
    }

    public virtual bool Update(T item)
    {
        try
        {
            var databaseSet = Ctx.Set<T>();
            databaseSet.Attach(item);
            Ctx.Entry(item).State = EntityState.Modified;

            Ctx.SaveChanges();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message + ex.InnerException + "The UPDATE could not been made!");
            return false;
        }

        return true;
    }

    public virtual bool DeleteById(object id)
    {
        try
        {
            Delete(GetByID(id)!);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message + ex.InnerException + "The DELETE could not been made!");
            return false;
        }

        return true;
    }

    public virtual bool Delete(T entityToDelete)
    {
        try
        {
            var dbSet = Ctx.Set<T>();

            if (Ctx.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }

            dbSet.Remove(entityToDelete);

            Ctx.SaveChanges();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message + ex.InnerException + "The DELETE could not been made!");
            return false;
        }

        return true;
    }

    public virtual T? GetByID(object id)
    {
        try
        {
            return Ctx.Set<T>().Find(id);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message + ex.InnerException + "The GetByID could not been made. Will return null!");
        }

        return null;
    }

    public bool DeleteAllEntitiesFromTable()
    {
        try
        {
            var dbSet = Ctx.Set<T>();
            dbSet.RemoveRange(dbSet);
            Ctx.SaveChanges();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message + ex.InnerException + "The DeleteAllEntitiesFromTable could not been made.");
            return false;
        }

        return true;
    }
}