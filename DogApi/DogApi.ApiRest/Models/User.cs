namespace DogApi.ApiRest.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
