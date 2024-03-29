﻿using policyInsurance.Entities.ViewModels;
using System.Threading.Tasks;

namespace policyInsurance.Data.Access
{
    public interface IAccessPolicyCreation
    {
        Task<string> Create(PolicySelectionViewModel model);
    }
}
