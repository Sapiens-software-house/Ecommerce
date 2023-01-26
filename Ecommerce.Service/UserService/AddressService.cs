using Ecommerce.Interface.IAuthService;
using Ecommerce.Interface.IUnitOfWork;
using Ecommerce.Interface.IUserService;
using Ecommerce.UI.Shared.ServiceResponse;
using Ecommerce.UI.Shared.User;

namespace Ecommerce.Service.UserService
{
    public class AddressService : IAddressService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        public AddressService(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<ServiceResponse<Address>> AddOrUpdateAddress(Address address)
        {
            var response = new ServiceResponse<Address>();
            var dbAddress = (await GetAddress()).Data;
            if (dbAddress == null)
            {
                address.UserId = _authService.GetUserId();
                _unitOfWork.AddressRepository.Add(address);
                response.Data = address;
            }
            else
            {
                dbAddress.FirstName = address.FirstName;
                dbAddress.LastName = address.LastName;
                dbAddress.State = address.State;
                dbAddress.Country = address.Country;
                dbAddress.City = address.City;
                dbAddress.Zip = address.Zip;
                dbAddress.Street = address.Street;
                response.Data = dbAddress;
            }

            await _unitOfWork.SaveAsync();

            return response;
        }

        public async Task<ServiceResponse<Address>> GetAddress()
        {
            int userId = _authService.GetUserId();
            var addressToCheck = new Address();
            var address = await _unitOfWork.AddressRepository.FindAsync(a => a.UserId == userId);
            if (address != null)
            {
                addressToCheck = address.FirstOrDefault();
            }
            return new ServiceResponse<Address> { Data = addressToCheck };
        }
    }
}
