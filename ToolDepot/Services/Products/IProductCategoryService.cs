using System.Web.Mvc;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Services.Products
{
    public interface IProductCategoryService : ICrudService<ProductCategory>
    {
        SelectList GetProductCategorySelectList(string selectedValue = null, string extraItem = null);
    }
}
