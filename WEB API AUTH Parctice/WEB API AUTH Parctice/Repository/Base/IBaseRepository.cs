using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace WEB_API_AUTH_Parctice.Repository.Base;

public interface IBaseRepository<TEntity,IModel,T>
    where TEntity : class, new() // this is to check for validation i this is the requried class or not
    where IModel : class, new()
    where T : IEquatable<T>
{
    public Task<List<IModel>> GetAllAsync();
    public Task<IModel?> GetByIdAsync(Expression<Func<TEntity, bool>> predicate);
    public Task<IModel> CreateAsync (IModel entity);
    public Task<IModel> UpdateAsync(T id,IModel entity);
    public Task<IModel> DeleteAsync(T id);
}
