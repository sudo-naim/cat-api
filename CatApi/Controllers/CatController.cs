using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CatApi.Services;

namespace CatApi.Controllers
{
    [Route("/api/v1")]
    public class CatController : ControllerBase
    {
        private readonly IImageService _imageService;

        public CatController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("/cat")]
        public async Task<IActionResult> Cat()
        {
            var bytes = await _imageService.GetCatImageAsync();
            return File(bytes, "image/png");
        }
    }
}
