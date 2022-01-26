using PlayFab;
using PlayFab.ClientModels;
using System.Threading.Tasks;
using UnityEngine;

namespace ApplicationLayer.Services.Server.PlayFab
{
    public class PlayFabLoginAndroidEditor : IPlayFabLogin
    {
        protected override void Login(TaskCompletionSource<bool> taskCompletionSource)
        {
            var request = new LoginWithAndroidDeviceIDRequest
            {
                CreateAccount = true,
                AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
            };

            PlayFabClientAPI
               .LoginWithAndroidDeviceID(request,
                                  success => OnSuccess(success, taskCompletionSource),
                                  error => OnError(error, taskCompletionSource)
                                 );
        }
    }
}