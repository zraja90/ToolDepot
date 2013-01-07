using System.Collections.Generic;
using ToolDepot.Core.Domain.Customers;

namespace ToolDepot.Core.Domain.Security
{
    /// <summary>
    /// Represents a permission record
    /// </summary>
    public class PermissionRecord : BaseEntity
    {
        private ICollection<CustomerRole> _customerRole;

        public PermissionRecord()
        {
        }
        /// <summary>
        /// Gets or sets the permission name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the permission system name
        /// </summary>
        public virtual string SystemName { get; set; }
        
        /// <summary>
        /// Gets or sets the permission category
        /// </summary>
        public virtual string Category { get; set; }
        
        /// <summary>
        /// Gets or sets discount usage history
        /// </summary>

        public virtual ICollection<CustomerRole> CustomerRoles
        {
            get { return _customerRole ?? (_customerRole = new List<CustomerRole>()); }
            protected set { _customerRole = value; }
        }

    }
}
