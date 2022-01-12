
using ApplicationLayer.Services.Server.PlayFab;
using Domain.UseCases;
using UnityEngine;

namespace UnityConfigurationAdapters.Installers
{
    public class GlobalInstaller : MonoBehaviour
    {
        public void Awake()
        {

            var playFabLogin = new PlayFabLogin();
            var loginUseCase = new LoginUseCase(playFabLogin);
            var initializeGameUseCase = new InitializeGameUseCase(loginUseCase);

            initializeGameUseCase.InitGame();
        }
    }
}
