using System;
using System.Collections.Generic;
using ToolDepot.Core.Domain.Email;

namespace ToolDepot.Services.Email
{
    public partial class WorkflowMessageService : IWorkflowMessageService
    {
        #region Fields

        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IQueuedEmailService _queuedEmailService;
        
        private readonly IEmailAccountService _emailAccountService;
        private readonly ITokenizer _tokenizer;
        
        #endregion

        #region Ctor

        public WorkflowMessageService(IEmailTemplateService emailTemplateService,
            IQueuedEmailService queuedEmailService, IEmailAccountService emailAccountService, ITokenizer tokenizer)
        {
            this._emailTemplateService = emailTemplateService;
            this._queuedEmailService = queuedEmailService;
            _tokenizer = tokenizer;
            this._emailAccountService = emailAccountService;
            
        }

        #endregion

     
        #region Email Methods

        public void SendContactEmail(string fromEmail, string name, string message)
        {
            var header = EmailHeader();
            var body = string.Format("Regarding: {0}",message);
            var emailBody = header.Replace("[Body]", body);
            
            
            string fromName = name;
            const int emailAccountId = 1;

            var email = new QueuedEmail()
            {
                Priority = 5,
                From = fromEmail,
                FromName = fromName,
                To = "zeeshan@unigo.com",
                EmailName = "Contact Email",
                ToName = "Contact",
                CC = string.Empty,
                Bcc = string.Empty,
                Subject = "Tool Depot Inquiry",
                Body = emailBody,
                CreatedOnUtc = DateTime.UtcNow,
                EmailAccountId = emailAccountId
            };

            _queuedEmailService.Add(email);
        }
       
        #endregion

        #region Utilities

        private int SendNotification(EmailTemplates messageTemplate, IEnumerable<Token> tokens, string toEmail, string toName)//, EmailAccount templateEmailAccount)
        {
            if (messageTemplate == null)
            {
                return 0;
            }
            var header = EmailHeader();

            var body = header.Replace("[Body]", messageTemplate.Body);
            var subject = messageTemplate.Subject;
            var bcc = messageTemplate.BccEmailAddresses;

            var subjectReplaced = _tokenizer.Replace(subject, tokens, false);
            var bodyReplaced = _tokenizer.Replace(body, tokens, true);
            string fromEmail = "do-not-reply@tooldepotinc.com";
            string fromName = "Tool Depot";
            int emailAccountId = 1;

            var email = new QueuedEmail()
            {
                Priority = 5,
                From = fromEmail,
                FromName = fromName,
                To = toEmail,
                EmailName = messageTemplate.Name,
                ToName = toName,
                CC = string.Empty,
                Bcc = bcc,
                Subject = subjectReplaced,
                Body = bodyReplaced,
                CreatedOnUtc = DateTime.UtcNow,
                EmailAccountId = emailAccountId
            };

            _queuedEmailService.Add(email);
            return email.Id;
        }

        private EmailTemplates GetLocalizedActiveMessageTemplate(int programId, string messageTemplateName)
        {
            var messageTemplate = _emailTemplateService.GetMessageTemplateByName(programId, messageTemplateName);

            if (messageTemplate == null)
                return null;


            //use
            var isActive = messageTemplate.IsActive;
            if (!isActive)
                return null;

            return messageTemplate;
        }

       
        #endregion


        #region Methods for Tokens

        public string[] GetAllTokensAllowed()
        {
            return GetListOfAllowedTokens();
        }

       
        public virtual string[] GetListOfAllowedTokens()
        {
            var allowedTokens = new List<string>()
            {
                //"%Program.Name%",
            };
            return allowedTokens.ToArray();
        }

        public virtual string EmailHeader()
        {
            var header = string.Format("<html><body bgcolor='#363636'><font face='Helvetica, Arial, sans-serif' style='font-family: Helvetica, Arial, sans-serif;'>" +
                                       "<table id='Table1' cellpadding='0' cellspacing='0' border='0' width='100%' bgcolor='#363636'>" +
                                       "<tr><td height='12'><center><table id='Table2' cellpadding='0' cellspacing='0' border='0' width='560'><tr>" +
                                       "<td height='12' colspan='3' style='padding: 5px 0 0;' valign='bottom' align='left' valign='top'>" +
                                       "<img src='http://nyu.ampwiz.com/Images/Email/EmailHeader.png' width='560' />" +
                                       "<img src='http://nyu.ampwiz.com/Images/Email/EmailFacePile.jpg' width='560' />" +
                                       "</td></tr></table></center></td></tr><tr><td><center><table id='body' cellpadding='0' cellspacing='0' border='0' width='560' bgcolor='#ffffff'>" +
                                       "<tr><td height='12' colspan='3' >&nbsp; </td> </tr><tr><td width='35'>&nbsp;</td> <td width='490'>" +
                                       "<table width='100%' cellpadding='0' cellspacing='0' border='0'><tr> <td>&nbsp;</td> " +
                                       "<td height='20' width='490' align='left' style='text-align: left; color: #363636; font-size: 12px; font-family: Helvetica, Arial, sans-serif;'>" +
                                       "&nbsp;  </td><td>&nbsp;</td> </tr><tr><td>&nbsp;</td> " +
                                       "<td height='30' width='490' align='center' style='text-align: left; color: #363636; font-size: 12px; font-family: Helvetica, Arial, sans-serif;'>" +
                                       "[Body]" +
                                       "</td> <td>&nbsp;</td> </tr> <tr> <td>&nbsp;</td>" +
                                       "<td height='20' width='490' align='left' style='text-align: left; color: #363636; font-size: 12px; font-family: Helvetica, Arial, sans-serif;'>" +
                                       "&nbsp;  </td><td>&nbsp;</td> </tr></table> </td> <td width='35'>&nbsp;</td> </tr> </table>" +
                                       "<table id='Table3' cellpadding='0' cellspacing='0' border='0' width='560'><tr><td height='10'><img src='http://nyu.ampwiz.com/Images/Email/EmailFooterBar.jpg' width='560' /></td></tr>" +
                                       "</table></center></td></tr><tr height='12'><td height='12'>&nbsp;</td></tr></table></font></body></html>");

            return header;
        }
        #endregion
    }
}
