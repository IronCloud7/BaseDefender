using Domain.Services.Server;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class LoginUseCase : ILoginRequester
    {
        private readonly IAuthentificateService _authentificateService;

        public LoginUseCase(IAuthentificateService authentificateService)
        {
            _authentificateService = authentificateService;
        }

        public async Task Login()
        {
            await _authentificateService.Authentificate();
        }

    
    }
}

