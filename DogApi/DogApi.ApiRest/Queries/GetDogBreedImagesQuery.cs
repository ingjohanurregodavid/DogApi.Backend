using MediatR;

namespace DogApi.ApiRest.Queries
{
    public class GetDogBreedImagesQuery : IRequest<List<string>>
    {
        public string Breed { get; set; }
    }
}
