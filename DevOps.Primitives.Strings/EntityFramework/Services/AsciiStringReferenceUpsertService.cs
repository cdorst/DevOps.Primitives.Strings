using Common.EntityFrameworkServices.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;

namespace DevOps.Primitives.Strings.EntityFramework.Services
{
    public class AsciiStringReferenceUpsertService<TDbContext> : UpsertService<TDbContext, AsciiStringReference>
        where TDbContext : UniqueStringsDbContext
    {
        public AsciiStringReferenceUpsertService(ICacheService<AsciiStringReference> cache, TDbContext database, ILogger<UpsertService<TDbContext, AsciiStringReference>> logger)
            : base(cache, database, logger, database.AsciiStringReferences)
        {
            CacheKey = record => $"StringReferences.{nameof(AsciiStringReference)}={record.Value}";
        }

        protected override Expression<Func<AsciiStringReference, bool>> FindExisting(AsciiStringReference record)
            => existing => existing.Value == record.Value;
    }
}
