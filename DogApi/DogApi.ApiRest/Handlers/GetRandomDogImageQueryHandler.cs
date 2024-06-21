using DogApi.ApiRest.Queries;
using DogApi.ApiRest.Services;
using MediatR;

namespace DogApi.ApiRest.Handlers
{
    public class GetRandomDogImageQueryHandler : IRequestHandler<GetRandomDogImageQuery, string>
    {
        private readonly IDogApiClient _dogApiClient;

        public GetRandomDogImageQueryHandler(IDogApiClient dogApiClient)
        {
            _dogApiClient = dogApiClient;
        }

        public async Task<string> Handle(GetRandomDogImageQuery request, CancellationToken cancellationToken)
        {
            return await _dogApiClient.FetchRandomDogImageAsync();
        }
    }
}
