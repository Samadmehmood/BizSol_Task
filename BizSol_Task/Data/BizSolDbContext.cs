using BizSol_Task.Entitties;
using Microsoft.EntityFrameworkCore;

namespace BizSol_Task.Data;

public class BizSolDbContext : DbContext
{
    public BizSolDbContext()
    {
        ChangeTracker.QueryTrackingBehavior =
        QueryTrackingBehavior.NoTracking;
        this.ChangeTracker.LazyLoadingEnabled = false;
    }
    public BizSolDbContext(DbContextOptions options)
        : base(options)
    {
        ChangeTracker.QueryTrackingBehavior =
        QueryTrackingBehavior.NoTracking;
        this.ChangeTracker.LazyLoadingEnabled = false;
    }
    public DbSet<User> Users { get; set; }
}
