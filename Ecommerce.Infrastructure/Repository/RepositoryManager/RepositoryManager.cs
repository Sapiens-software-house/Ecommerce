using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.UserRepository;
using Ecommerce.Interface.IUserRepository;
using Ecommerce.Interface.Repository;
using Ecommerce.UI.Shared.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repository.RepositoryManager
{
    public class RepositoryManager : IRepositoryManager
    {
        private IUserIdentityRepository _userIdentityRepository;
        private UserManager<ApplicationUser> _user;
        private RoleManager<IdentityRole> _userRole;
        private IConfiguration _configuration;
        private ApplicationDataContext _context;
        public RepositoryManager(ApplicationDataContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> userRole, IConfiguration configuration) 
        {
            _context = context;
            _user = user;
            _userRole = userRole;
            _configuration = configuration;
        }

        public IUserIdentityRepository UserIdentityRepository
        {
            get
            {
                if (_userIdentityRepository is null)
                    _userIdentityRepository = new UserIdentityRepository(_user, _userRole, _configuration);
                return _userIdentityRepository;
            }
        }

    }
}
