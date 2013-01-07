namespace ToolDepot.Core.Domain.Email
{
    /// <summary>
    /// Represents a message template
    /// </summary>
    public partial class EmailTemplates : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the BCC Email addresses
        /// </summary>
        public virtual string BccEmailAddresses { get; set; }

        /// <summary>
        /// Gets or sets the subject
        /// </summary>
        public virtual string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body
        /// </summary>
        public virtual string Body { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the template is active
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the used email account identifier
        /// </summary>
        public virtual int EmailAccountId { get; set; }

        public virtual int ProgramId { get; set; }

    }
}
