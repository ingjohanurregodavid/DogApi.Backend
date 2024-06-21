using DogApi.ApiRest.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogApi.ApiRest.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("breeds")]
        public async Task<IActionResult> GetDogBreeds()
        {
            var query = new GetDogBreedsQuery();
            var breeds = await _mediator.Send(query);
            return Ok(breeds);
        }

        [HttpGet("random-image")]
        public async Task<IActionResult> GetRandomDogImage()
        {
            var query = new GetRandomDogImageQuery();
            var imageUrl = await _mediator.Send(query);
            return Ok(new { imageUrl });
        }

        [HttpGet("breed/{breed}/images")]
        public async Task<IActionResult> GetDogBreedImages(string breed)
        {
            var query = new GetDogBreedImagesQuery { Breed = breed };
            var images = await _mediator.Send(query);
            return Ok(images);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetDogBreedList()
        {
            var query = new GetBreedListQuery();
            var breeds = await _mediator.Send(query);
            return Ok(breeds);
        }

        [HttpGet("breed/{breed}/images/random")]
        public async Task<IActionResult> GetDogBreedImage(string breed)
        {
            var query = new GetDogBreedImageQuery { Breed = breed };
            var images = await _mediator.Send(query);
            return Ok(images);
        }
    }
}
