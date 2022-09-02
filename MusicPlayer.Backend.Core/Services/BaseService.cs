using FluentValidation;
using Microsoft.Extensions.Logging;
using MusicPlayer.Backend.Core.Interfaces;
using MusicPlayer.Backend.SharedKernel;
using MusicPlayer.Backend.SharedKernel.Interfaces;
using System.Linq.Expressions;

namespace MusicPlayer.Backend.Core.Services;

public class BaseService<TModel> : IBaseService<TModel>
    where TModel : BaseEntity
{
    protected IBaseRepository<TModel> Repository { get; set; }
    protected IValidator<TModel> Validator { get; set; }
    protected ILogger Logger { get; set; }

    public BaseService(IBaseRepository<TModel> repository, IValidator<TModel> validator, ILogger logger)
    {
        Repository = repository;
        Validator = validator;
        Logger = logger;
    }

    public virtual TModel GetByID(object id)
    {
        return Repository.GetByID(id)!;
    }

    public IEnumerable<TModel>? Get(Expression<Func<TModel, bool>>? filter = null,
        Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orderBy = null)
    {
        return Repository.Get(filter, orderBy);
    }

    public virtual bool Insert(TModel entity)
    {
        var result = Validator.Validate(entity);
        var isValid = false;
        if (result.IsValid)
        {
            isValid = true;
        }
        else
        {
            foreach (var error in result.Errors)
            {
                Logger.LogError(error.ErrorMessage);
            }

            return false;
        }

        if (isValid == true)
        {
            Repository.Insert(entity);
        }

        return true;
    }

    public virtual bool Update(TModel entity)
    {
        var result = Validator.Validate(entity);
        if (result.IsValid)
        {
            Repository.Update(entity);
        }
        else
        {
            foreach (var error in result.Errors)
            {
                Logger.LogError(error.ErrorMessage);
            }
            return false;
        }

        return true;
    }

    public virtual bool DeleteById(object id)
    {
        return Repository.DeleteById(id);
    }
}