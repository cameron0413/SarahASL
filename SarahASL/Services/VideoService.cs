using SarahASL.Services.Interfaces;

namespace SarahASL.Services
{
    public class VideoService : IVideoService
    {
        #region Globals
        private readonly string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };
        private readonly string defaultVideoImgSrc = "/img/defaultVideoImgSrc";
        #endregion


        public string? ConvertByteArrayToFile(byte[] fileData, string? extension)
        {

            if (fileData == null || fileData.Length == 0)
            {
                return defaultVideoImgSrc;

            }
            try
            {
                string? imageBase64Data = Convert.ToBase64String(fileData!);
                return string.Format($"data:{extension};base64, {imageBase64Data}");
                //^^^^^ Interpolated code
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            try
            {
                using MemoryStream memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                byte[] byteArray = memoryStream.ToArray();
                return byteArray;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
