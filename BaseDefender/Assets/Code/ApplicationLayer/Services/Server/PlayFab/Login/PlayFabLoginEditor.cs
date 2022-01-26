using PlayFab;
using PlayFab.ClientModels;
using System.Threading.Tasks;


namespace ApplicationLayer.Services.Server.PlayFab
{
    public class PlayFabLoginEditor : IPlayFabLogin
    {
        protected override void Login(TaskCompletionSource<bool> taskCompletionSource)
        {
            var request = new LoginWithCustomIDRequest
            {
                CreateAccount = true,
                CustomId = "1"
            };


            PlayFabClientAPI
               .LoginWithCustomID(request,
                                  success => OnSuccess(success, taskCompletionSource),
                                  error => OnError(error, taskCompletionSource)
                                 );
        }
    }
}