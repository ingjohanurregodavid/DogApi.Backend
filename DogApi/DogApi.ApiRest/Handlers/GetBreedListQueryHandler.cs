

using DogApi.ApiRest.Queries;
using DogApi.ApiRest.Services;
using MediatR;

namespace DogApi.ApiRest.Handlers
{
    public class GetBreedListQueryHandler : IRequestHandler<GetBreedListQuery, List<string>>
    {
        private readonly IDogApiClient _dogApiClient;

        public GetBreedListQueryHandler(IDogApiClient dogApiClient)
        {
            _dogApiClient = dogApiClient;
        }

        public async Task<List<string>> Handle(GetBreedListQuery request, CancellationToken cancellationToken)
        {
            return await _dogApiClient.FetchBreedListAsync();
        }
    }
}
