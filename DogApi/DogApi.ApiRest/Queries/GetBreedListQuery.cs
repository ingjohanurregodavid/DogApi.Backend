using MediatR;

namespace DogApi.ApiRest.Queries
{
    public class GetBreedListQuery : IRequest<List<string>>
    {
    }
}
