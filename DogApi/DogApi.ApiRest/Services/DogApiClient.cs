using DogApi.ApiRest.Models;
using Newtonsoft.Json;
using System.Threading;

namespace DogApi.ApiRest.Services
{
    public class DogApiClient: IDogApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<DogApiClient> _logger;

        public DogApiClient(IHttpClientFactory httpClientFactory, ILogger<DogApiClient> logger)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #region Implementación de interfaz IDogApiClient
        public async Task<string> FetchRandomDogImageAsync()
        {
            using (var client = _httpClientFactory.CreateClient("DogApi"))
            {
                var response = await client.GetAsync("/api/breeds/image/random");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"Failed to fetch random dog image. Status code: {response.StatusCode}");
                    throw new HttpRequestException("Failed to fetch random dog image.");
                }

                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<RandomDogImageResponse>(data);
                var imagesBase64 =  ConvertImageToBase64(result.Message);

                return imagesBase64;
            }
        }

        public async Task<List<string>> FetchBreedImagesAsync(string breed)
        {
            using (var client = _httpClientFactory.CreateClient("DogApi"))
            {
                var response = await client.GetAsync($"/api/breed/{breed}/images");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"Failed to fetch images for breed {breed}. Status code: {response.StatusCode}");
                    throw new HttpRequestException($"Failed to fetch images for breed {breed}.");
                }

                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BreedImagesResponse>(data); 

                return result.Message;
            }
        }

        public async Task<List<string>> FetchBreedListAsync()
        {
            using (var client = _httpClientFactory.CreateClient("DogApi"))
            {
                var response = await client.GetAsync("/api/breeds/list");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"Failed to fetch breed list. Status code: {response.StatusCode}");
                    throw new HttpRequestException("Failed to fetch breed list.");
                }

                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BreedListResponse>(data); // Asume que la clase BreedListResponse es la estructura de datos del resultado.
                return result.Message;
            }
        }

        public async Task<List<DogBreed>> FetchDogBreedsAsync()
        {
            using (var client = _httpClientFactory.CreateClient("DogApi"))
            {
                var response = await client.GetAsync("/api/breeds/list/all");

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"Failed to fetch dog breeds. Status code: {response.StatusCode}");
                    throw new HttpRequestException($"Failed to fetch dog breeds. Status code: {response.StatusCode}");
                }

                var data = await response.Content.ReadAsStringAsync();
                var breedResponse = JsonConvert.DeserializeObject<DogBreedResponse>(data);
                var dogBreedsData = new DogBreedsData(breedResponse);
                return dogBreedsData.Breeds;
            }
        }

        public async Task<List<string>> FetchBreedImageAsync(string breed)
        {
            using (var client = _httpClientFactory.CreateClient("DogApi"))
            {
                var response = await client.GetAsync($"/api/breed/{breed}/images/random");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"Failed to fetch breed image. Status code: {response.StatusCode}");
                    throw new HttpRequestException("Failed to fetch breed list.");
                }

                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BreedImageResponse>(data);
                return result.Message;
            }
        }
        #endregion

        #region Metodos

        private string ConvertImageToBase64(string imageUrl)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(imageUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    byte[] imageBytes = response.Content.ReadAsByteArrayAsync().Result;
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
                else
                {
                    _logger.LogError($"Failed to fetch image from {imageUrl}. Status code: {response.StatusCode}");
                    throw new Exception($"Failed to fetch image from {imageUrl}. Status code: {response.StatusCode}");
                }
            }
        }

        #endregion
    }
}
