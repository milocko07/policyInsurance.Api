﻿using policyInsurance.Data.Models.Clients;
using policyInsurance.Data.Models.Policy;
using policyInsurance.Data.Models.Security;
using System.Threading.Tasks;

namespace policyInsurance.Data.Repositories
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppIdentityDbContext _identityContext;

        private GenericRepository<AppIdentityUser> _identityUserRepository;
        private GenericRepository<AppIdentityRole> _identityRoleRepository;
        private GenericRepository<AppIdentityUserRoles> _identityUserRolesRepository;
        private GenericRepository<Policy> _policyRepository;
        private GenericRepository<PolicyType> _policyTypeRepository;
        private GenericRepository<PolicyRisk> _policyRiskRepository;
        private GenericRepository<Client> _clientRepository;
        private GenericRepository<PolicyClient> _policyClientRepository;

        public UnitOfWork(AppIdentityDbContext _context)
        {
            _identityContext = _context;
        }

        public GenericRepository<AppIdentityUser> IdentityUserRepository
        {
            get
            {
                return _identityUserRepository = _identityUserRepository ?? new GenericRepository<AppIdentityUser>(_identityContext);
            }
        }

        public GenericRepository<AppIdentityRole> IdentityRoleRepository
        {
            get
            {
                return _identityRoleRepository = _identityRoleRepository ?? new GenericRepository<AppIdentityRole>(_identityContext);
            }
        }

        public GenericRepository<AppIdentityUserRoles> IdentityUserRolesRepository
        {
            get
            {
                return _identityUserRolesRepository = _identityUserRolesRepository ?? new GenericRepository<AppIdentityUserRoles>(_identityContext);
            }
        }

        public GenericRepository<Policy> PolicyRepository
        {
            get
            {
                return _policyRepository = _policyRepository ?? new GenericRepository<Policy>(_identityContext);
            }
        }

        public GenericRepository<PolicyType> PolicyTypeRepository
        {
            get
            {
                return _policyTypeRepository = _policyTypeRepository ?? new GenericRepository<PolicyType>(_identityContext);
            }
        }

        public GenericRepository<PolicyRisk> PolicyRiskRepository
        {
            get
            {
                return _policyRiskRepository = _policyRiskRepository ?? new GenericRepository<PolicyRisk>(_identityContext);
            }
        }

        public GenericRepository<Client> ClientRepository
        {
            get
            {
                return _clientRepository = _clientRepository ?? new GenericRepository<Client>(_identityContext);
            }
        }

        public GenericRepository<PolicyClient> PolicyClientRepository
        {
            get
            {
                return _policyClientRepository = _policyClientRepository ?? new GenericRepository<PolicyClient>(_identityContext);
            }
        }

        public void Save()
        {
            _identityContext.SaveChanges();
        }

        public Task SaveAsync()
        {
            return _identityContext.SaveChangesAsync();
        }
    }
}
