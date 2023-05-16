using Microsoft.EntityFrameworkCore;

namespace BizSol_Task.Data;

public class BizSolDbContext : DbContext
{
    public BizSolDbContext(DbContextOptions options)
        : base(options)
    {

    }
}
