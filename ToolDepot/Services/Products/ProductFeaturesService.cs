using ToolDepot.Core.Domain.Products;
using ToolDepot.Data;

namespace ToolDepot.Services.Products
{
    public class ProductFeaturesService : CrudService<ProductFeatures>, IProductFeaturesService
    {
        public ProductFeaturesService(IRepository<ProductFeatures> repo)
            : base(repo)
        {
        }


    }
}