using System;
using System.Linq;
using PagedList;
using ToolDepot.Core.Domain.Email;
using ToolDepot.Data;

namespace ToolDepot.Services.Email
{
    public partial class QueuedEmailService : CrudService<QueuedEmail>, IQueuedEmailService
    {
        private readonly IRepository<QueuedEmail> _queuedEmailRepository;
        

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="queuedEmailRepository">Queued email repository</param>
        public QueuedEmailService(IRepository<QueuedEmail> queuedEmailRepository)
            : base(queuedEmailRepository)
        {
            _queuedEmailRepository = queuedEmailRepository;
        }

        /// <summary>
        /// Gets all queued emails
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
        /// <returns>Email item list</returns>
        public virtual IPagedList<QueuedEmail> SearchEmails(string fromEmail, 
            string toEmail, DateTime? startTime, DateTime? endTime, 
            bool loadNotSentItemsOnly, int maxSendTries,
            bool loadNewest, int pageIndex, int pageSize)
        {
            fromEmail = (fromEmail ?? String.Empty).Trim();
            toEmail = (toEmail ?? String.Empty).Trim();
            
            var query = _queuedEmailRepository.Table;
            if (!String.IsNullOrEmpty(fromEmail))
                query = query.Where(qe => qe.From.Contains(fromEmail));
            if (!String.IsNullOrEmpty(toEmail))
                query = query.Where(qe => qe.To.Contains(toEmail));
            if (startTime.HasValue)
                query = query.Where(qe => qe.CreatedOnUtc >= startTime);
            if (endTime.HasValue)
                query = query.Where(qe => qe.CreatedOnUtc <= endTime);
            if (loadNotSentItemsOnly)
                query = query.Where(qe => !qe.SentOnUtc.HasValue);
            query = query.Where(qe => qe.SentTries < maxSendTries);
            query = query.OrderByDescending(qe => qe.Priority);
            query = loadNewest ? 
                ((IOrderedQueryable<QueuedEmail>)query).ThenByDescending(qe => qe.CreatedOnUtc) :
                ((IOrderedQueryable<QueuedEmail>)query).ThenBy(qe => qe.CreatedOnUtc);

            var queuedEmails = new PagedList<QueuedEmail>(query, pageIndex, pageSize);
            return queuedEmails;
        }

        public bool EmailSendStatus(int id)
        {
            return _queuedEmailRepository.Table.Any(x=>x.Id==id && x.SentOnUtc.HasValue);
        }
    }
}
