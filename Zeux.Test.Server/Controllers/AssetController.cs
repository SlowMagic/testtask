using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zeux.Test.Models;
using Zeux.Test.Services;

namespace Zeux.Test.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AssetController : Controller
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet("[action]/{type}")]
        public async Task<IEnumerable<Asset>> Get(string type)
        {
            IEnumerable<Asset> result;
            if (string.IsNullOrWhiteSpace(type) || type.ToLower() == "all")
            {
                result = await _assetService.Get();
            }
            else
            {
                result = await _assetService.Get(type);
            }

            return result;
        }


        [HttpGet("products")]
        public async Task<IActionResult> Get()
        {
            var result = await _assetService.GetOrderedAssets();

            return Json(result);
        }


        [HttpGet("[action]")]
        public async Task<IEnumerable<AssetType>> GetTypes()
        {
            return await _assetService.GetTypes();
        }
    }
}
