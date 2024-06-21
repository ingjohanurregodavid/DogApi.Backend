using MediatR;

namespace DogApi.ApiRest.Queries
{
    public class GetDogBreedImageQuery: IRequest<List<string>>
    {
        public string Breed { get; set; }
    }
}
