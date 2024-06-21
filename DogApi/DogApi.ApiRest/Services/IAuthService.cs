namespace DogApi.ApiRest.Services
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(string username, string password, CancellationToken cancellationToken);
    }
}

