using DogApi.ApiRest.Models;
using MediatR;

namespace DogApi.ApiRest.Commands
{
    //Clase para obtener las razas de los Perros
    public class GetDogBreedsCommand:IRequest<List<DogBreed>>
    {
    }
}
