using Ecommerce.Infrastructure.Repository.RepositoryManager;
using Ecommerce.Interface.IUserService;
using Ecommerce.Interface.Repository;
using Ecommerce.UI.Shared.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.UserService
{
    public class RegisterUserService : IRegisterUserService
    {
        private IRepositoryManager _repository;
        public RegisterUserService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<IdentityResult> RegisterUser(ApplicationUser applicationUser)
        {
            var userResult = await _repository.UserIdentityRepository.RegisterUserAsync(applicationUser);
            return userResult;
        }

        public async Task<ResponseIdentity> Login(ApplicationUserLogin applicationUser)
        {
            var userResult = await _repository.UserIdentityRepository.Login(applicationUser);
            return userResult;
        }

        public async Task<IdentityResult> RegisterAdmin(ApplicationUser applicationUser)
        {
            var userResult = await _repository.UserIdentityRepository.RegisterAdmin(applicationUser);
            return userResult;
        }
    }
}
