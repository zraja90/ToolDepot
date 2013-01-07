using System.Collections.Generic;
using ToolDepot.Core.Domain.Security;

namespace ToolDepot.Core.Domain.Customers
{
    public class CustomerRole : BaseEntity
    {
        private ICollection<PermissionRecord> _permissionRecords;
        private ICollection<Customer> _customers;

        /// <summary>
        /// Gets or sets the customer role name
        /// </summary>

        public CustomerRole()
        {
        }

        public string Name { get; set; }
        public bool Active { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether the customer role is system
        /// </summary>
        public bool IsSystemRole { get; set; }

        /// <summary>
        /// Gets or sets the customer role system name
        /// </summary>
        public string SystemName { get; set; }


        public bool IsGlobal { get; set; }

        public virtual ICollection<Customer> Customers
        {
            get { return _customers ?? (_customers = new List<Customer>()); }
            protected set { _customers = value; }
        }

        public virtual ICollection<PermissionRecord> PermissionRecords
        {
            get { return _permissionRecords ?? (_permissionRecords = new List<PermissionRecord>()); }
            protected set { _permissionRecords = value; }
        }
    }
}
