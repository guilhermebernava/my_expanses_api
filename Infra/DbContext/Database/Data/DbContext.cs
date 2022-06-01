using Database.Entities;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Database.Data;
public interface IAppDbContext { }

public class ExpanseContext : IdentityDbContext<ApplicationUser, ApplicationRole, String>, IAppDbContext
{
    public DbSet<Transaction> transactions { get; set; }
    public DbSet<ApplicationUser> users{ get; set; }

    public ExpanseContext(DbContextOptions<ExpanseContext> options)
         : base(options)
    {
     }

}




