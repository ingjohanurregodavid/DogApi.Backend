using DogApi.ApiRest.Models;

namespace DogApi.ApiRest.Services
{
    public interface IDogApiClient
    {
        Task<List<DogBreed>> FetchDogBreedsAsync();
        Task<string> FetchRandomDogImageAsync();
        Task<List<string>> FetchBreedImageAsync(string breed);
        Task<List<string>> FetchBreedImagesAsync(string breed);
        Task<List<string>> FetchBreedListAsync();
    }
}
