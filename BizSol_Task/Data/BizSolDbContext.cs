using BizSol_Task.Entitties;
using Microsoft.EntityFrameworkCore;

namespace BizSol_Task.Data;

public class BizSolDbContext : DbContext
{
    public BizSolDbContext(DbContextOptions options)
        : base(options)
    {

    }
    public DbSet<User> Users { get; set; }
}
