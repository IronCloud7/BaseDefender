
using Domain.Services.Server;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace ApplicationLayer.Services.Server.PlayFab
{
     public class PlayFabLogin : IAuthentificateService
     {
        private string _userId;

        public Task Authentificate()
        {
            var t = new TaskCompletionSource<bool>();
            var request = new LoginWithCustomIDRequest
            {
                CreateAccount = true,
                CustomId = "1"
            };

            PlayFabClientAPI.LoginWithCustomID(request, okResult => OnSuccessResult(okResult, t), errorResult => OnErrorResult(errorResult, t));

            return Task.Run(() => t.Task);
        }

        private void OnSuccessResult(LoginResult result, TaskCompletionSource<bool> taskCompletionSource)
        {
            _userId = result.PlayFabId;
            taskCompletionSource.SetResult(true);
            Debug.Log("Login");
        }


        private void OnErrorResult(PlayFabError error, TaskCompletionSource<bool> taskCompletionSource)
        {
            taskCompletionSource.SetResult(false);
            throw new Exception(error.ErrorMessage);
        }
    }
}