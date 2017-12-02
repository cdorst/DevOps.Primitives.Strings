using Common.EntityFrameworkServices.Services;
using DevOps.Primitives.Strings.EntityFramework.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevOps.Primitives.Strings.EntityFramework
{
    public static class AddUniqueStringsServicesExtension
    {
        public static IServiceCollection AddUniqueStringsServices<TDbContext>(this IServiceCollection serviceCollection)
            where TDbContext : UniqueStringsDbContext
            => serviceCollection
                .AddGenericServices()
                .AddScoped<IMaxStringHashService<TDbContext>, MaxStringHashService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, AsciiMaxStringReference>, AsciiMaxStringReferenceUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, AsciiStringReference>, AsciiStringReferenceUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, UnicodeMaxStringReference>, UnicodeMaxStringReferenceUpsertService<TDbContext>>()
                .AddScoped<IUpsertService<TDbContext, UnicodeStringReference>, UnicodeStringReferenceUpsertService<TDbContext>>();
    }
}
