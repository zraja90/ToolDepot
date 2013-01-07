using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolDepot.Core.Domain.Products
{
    public class RepairAppt : BaseEntity
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string ToolName { get; set; }
        public string RepairDescription { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ScheduledTime { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}