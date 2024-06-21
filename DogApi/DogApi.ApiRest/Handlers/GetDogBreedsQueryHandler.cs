using DogApi.ApiRest.Models;
using DogApi.ApiRest.Queries;
using DogApi.ApiRest.Services;
using MediatR;
using Newtonsoft.Json;

namespace DogApi.ApiRest.Handlers
{
    public class GetDogBreedsQueryHandler : IRequestHandler<GetDogBreedsQuery, List<DogBreed>>
    {
        private readonly IDogApiClient _dogApiClient;

        public GetDogBreedsQueryHandler(IDogApiClient dogApiClient)
        {
            _dogApiClient = dogApiClient;
        }

        public async Task<List<DogBreed>> Handle(GetDogBreedsQuery request, CancellationToken cancellationToken)
        {
            return await _dogApiClient.FetchDogBreedsAsync();
        }
    }
}
