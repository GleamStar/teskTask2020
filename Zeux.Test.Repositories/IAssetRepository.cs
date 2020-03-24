using System.Linq;
using System.Threading.Tasks;
using Zeux.Test.Models;

namespace Zeux.Test.Repositories
{
    public interface IAssetRepository
    {
        IQueryable<Asset> Get();
        Task<IQueryable<AssetType>> GetTypes();
    }
}