using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Database.Data;
public class ExpanseContext : DbContext
{
    public DbSet<Transaction> transactions { get; set; }


    public ExpanseContext(DbContextOptions<ExpanseContext> options) : base(options)
    {
    }


}

public class ExpanseContextFactory : IDesignTimeDbContextFactory<ExpanseContext>
{
    public ExpanseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ExpanseContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=finnances_api;User Id=guilhermebernava;Password=123456;");
        return new ExpanseContext(optionsBuilder.Options);
    }
}



