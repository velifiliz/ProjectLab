using Microsoft.EntityFrameworkCore;

namespace ProjectLab.WebUI.Infrastructures;

public class AppDataContext : DbContext
{
    public AppDataContext() : base() { }

    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlServer("");
        }
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        foreach (var item in ChangeTracker.Entries())
        {
            if (item.Entity is BaseEntity entity)
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        Entry(entity).Property(x=> x.CreatedDate).IsModified = false;
                        entity.UpdatedDate = DateTime.Now;
                        break;

                }
            }
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {

        base.ConfigureConventions(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Person>().HasQueryFilter(x=> !x.IsDeleted);
        base.OnModelCreating(builder);
    }

}
