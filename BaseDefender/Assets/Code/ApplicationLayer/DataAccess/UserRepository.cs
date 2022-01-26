using ApplicationLayer.Services.Server.Dtos.User;
using ApplicationLayer.Services.Server.Gateways.ServerData;
using Domain.DataAccess;
using Domain.Entities;
using Domain.Services.Server;
using System.Threading.Tasks;

namespace ApplicationLayer.DataAccess
{
    public class UserRepository : UserDataAccess
    {
        private readonly AuthenticateService _authenticateService;
        private readonly Gateway _userDataGateway;
        private User _localUser;

        public UserRepository(Gateway userDataGateway)
        {
            _userDataGateway = userDataGateway;
        }

        public async Task<User> GetLocalUser()
        {
            if (_localUser != null)
            {
                return _localUser;
            }

            var isInitialized = await _userDataGateway.Contains<IsInitializedDto>();
            _localUser = new User(isInitialized);
            return _localUser;
        }
    }
}
