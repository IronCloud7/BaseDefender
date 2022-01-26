using PlayFab;
using PlayFab.ClientModels;
using System.Threading.Tasks;
using UnityEngine.iOS;

namespace ApplicationLayer.Services.Server.PlayFab
{
    public class PlayFabLoginiOSEditor : IPlayFabLogin
    {
        protected override void Login(TaskCompletionSource<bool> taskCompletionSource)
        {
            var request = new LoginWithIOSDeviceIDRequest
            {
                CreateAccount = true,
                DeviceId = Device.vendorIdentifier
            };

            PlayFabClientAPI.LoginWithIOSDeviceID(request,
                            success => OnSuccess(success, taskCompletionSource),
                            error => OnError(error, taskCompletionSource));
        }
    }
}