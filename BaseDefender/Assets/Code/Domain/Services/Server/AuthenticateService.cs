using System.Threading.Tasks;

namespace Domain.Services.Server
{
    public interface AuthenticateService
    {
        Task Authenticate();
    }
}
