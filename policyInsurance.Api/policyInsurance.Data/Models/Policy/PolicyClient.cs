﻿using ClientAlias = policyInsurance.Data.Models.Client;

namespace policyInsurance.Data.Models.Policy
{
    public class PolicyClient
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public Policy Policy { get; set; }
        public int ClientId { get; set; }
        public ClientAlias.Client Client { get; set; }
    }
}