using System.Linq;
using System.Threading.Tasks;
using Zeux.Test.Models;

namespace Zeux.Test.Repositories
{
    public class AssetRepository: IAssetRepository
    {
        private readonly FakeContext _context = new FakeContext();

        public IQueryable<Asset> Get()
        {
            return _context.Assets;
        }

        public async Task<IQueryable<AssetType>> GetTypes()
        {
            return await Task.Run(() => _context.AssetTypes);
        }
    }
}
