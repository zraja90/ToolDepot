using System;
using System.Linq;
using System.Web.Mvc;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Data;

namespace ToolDepot.Services.Products
{
    public class ProductService : CrudService<Product>, IProductService
    {
        public ProductService(IRepository<Product> repo)
            : base(repo)
        {
        }


        public SelectList GetAllProductsSelectList(string selectedValue = null, string extraItem = null)
        {
            var list = GetAll().OrderBy(x => x.Name).ToList();
            
            if (!string.IsNullOrEmpty(extraItem))
            {
                var productField = new Product
                                       {
                                           Id = 0,
                                           Name = extraItem
                                       };
                list.Insert(0, productField);
            }
            var selectedIndex = 0;
            if (!string.IsNullOrEmpty(selectedValue))
            {
                selectedIndex = list.FindIndex(x => Convert.ToString(x.Id) == selectedValue);
            }
            var selectList = new SelectList(list, "Id", "Name", selectedIndex);

            return selectList;
        }
    }
}