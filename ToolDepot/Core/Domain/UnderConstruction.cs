using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolDepot.Core.Domain
{
    [Table("UnderConstruction")]
    public class UnderConstruction : BaseEntity
    {

        public UnderConstruction()
        {
            CreatedDate = DateTime.UtcNow;
        }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}