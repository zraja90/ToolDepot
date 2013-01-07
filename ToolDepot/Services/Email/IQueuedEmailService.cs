using System;
using PagedList;
using ToolDepot.Core.Domain.Email;

namespace ToolDepot.Services.Email
{
    public partial interface IQueuedEmailService : ICrudService<QueuedEmail>
    {
        /// <summary>
        /// Search queued emails
        /// </summary>
        /// <param name="fromEmail">From Email</param>
        /// <param name="toEmail">To Email</param>
        /// <param name="startTime">The start time</param>
        /// <param name="endTime">The end time</param>
        /// <param name="loadNotSentItemsOnly">A value indicating whether to load only not sent emails</param>
        /// <param name="maxSendTries">Maximum send tries</param>
        /// <param name="loadNewest">A value indicating whether we should sort queued email descending; otherwise, ascending.</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Email item collection</returns>
        IPagedList<QueuedEmail> SearchEmails(string fromEmail,
            string toEmail, DateTime? startTime, DateTime? endTime,
            bool loadNotSentItemsOnly, int maxSendTries,
            bool loadNewest, int pageIndex, int pageSize);

        bool EmailSendStatus(int id);
    }
}
