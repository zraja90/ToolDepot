using ToolDepot.Core.Domain.Email;
using ToolDepot.Data;

namespace ToolDepot.Services.Email
{
    public partial class EmailAccountService : CrudService<EmailAccount>, IEmailAccountService
    {
        public EmailAccountService(IRepository<EmailAccount> repo) : base(repo)
        {
        }


    }
}
