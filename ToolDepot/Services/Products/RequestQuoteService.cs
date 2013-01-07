using ToolDepot.Core.Domain.Products;
using ToolDepot.Data;
using ToolDepot.Models;

namespace ToolDepot.Services.Products
{
    public class RequestQuoteService : CrudService<RequestAQuote>, IRequestQuoteService 
    {
        public RequestQuoteService(IRepository<RequestAQuote> repo) : base(repo)
        {
        }
    }
}