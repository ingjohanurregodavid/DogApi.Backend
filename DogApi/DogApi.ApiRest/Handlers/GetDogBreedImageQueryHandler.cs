using DogApi.ApiRest.Queries;
using DogApi.ApiRest.Services;
using MediatR;

namespace DogApi.ApiRest.Handlers
{
    public class GetDogBreedImageQueryHandler: IRequestHandler<GetDogBreedImageQuery, List<string>>
    {
        private readonly IDogApiClient _dogApiClient;

        public GetDogBreedImageQueryHandler(IDogApiClient dogApiClient)
        {
            _dogApiClient = dogApiClient;
        }

        public async Task<List<string>> Handle(GetDogBreedImageQuery request, CancellationToken cancellationToken)
        {
            return await _dogApiClient.FetchBreedImageAsync(request.Breed);
        }
    }
}
