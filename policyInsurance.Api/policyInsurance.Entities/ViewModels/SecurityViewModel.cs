﻿using System.Collections.Generic;

namespace policyInsurance.Entities.ViewModels
{
    public class SecurityViewModel
    {
        public string UserName { get; set; }

        public string RoleName { get; set; }

        public string Token { get; set; }
        public IEnumerable<MenuViewModel> MenuList { get; set; }
    }
}
