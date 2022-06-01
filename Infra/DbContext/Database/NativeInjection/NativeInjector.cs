using Database.Data;
using Database.Entities;
using Database.Interfaces;
using Database.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NativeInjection;
public class NativeInjector
{
    public static void InjectServices(IServiceCollection services)
    {
        services.AddScoped<IUser, AspNetUser>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();

        services.AddDbContext<ExpanseContext>(options =>
        {
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
        services.AddTransient<IAppDbContext, ExpanseContext>();
    }
}

