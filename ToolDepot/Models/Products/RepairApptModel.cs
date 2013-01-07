using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace ToolDepot.Models.Products
{
    public class RepairApptModel
    {
        public RepairApptModel()
        {
            CreatedDate = DateTime.UtcNow;
        }

        [Required]
        [DisplayName("Your Name")]
        public string Name { get; set; }
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [DisplayName("What tool needs repairing?")]
        public string ToolName { get; set; }
        [Required]
        [DisplayName("Describe the problem")]
        public string RepairDescription { get; set; }

        public DateTime ScheduledTime { get; set; }
       
        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }

        
        public SelectList Times { get; set; }
        public string ScheduledTimes { get; set; }
         
        [Required]
        [DisplayName("When would you like to come in?")]
        public SelectList Dates { get; set; }
        public string ScheduledDate { get; set; }
    }
}