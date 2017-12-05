using Common.EntityFrameworkServices;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;

namespace DevOps.Primitives.Strings.EntityFramework.Services
{
    public class UnicodeStringReferenceUpsertService<TDbContext> : UpsertService<TDbContext, UnicodeStringReference>
        where TDbContext : UniqueStringsDbContext
    {
        public UnicodeStringReferenceUpsertService(ICacheService<UnicodeStringReference> cache, TDbContext database, ILogger<UpsertService<TDbContext, UnicodeStringReference>> logger)
            : base(cache, database, logger, database.UnicodeStringReferences)
        {
            CacheKey = record => $"StringReferences.{nameof(UnicodeStringReference)}={record.Value}";
        }

        protected override Expression<Func<UnicodeStringReference, bool>> FindExisting(UnicodeStringReference record)
            => existing => existing.Value == record.Value;
    }
}
