using Common.EntityFrameworkServices;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevOps.Primitives.Strings.EntityFramework.Services
{
    public class UnicodeMaxStringReferenceUpsertService<TDbContext> : UpsertService<TDbContext, UnicodeMaxStringReference>
        where TDbContext : UniqueStringsDbContext
    {
        private readonly IMaxStringHashService<TDbContext> _hash;

        public UnicodeMaxStringReferenceUpsertService(ICacheService<UnicodeMaxStringReference> cache, TDbContext database, ILogger<UpsertService<TDbContext, UnicodeMaxStringReference>> logger, IMaxStringHashService<TDbContext> hash)
            : base(cache, database, logger, database.UnicodeMaxStringReferences)
        {
            CacheKey = record => $"StringReferences.{nameof(UnicodeMaxStringReference)}={record.HashId}";
            _hash = hash ?? throw new ArgumentNullException(nameof(hash));
        }

        protected override async Task<UnicodeMaxStringReference> AssignUpsertedReferences(UnicodeMaxStringReference record)
            => (await _hash.UpsertComputedHash(record)) as UnicodeMaxStringReference;

        protected override Expression<Func<UnicodeMaxStringReference, bool>> FindExisting(UnicodeMaxStringReference record)
            => existing => existing.Hash == record.Hash;
    }
}
