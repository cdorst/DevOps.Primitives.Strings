using Common.EntityFrameworkServices;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Primitives.Strings.EntityFramework.Services
{
    public class AsciiMaxStringReferenceUpsertService<TDbContext> : UpsertService<TDbContext, AsciiMaxStringReference>
        where TDbContext : UniqueStringsDbContext
    {
        private readonly IMaxStringHashService<TDbContext> _hash;

        public AsciiMaxStringReferenceUpsertService(ICacheService<AsciiMaxStringReference> cache, TDbContext database, ILogger<UpsertService<TDbContext, AsciiMaxStringReference>> logger, IMaxStringHashService<TDbContext> hash)
            : base(cache, database, logger, database.AsciiMaxStringReferences)
        {
            CacheKey = record => $"StringReferences.{nameof(AsciiMaxStringReference)}={record.HashId}";
            _hash = hash ?? throw new ArgumentNullException(nameof(hash));
        }

        protected override async Task<AsciiMaxStringReference> AssignUpsertedReferences(AsciiMaxStringReference record)
            => (await _hash.UpsertComputedHash(record)) as AsciiMaxStringReference;

        protected override Expression<Func<AsciiMaxStringReference, bool>> FindExisting(AsciiMaxStringReference record)
            => existing => existing.Hash == record.Hash;
    }
}
