using Domain.UseCases.Meta.LoadUserData;
using Domain.UseCases.Meta.Login;

namespace Domain.UseCases.Meta.InitializeGame
{
    public class InitializeGameUseCase : GameInitializer
    {
        private readonly LoginRequester _loginRequester;
        private readonly UserDataLoader _userDataLoader;
        private readonly ServerDataLoader _serverDataLoader;

        public InitializeGameUseCase(LoginRequester loginRequester, UserDataLoader userDataLoader, ServerDataLoader serverDataLoader)
        {
            _loginRequester = loginRequester;
            _userDataLoader = userDataLoader;
            _serverDataLoader = serverDataLoader;
        }

        public async void InitGame()
        {
            await _loginRequester.Login();
            await _userDataLoader.Load();
            await _serverDataLoader.Load();
            // Load server configuration
        }
    }
}

