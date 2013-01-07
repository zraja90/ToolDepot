using System;
using System.Linq;
using System.Web.Mvc;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Data;

namespace ToolDepot.Services.Products
{
    public class ProductCategoryService : CrudService<ProductCategory>, IProductCategoryService
    {
        public ProductCategoryService(IRepository<ProductCategory> repo)
            : base(repo)
        {

        }
        public SelectList GetProductCategorySelectList(string selectedValue, string extraItem = null)
        {
            var list = GetAll().ToList();

            if (!string.IsNullOrEmpty(extraItem))
            {
                var categoryField = new ProductCategory
                    {
                        Id = 0,
                        CategoryName = extraItem
                    };
                list.Insert(0, categoryField);
            }
            var selectedIndex = 0;
            if (!string.IsNullOrEmpty(selectedValue))
            {
                selectedIndex = list.FindIndex(x => Convert.ToString(x.Id) == selectedValue);
            }

            var selectList = new SelectList(list, "Id", "CategoryName", selectedIndex);

            return selectList;
        }
    }
}