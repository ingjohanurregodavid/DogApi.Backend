using DogApi.ApiRest.Queries;
using DogApi.ApiRest.Services;
using MediatR;

namespace DogApi.ApiRest.Handlers
{
    public class AuthenticateUserQueryHandler :IRequestHandler<AuthenticateUserQuery, string>
    {
        private readonly IAuthService _authService;

        public AuthenticateUserQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<string> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            return await _authService.AuthenticateAsync(request.Username, request.Password, cancellationToken);
        }
    }
}
