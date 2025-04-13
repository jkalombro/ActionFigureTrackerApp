using ActionFigureTrackerApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ActionFigureTrackerApp.Infrastructure.Repositories
{
  public class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(DbContext context)
    {
      _context = context;
      _dbSet = _context.Set<T>();
    }

    public void Add(T entity) => _dbSet.Add(entity);

    public void AddRange(IList<T> entities) => _dbSet.AddRange(entities);

    public void Update(T entity) => _dbSet.Update(entity);

    public void UpdateRange(IList<T> entities) => _dbSet.UpdateRange(entities);

    public void Delete(T entity) => _dbSet.Remove(entity);

    public void DeleteRange(IList<T> entities) => _dbSet.RemoveRange(entities);

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task AddAsync(T entity)
    {
      _dbSet.Add(entity);
      await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
      _dbSet.AddRange(entities);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
      _dbSet.Update(entity);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(IList<T> entities)
    {
      _dbSet.UpdateRange(entities);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
      _dbSet.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(IList<T> entities)
    {
      _dbSet.RemoveRange(entities);
      await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
      await _context.SaveChangesAsync();
    }
  }
}
