using System.Threading.Tasks;

namespace CatApi.Services
{
    public interface IImageService
    {
        public Task<byte[]> GetCatImageAsync();
    }
}
