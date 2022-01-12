namespace Domain.UseCases
{
    public class InitializeGameUseCase : IGameInitializer
    {
        private readonly ILoginRequester _loginRequester;

        public InitializeGameUseCase(ILoginRequester loginRequester)
        {
            _loginRequester = loginRequester;
        }

        public async void InitGame()
        {
            await _loginRequester.Login();

            // Load server configuration
            // Load user configuration
        }
    }
}

