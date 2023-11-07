using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WEB_API_AUTH_Parctice.Repository.Base;

public class BaseRepository<TEntity, IModel, T> : IBaseRepository<TEntity, IModel, T>
    where TEntity : class,new()
    where IModel : class, new()
    where T : IEquatable<T>
{
    protected readonly IMapper _mapper;
    private readonly DbContext _context;

    private DbSet<TEntity> DbSet { get; set; }

    // this for the mapper and dbcontext
    protected BaseRepository(IMapper mapper, DbContext context)
    {
        _mapper = mapper;
        _context = context;
        DbSet = _context.Set<TEntity>();
    }

    public async Task<List<IModel>> GetAllAsync()
    {
        return _mapper.Map<List<IModel>>(await DbSet.ToListAsync());
    }

    public async Task<IModel? > GetByIdAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return _mapper.Map<IModel?>(await DbSet.FirstOrDefaultAsync(predicate));
    }

    public async Task<IModel> CreateAsync(IModel entity)
    {
        await DbSet.AddAsync(_mapper.Map<TEntity>(entity));        
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IModel> UpdateAsync(T id,IModel entity)
    {
        var data = await DbSet.FindAsync(id);
        if(data != null)
        {
            DbSet.Update(_mapper.Map<TEntity>(entity));
            await _context.SaveChangesAsync();
        }

        return entity;
    }

    public async Task<IModel> DeleteAsync(T id)
    {
        var data = await DbSet.FindAsync(id);
        DbSet.Remove(data);
        await _context.SaveChangesAsync();
        return _mapper.Map<IModel>(data);
    }
}
