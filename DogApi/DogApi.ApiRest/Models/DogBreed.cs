namespace DogApi.ApiRest.Models
{
    public class DogBreed
    {
        public string Name { get; set; }
        public List<string> SubBreeds { get; set; } = new List<string>();
    }

    public class DogBreedResponse
    {
        public Dictionary<string, List<string>> Message { get; set; }
        public string Status { get; set; }
    }
    public class DogBreedsData
    {
        public List<DogBreed> Breeds { get; set; } = new List<DogBreed>();

        public DogBreedsData(DogBreedResponse response)
        {
            if (response.Message != null)
            {
                foreach (var breedEntry in response.Message)
                {
                    Breeds.Add(new DogBreed
                    {
                        Name = breedEntry.Key,
                        SubBreeds = breedEntry.Value
                    });
                }
            }
        }
    }


    public class RandomDogImageResponse
    {
        public string Message { get; set; }
        public string Status { get; set; }
    }

    public class BreedImagesResponse
    {
        public List<string> Message { get; set; }
        public string Status { get; set; }
    }

    public class BreedListResponse
    {
        public List<string> Message { get; set; }
        public string Status { get; set; }
    }

    public class BreedImageResponse
    {
        public List<string> Message { get; set; }
        public string Status { get; set; }
        public string Code { get; set; }
    }

}
