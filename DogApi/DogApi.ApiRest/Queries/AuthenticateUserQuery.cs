using MediatR;

namespace DogApi.ApiRest.Queries
{
    public class AuthenticateUserQuery : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public CancellationToken CancellationToken { get; set; }
    }
}
