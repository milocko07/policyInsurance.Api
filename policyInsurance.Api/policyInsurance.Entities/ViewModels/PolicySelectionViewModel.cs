using System;

namespace policyInsurance.Entities.ViewModels
{
    public class PolicySelectionViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Opening { get; set; }

        public decimal Coverage { get; set; }

        public int TimeCoverage { get; set; }

        public Decimal Price { get; set; }

        public int TypeId { get; set; }

        public string Type { get; set; }

        public int RiskId { get; set; }

        public string Risk { get; set; }
    }
}
