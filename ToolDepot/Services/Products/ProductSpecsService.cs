using ToolDepot.Core.Domain.Products;
using ToolDepot.Data;

namespace ToolDepot.Services.Products
{
    public class ProductSpecsService : CrudService<ProductSpecs>, IProductSpecsService
    {
        public ProductSpecsService(IRepository<ProductSpecs> repo)
            : base(repo)
        {
        }
        
      
    }
}