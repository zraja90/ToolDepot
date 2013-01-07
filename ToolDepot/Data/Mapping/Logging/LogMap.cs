using System.Data.Entity.ModelConfiguration;
using ToolDepot.Core.Domain.Logging;

namespace ToolDepot.Data.Mapping.Logging
{
    public partial class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            this.ToTable("Log");
            this.HasKey(l => l.Id);
            this.Property(l => l.ShortMessage).IsRequired().IsMaxLength();
            this.Property(l => l.FullMessage).IsMaxLength();
            this.Property(l => l.IpAddress).HasMaxLength(200);
            this.Ignore(l => l.LogLevel);

        }
    }
}