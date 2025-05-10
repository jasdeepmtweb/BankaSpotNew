using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace BankaSpotNew.App_Code
{
    public class ImageCompressor
    {
        public static byte[] CompressImage(byte[] originalImage, long quality)
        {
            using (var ms = new MemoryStream(originalImage))
            using (var img = System.Drawing.Image.FromStream(ms))
            {
                var encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);
                var codecInfo = GetEncoderInfo("image/jpeg");

                using (var output = new MemoryStream())
                {
                    img.Save(output, codecInfo, encoderParameters);
                    return output.ToArray();
                }
            }
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            return ImageCodecInfo.GetImageEncoders().FirstOrDefault(c => c.MimeType == mimeType);
        }

        public static string SaveFile(string fileName, byte[] fileBytes, string uploadPath)
        {
            byte[] originalImageBytes = fileBytes;
            byte[] compressedImageBytes = CompressImage(originalImageBytes, 80);
            string extension = Path.GetExtension(fileName);
            fileName = Guid.NewGuid().ToString() + extension;
            string fullPath = Path.Combine(uploadPath, fileName);
            File.WriteAllBytes(fullPath, compressedImageBytes);
            return fileName;
        }
        public static byte[] GetFileBytes(HttpPostedFile uploadedFile)
        {
            if (uploadedFile != null && uploadedFile.ContentLength > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    uploadedFile.InputStream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
            return null;
        }
    }
}