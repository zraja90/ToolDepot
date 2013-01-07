using System.Web.Mvc;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Services.Products
{
    public interface IProductService : ICrudService<Product>
    {
        SelectList GetAllProductsSelectList(string selectedValue =null, string extraItem = null);
    }
}
