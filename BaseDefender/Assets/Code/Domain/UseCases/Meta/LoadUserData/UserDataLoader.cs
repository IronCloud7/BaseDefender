using System.Threading.Tasks;

namespace Domain.UseCases.Meta.LoadUserData
{
    public interface UserDataLoader
    {
        public Task Load();
    }
}