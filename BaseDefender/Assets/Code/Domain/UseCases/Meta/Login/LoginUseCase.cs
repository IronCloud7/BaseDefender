using Domain.Services.Server;
using System.Threading.Tasks;

namespace Domain.UseCases.Meta.Login
{
    public class LoginUseCase : LoginRequester
    {
        private readonly AuthenticateService _authenticateService;

        public LoginUseCase(AuthenticateService authentificateService)
        {
            _authenticateService = authentificateService;
        }

        public async Task Login()
        {
            await _authenticateService.Authenticate();
        }

    
    }
}

