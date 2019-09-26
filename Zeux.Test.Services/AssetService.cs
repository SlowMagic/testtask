using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zeux.Test.Models;
using Zeux.Test.Repositories;
using Zeux.Test.Services.ViewModel;

namespace Zeux.Test.Services
{
    public class AssetService: IAssetService
    {
        private readonly IAssetRepository _repository;
        private const string APPLE = "apple";
        private const string BANANA = "banana";
        private const string ORANGE = "orange";


        public AssetService(IAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Asset>> Get()
        {
            return await _repository.GetAllOrderedBy(x => x.Name);
        }

        public async Task<IEnumerable<Asset>> Get(string type)
        {
            return await _repository.GetAllWithPredicateOrderedBy(x=>x.Type.Name.ToLower() == type.ToLower(),x=>x.Name);
        } 

        public async Task<IEnumerable<AssetType>> GetTypes()
        {
            return await _repository.GetTypes();
        }

        public async Task<List<AssetViewModel>> GetOrderedAssets()
        {
            var assets = await _repository.GetAllOrderedBy(x => x.Name);
            //TODO : ADD Automapper
            var result = new List<AssetViewModel>();
            foreach(var asset in assets)
            {
                result.Add(new AssetViewModel() { Name = asset.Name, Percent = asset.Percent, Sum = asset.Sum, TypeName = asset.Type.Name });
            }

            return ChangeRandomAssetsName(result);
        }

        private List<AssetViewModel> ChangeRandomAssetsName(List<AssetViewModel> assets)
        {
            var sequence = Enumerable.Range(0,assets.Count).OrderBy(n => n * n * (new Random()).Next());

            var result = sequence.Distinct().Take(3).ToArray();

            assets[result[0]].Name = APPLE;
            assets[result[1]].Name = BANANA;
            assets[result[2]].Name = ORANGE;

            return assets.OrderBy(x=>x.Name).ToList();
        }
    }
}
