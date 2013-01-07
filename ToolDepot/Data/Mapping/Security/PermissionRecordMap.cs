using System.Data.Entity.ModelConfiguration;
using ToolDepot.Core.Domain.Security;

namespace ToolDepot.Data.Mapping.Security
{
    public partial class PermissionRecordMap : EntityTypeConfiguration<PermissionRecord>
    {
        public PermissionRecordMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            this.Property(t => t.SystemName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Category)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("PermissionRecord");


            
        }
    }
}