using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Application.Services.ImageService
{
    public abstract class ImageServiceBase
    {
        public abstract Task<string> UploadAsync(IFormFile formFile);
        public abstract Task DeleteAsync(string imageUrl);
        public async Task<string> UpdateAsync(IFormFile formFile, string imageUrl)
        {
            await FileMustBeInImageFromat(formFile);
            await DeleteAsync(imageUrl);
            return await UploadAsync(formFile);
        }
        protected async Task FileMustBeInImageFromat(IFormFile formFile)
        {
            List<string> extensions = new() { ".jpg", ".png", ".jpeg", ".webp" };
            string extension = Path.GetExtension(formFile.FileName).ToLower();
            if (!extensions.Contains(extension)) throw new BusinessException("Unsupported format!");
            await Task.CompletedTask;
        }
    }
}
