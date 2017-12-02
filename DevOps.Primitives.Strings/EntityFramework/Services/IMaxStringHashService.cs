using System.Threading.Tasks;

namespace DevOps.Primitives.Strings.EntityFramework.Services
{
    public interface IMaxStringHashService
    {
        Task<IMaxStringReference> UpsertComputedHash(IMaxStringReference record);
    }
}
