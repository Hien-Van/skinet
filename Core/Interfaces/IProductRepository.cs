using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
         Task<Product> GetProductById(int id);
         Task<IReadOnlyList<Product>> GetProductsAsync();

        Task<IReadOnlyList<ProductBrand>> GetProductBrands();
        Task<IReadOnlyList<ProductType>> GetProductTypes();
    }
}