using DogApi.ApiRest.Models;
using MediatR;

namespace DogApi.ApiRest.Queries
{
    public class GetDogBreedsQuery : IRequest<List<DogBreed>>
    {
    }
}
