using System.Data.Entity.ModelConfiguration;
using ToolDepot.Core.Domain.Email;

namespace ToolDepot.Data.Mapping.Email
{
    public partial class EmailTemplatesMap : EntityTypeConfiguration<EmailTemplates>
    {
        public EmailTemplatesMap()
        {
            this.ToTable("EmailTemplates");
            this.HasKey(mt => mt.Id);

            this.Property(mt => mt.Name).IsRequired().HasMaxLength(200);
            this.Property(mt => mt.BccEmailAddresses).HasMaxLength(200);
            this.Property(mt => mt.Subject).HasMaxLength(1000);
            this.Property(mt => mt.Body).IsMaxLength();
            this.Property(mt => mt.EmailAccountId).IsRequired();
        }
    }
}