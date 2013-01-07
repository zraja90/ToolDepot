using System.Collections.Generic;
using ToolDepot.Core.Domain.Email;

namespace ToolDepot.Services.Email
{
    public partial interface IEmailTemplateService : ICrudService<EmailTemplates>
    {
        EmailTemplates GetMessageTemplateByName(int programId, string messageTemplateName);
        IList<EmailTemplates> GetAllMessageTemplates(int programId);

        void InitSettings(int programId);
        
    }
}
