using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace ProjectLab.WebUI.Infrastructures;

public interface IAppDataServiceAsync
{
    Task<bool> AddOrUpdateAsync<T>(T entity, CancellationToken cancellationToken = default) where T : BaseEntity;
    Task<List<T>> FindBylAsync<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) where T : BaseEntity;
    Task<List<T>> GetAllAsync<T>(CancellationToken cancellationToken = default) where T : BaseEntity;
    Task<T> GetByIdAsync<T>(int Id, CancellationToken cancellationToken = default) where T : BaseEntity;
    Task<bool> RemoveAsync<T>(T entity, bool Deleted = false, CancellationToken cancellationToken = default) where T : BaseEntity;
}

public class AppDataServiceAsync(AppDataContext context) : IAppDataServiceAsync
{
    private DbSet<T> DbSet<T>() where T : BaseEntity => context.Set<T>();

    public async Task<T> GetByIdAsync<T>(int Id, CancellationToken cancellationToken = default) where T : BaseEntity
    {
        return await DbSet<T>().FirstOrDefaultAsync<T>(x => x.Id == Id, cancellationToken);
    }

    public async Task<List<T>> GetAllAsync<T>(CancellationToken cancellationToken = default) where T : BaseEntity
    {
        return await DbSet<T>().ToListAsync(cancellationToken);
    }

    public async Task<List<T>> FindBylAsync<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) where T : BaseEntity
    {
        return await DbSet<T>().Where(expression).ToListAsync(cancellationToken);
    }

    public async Task<bool> AddOrUpdateAsync<T>(T entity, CancellationToken cancellationToken = default) where T : BaseEntity
    {
        if (entity.Id > 0)
        {
            _ = DbSet<T>().Update(entity).State = EntityState.Modified;

        }
        else
        {
            _ = (await DbSet<T>().AddAsync(entity, cancellationToken)).State == EntityState.Added;
        }

        return await context.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> RemoveAsync<T>(T entity, bool Deleted = false, CancellationToken cancellationToken = default) where T : BaseEntity
    {
        if (Deleted)
        {
            _ = DbSet<T>().Remove(entity).State = EntityState.Deleted;

        }
        else
        {
            entity.IsDeleted = true;
            _ = DbSet<T>().Update(entity).State == EntityState.Modified;
        }

        return await context.SaveChangesAsync(cancellationToken) > 0;
    }
}
