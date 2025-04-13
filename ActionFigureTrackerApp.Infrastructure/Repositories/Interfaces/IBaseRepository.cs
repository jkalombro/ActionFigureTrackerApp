namespace ActionFigureTrackerApp.Infrastructure.Repositories
{
  public interface IBaseRepository<T> where T : class
  {
    void Add(T entity);
    void AddRange(IList<T> entities);
    void Update(T entity);
    void UpdateRange(IList<T> entities);
    void Delete(T entity);
    void DeleteRange(IList<T> entities);

    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task AddRangeAsync(IList<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(IList<T> entities);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(IList<T> entities);
    Task SaveChangesAsync();
  }
}
