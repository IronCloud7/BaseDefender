using ApplicationLayer.DataAccess;
using ApplicationLayer.Services.Serializer;
using ApplicationLayer.Services.Server.Gateways.Catalog;
using ApplicationLayer.Services.Server.Gateways.ServerData;
using ApplicationLayer.Services.Server.PlayFab;
using ApplicationLayer.Services.Server.PlayFab.Catalog;
using Domain.UseCases;
using Domain.UseCases.Meta.InitializeGame;
using Domain.UseCases.Meta.LoadUserData;
using Domain.UseCases.Meta.Login;
using System;
using UnityEngine;

namespace UnityConfigurationAdapters.Installers
{
    public class GlobalInstaller : MonoBehaviour
    {
        public void Awake()
        {

            //Login
            var playFabLogin = GetPlayFabLogin();
            var loginUseCase = new LoginUseCase(playFabLogin);

            //Serializador
            var unityJsonSerializer = new UnityJsonSerializer();

            //Usuario
            var playFabGetUserDataService = new PlayFabGetUserDataService();
            var userDataGateway = new UserDataGateway(unityJsonSerializer, playFabGetUserDataService, null);
            var userDataAccess = new UserRepository(userDataGateway);
            var loadUserDataUseCase = new LoadUserDataUseCase(userDataAccess);

            //Catálogo
            var playFabCatalogService = new PlayFabCatalogService();
            var catalogGateway = new CatalogGatewayImpl(unityJsonSerializer, playFabCatalogService);
            var unitsDataAccess = new UnitsRepository(catalogGateway);
            var loadServerDataUseCase = new LoadServerDataUseCase(unitsDataAccess);

            //Juego
            var initializeGameUseCase = new InitializeGameUseCase(loginUseCase, loadUserDataUseCase, loadServerDataUseCase);

            initializeGameUseCase.InitGame();
        }


        private static IPlayFabLogin GetPlayFabLogin()
        {
#if UNITY_EDITOR
            return new PlayFabLoginEditor();
#elif UNITY_ANDROID
            return new PlayFabLoginAndroidEditor();
#elif UNITY_IOS
            return new PlayFabLoginiOSEditor();          
#endif
            throw new Exception("Platform not defined");
        }
    }
}
