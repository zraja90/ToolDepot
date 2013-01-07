namespace ToolDepot.Services.Email
{
    public partial interface IWorkflowMessageService
    {
        

        //int SendMeetingsNotification(Meeting meeting, string emailTemplateName, string toEmail);
        
        string[] GetAllTokensAllowed();
        
        //int SendEmailNotification(Customer customer, string emailName, string newPassword="");
        //bool SendAdminNotification(Customer customer, string emailTemplateName, int programId);
        void SendContactEmail(string fromEmail, string name, string message);
    }
}
