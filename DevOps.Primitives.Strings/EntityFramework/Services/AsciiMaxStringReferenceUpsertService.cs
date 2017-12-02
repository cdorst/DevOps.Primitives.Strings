using Common.EntityFrameworkServices.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Data.HashFunction.xxHash;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Primitives.Strings.EntityFramework.Services
{
    public class AsciiMaxStringReferenceUpsertService<TDbContext> : UpsertService<TDbContext, AsciiMaxStringReference>
        where TDbContext : UniqueStringsDbContext
    {
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public AsciiMaxStringReferenceUpsertService(ICacheService<AsciiMaxStringReference> cache, TDbContext database, ILogger<UpsertService<TDbContext, AsciiMaxStringReference>> logger, IUpsertService<TDbContext, AsciiStringReference> strings)
            : base(cache, database, logger, database.AsciiMaxStringReferences)
        {
            CacheKey = record => $"StringReferences.{nameof(AsciiMaxStringReference)}={record.HashId}";
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        protected override async Task<AsciiMaxStringReference> AssignUpsertedReferences(AsciiMaxStringReference record)
        {
            var hashString = xxHashFactory.Instance.Create().ComputeHash(Encoding.UTF8.GetBytes(record.Value)).AsBase64String();
            var hash = new AsciiStringReference { Value = hashString };
            hash = await _strings.UpsertAsync(hash);
            record.Hash = hash;
            record.HashId = hash.AsciiStringReferenceId;
            return record;
        }

        protected override Expression<Func<AsciiMaxStringReference, bool>> FindExisting(AsciiMaxStringReference record)
            => existing => existing.Hash == record.Hash;
    }
}
