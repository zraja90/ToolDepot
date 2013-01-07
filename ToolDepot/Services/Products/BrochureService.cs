using ToolDepot.Core.Domain.Products;
using ToolDepot.Data;

namespace ToolDepot.Services.Products
{
    public class BrochureService: CrudService<Brochure>, IBrochureService
    {
        public BrochureService(IRepository<Brochure> repo) : base(repo)
        {
        }
    }
}