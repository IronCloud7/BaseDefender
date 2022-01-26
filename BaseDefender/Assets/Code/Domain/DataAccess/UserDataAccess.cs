using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.DataAccess
{
    public interface UserDataAccess
    {
        Task<User> GetLocalUser();
    }
}
