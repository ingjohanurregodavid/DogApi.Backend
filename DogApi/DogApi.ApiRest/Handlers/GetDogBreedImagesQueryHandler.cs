using DogApi.ApiRest.Queries;
using DogApi.ApiRest.Services;
using MediatR;

namespace DogApi.ApiRest.Handlers
{
    public class GetDogBreedImagesQueryHandler : IRequestHandler<GetDogBreedImagesQuery, List<string>>
    {
        private readonly IDogApiClient _dogApiClient;

        public GetDogBreedImagesQueryHandler(IDogApiClient dogApiClient)
        {
            _dogApiClient = dogApiClient;
        }

        public async Task<List<string>> Handle(GetDogBreedImagesQuery request, CancellationToken cancellationToken)
        {
            return await _dogApiClient.FetchBreedImagesAsync(request.Breed);
        }
    }
}
