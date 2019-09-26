using System.Collections.Generic;
using System.Threading.Tasks;
using Zeux.Test.Models;
using Zeux.Test.Services.ViewModel;

namespace Zeux.Test.Services
{
    public interface IAssetService
    {
        Task<IEnumerable<Asset>> Get();
        Task<IEnumerable<Asset>> Get(string type);
        Task<IEnumerable<AssetType>> GetTypes();
        Task<List<AssetViewModel>> GetOrderedAssets();
    }
}