namespace SarahASL.Services.Interfaces
{
    public interface IVideoService
    {
        public Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file);
        public string? ConvertByteArrayToFile(byte[] fileData, string? extension);
    }
}
