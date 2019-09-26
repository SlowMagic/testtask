using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Zeux.Test.Models;

namespace Zeux.Test.Repositories
{
    public interface IAssetRepository
    {
        Task<IQueryable<Asset>> Get();
        Task<IQueryable<Asset>> Get(string type);
        Task<IList<Asset>> GetAllOrderedBy<T>(Expression<Func<Asset, T>> orderBy);
        Task<IList<Asset>> GetAllWithPredicateOrderedBy<T>(Expression<Func<Asset, bool>> predicate, Expression<Func<Asset, T>> orderBy);
        Task<IQueryable<AssetType>> GetTypes();      
    }
}