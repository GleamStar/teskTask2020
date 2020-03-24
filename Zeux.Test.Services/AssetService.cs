using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zeux.Test.Models;
using Zeux.Test.Repositories;

namespace Zeux.Test.Services
{
    public class AssetService: IAssetService
    {
        private readonly IAssetRepository _repository;

        public AssetService(IAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Asset>> Get(string type)
        {
            var assets = _repository.Get();

            if (!string.IsNullOrWhiteSpace(type) && type.ToLower() != "all")
            {
                assets = assets.Where(row => row.Type.Name.ToLower() == type.ToLower());
            }
            
            assets = assets.OrderBy(a => a.Name);
            
            return await Task.Run(() => assets.ToList());
        }

        public async Task<IEnumerable<AssetType>> GetTypes()
        {
            return await _repository.GetTypes();
        }
    }
}
