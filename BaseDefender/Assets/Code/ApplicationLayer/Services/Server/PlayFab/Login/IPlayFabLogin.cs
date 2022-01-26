
using Domain.Services.Server;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace ApplicationLayer.Services.Server.PlayFab
{
    public abstract class IPlayFabLogin : AuthenticateService
    {
        public string UserId { get; private set; }

        public  Task Authenticate()
        {
            var t = new TaskCompletionSource<bool>();

            Login(t);

            return Task.Run(() => t.Task);
        }

        protected abstract void Login(TaskCompletionSource<bool> taskCompletionSource);

        protected void OnSuccess(LoginResult result, TaskCompletionSource<bool> taskCompletionSource)
        {
            UserId = result.PlayFabId;
            taskCompletionSource.SetResult(true);
            Debug.Log("Login");
        }


        protected void OnError(PlayFabError error, TaskCompletionSource<bool> taskCompletionSource)
        {
            taskCompletionSource.SetResult(false);
            throw new Exception(error.ErrorMessage);
        }
    }
}