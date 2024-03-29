﻿using System;
using System.Diagnostics;
using System.Linq;
using ToolDepot.Services.Logging;
using ToolDepot.Services.Tasks;



namespace ToolDepot.Services.Email
{
    /// <summary>
    /// Represents a task for sending queued message 
    /// </summary>
    public partial class QueuedMessagesSendTask : ITask
    {
        private readonly IQueuedEmailService _queuedEmailService;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public QueuedMessagesSendTask(IQueuedEmailService queuedEmailService,
            IEmailSender emailSender, ILogger logger)
        {
            this._queuedEmailService = queuedEmailService;
            this._emailSender = emailSender;
            this._logger = logger;
        }
        /// <summary>
        /// Executes a task
        /// </summary>
        public void Execute()
        {
            var maxTries = 3;
            var queuedEmails = _queuedEmailService.SearchEmails(null, null, null, null,
                true, maxTries, false, 1, 1000).ToList();

            Debug.WriteLine(string.Format("run time:{0}", DateTime.Now));
            foreach (var queuedEmail in queuedEmails)
            {
                var bcc = String.IsNullOrWhiteSpace(queuedEmail.Bcc) 
                            ? null 
                            : queuedEmail.Bcc.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var cc = String.IsNullOrWhiteSpace(queuedEmail.CC) 
                            ? null 
                            : queuedEmail.CC.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);


                if (_queuedEmailService.EmailSendStatus(queuedEmail.Id))
                    continue;
                try
                {
                    #if DEBUG 
                    #else
                   #endif

                    Debug.WriteLine(string.Format("before send: {0}:{1}:{2}:{3})",queuedEmail.Id,queuedEmail.CreatedOnUtc,queuedEmail.SentTries,DateTime.Now));
                    _emailSender.SendEmail(queuedEmail.EmailAccount, queuedEmail.Subject, queuedEmail.Body,
                        queuedEmail.From, queuedEmail.FromName, queuedEmail.To, queuedEmail.ToName, bcc, cc);
                    Debug.WriteLine(string.Format("after send: {0}:{1}:{2}:{3})", queuedEmail.Id, queuedEmail.CreatedOnUtc, queuedEmail.SentTries, DateTime.Now));
                    queuedEmail.SentOnUtc = DateTime.UtcNow;
                }
                catch (Exception exc)
                {
                    _logger.Error(string.Format("Error sending e-mail. {0}", exc.Message), exc);
                }
                finally
                {
                    queuedEmail.SentTries = queuedEmail.SentTries + 1;
                    _queuedEmailService.Update(queuedEmail);

                }
            }
        }
    }
}
