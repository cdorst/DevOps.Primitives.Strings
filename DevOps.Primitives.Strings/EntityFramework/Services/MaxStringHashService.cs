using Common.EntityFrameworkServices.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Data.HashFunction.xxHash;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Primitives.Strings.EntityFramework.Services
{
    public class MaxStringHashService<TDbContext> : IMaxStringHashService<TDbContext>
        where TDbContext : UniqueStringsDbContext
    {
        private readonly ILogger<MaxStringHashService<TDbContext>> _logger;
        private readonly IUpsertService<TDbContext, AsciiStringReference> _strings;

        public MaxStringHashService(ILogger<MaxStringHashService<TDbContext>> logger, IUpsertService<TDbContext, AsciiStringReference> strings)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _strings = strings ?? throw new ArgumentNullException(nameof(strings));
        }

        public async Task<IMaxStringReference> UpsertComputedHash(IMaxStringReference record)
        {
            var hashString = xxHashFactory.Instance.Create().ComputeHash(Encoding.UTF8.GetBytes(record.Value)).AsBase64String();
            var hash = new AsciiStringReference { Value = hashString };
            hash = await _strings.UpsertAsync(hash);
            record.Hash = hash;
            record.HashId = hash.AsciiStringReferenceId;
            return record;
        }
    }
}
