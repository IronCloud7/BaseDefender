using Domain.DataAccess;
using System.Threading.Tasks;
using UnityEngine;

namespace Domain.UseCases.Meta.LoadUserData
{
    public class LoadUserDataUseCase : UserDataLoader
    {
        private readonly UserDataAccess _userDataAccess;

        public LoadUserDataUseCase(UserDataAccess userDataAccess)
        {
           _userDataAccess = userDataAccess;
        }

        public async Task Load()
        {
            var localUser = await _userDataAccess.GetLocalUser();     
            Debug.Log(localUser.IsInitialized);
        }
    }
}
