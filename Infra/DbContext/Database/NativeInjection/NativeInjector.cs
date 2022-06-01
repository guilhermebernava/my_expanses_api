using Database.Interfaces;
using Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace NativeInjection;
public class NativeInjector
{
    public static void InjectServices(IServiceCollection services)
    {
        services.AddScoped<ITransactionRepository, TransactionRepository>();
    }
}

