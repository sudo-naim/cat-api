using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace CatApi.Services
{
    public class ImageService : IImageService
    {
        private readonly HttpClient _httpClient;
        private readonly string _catApiUrl;
        public ImageService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _catApiUrl = configuration["CatApi:Url"];
        }

        public async Task<byte[]> GetCatImageAsync()
        {
            //get image from cat api
            var bytes = await _httpClient.GetByteArrayAsync(_catApiUrl);
            //convert image(flip it upside down)
            using var image = Image.Load(bytes);
            image.Mutate(x => x.Rotate(180));
            using var stream = new MemoryStream(bytes.Length);
            image.Save(stream, PngFormat.Instance);
            //return as bytes
            return stream.ToArray(); ;
        }
    }
}
