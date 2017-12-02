using System.Threading.Tasks;

namespace DevOps.Primitives.Strings.EntityFramework.Services
{
    public interface IMaxStringHashService<TDbContext>
        where TDbContext : UniqueStringsDbContext
    {
        Task<IMaxStringReference> UpsertComputedHash(IMaxStringReference record);
    }
}
