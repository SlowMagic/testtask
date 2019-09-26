using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Zeux.Test.Models;

namespace Zeux.Test.Repositories
{
    public class AssetRepository: IAssetRepository
    {
        private readonly FakeContext _context = new FakeContext();

        public async Task<IQueryable<Asset>> Get()
        {
            return await Task.Run(() => _context.Assets);
        }

        public async Task<IQueryable<Asset>> Get(string type)
        {
            return await Task.Run(() => _context.Assets.Where(row => row.Type.Name.ToLower() == type.ToLower()));
        }     
        public async Task<IQueryable<AssetType>> GetTypes()
        {
            return await Task.Run(() => _context.AssetTypes);
        }

        public async Task<IList<Asset>> GetAllOrderedBy<T>(Expression<Func<Asset, T>> orderBy)
        {
            return await Task.Run(() => _context.Assets.OrderBy(orderBy).ToList());
        }
        public async Task<IList<Asset>> GetAllWithPredicateOrderedBy<T>(Expression<Func<Asset, bool>> predicate, Expression<Func<Asset, T>> orderBy)
        {
            return await Task.Run(() => _context.Assets.Where(predicate).OrderBy(orderBy).ToList());
        }
    }
}