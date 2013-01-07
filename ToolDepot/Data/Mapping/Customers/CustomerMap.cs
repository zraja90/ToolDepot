using System.Data.Entity.ModelConfiguration;
using ToolDepot.Core.Domain.Customers;

namespace ToolDepot.Data.Mapping.Customers
{
    public partial class CustomerMap : EntityTypeConfiguration<Customer>
    {

        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UserName)
                .HasMaxLength(128);

            this.Property(t => t.Email)
                .HasMaxLength(128);

            this.Property(t => t.FirstName)
                .HasMaxLength(128);

            this.Property(t => t.LastName)
                .HasMaxLength(128);

            this.Property(t => t.ConfirmationToken)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Customer");

            // Relationships
            this.HasMany(t => t.CustomerRoles)
                .WithMany(t => t.Customers)
                .Map(m =>
                {
                    m.ToTable("Customer_CustomerRole_Mapping");
                    m.MapLeftKey("Customer_Id");
                    m.MapRightKey("CustomerRole_Id");
                });
        }
    }
}
