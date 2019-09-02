using policyInsurance.Data.Models.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace policyInsurance.Data.Models.Policy
{
    public class Policy
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Opening { get; set; }

        [Range(0, 100)]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Coverage { get; set; }

        public int TimeCoverage { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]

        public Decimal Price { get; set; }

        public virtual PolicyType Type { get; set; }

        public virtual PolicyRisk Risk { get; set; }

        public virtual AppIdentityUser User { get; set; }

        public virtual ICollection<PolicyClient> PolicyClients { get; set; }
    }
}
