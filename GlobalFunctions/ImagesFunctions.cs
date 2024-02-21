using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalFunctions
{
    public class ImagesFunctions
    {
        //FolderPath of forder inside the project: AppDomain.CurrentDomain.BaseDirectory
        public static Image loadImageFromProject(String FolderPath, String FolderName, string imageName)//to call it: button.background=loadImage(,) w ama tensa tghayir el prop imaghe la copy always
        {
            Image image = null;
            string imagePath = Path.Combine(FolderPath, FolderName, imageName);

            if (File.Exists(imagePath))
            {
                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    image = Image.FromStream(fs);
                }
            }
            return image;
        }
        public static void SaveImage(Image DesiredImage, string folderPath, string ImageName)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = Path.Combine(folderPath, ImageName + ".jpg");

                DesiredImage.Save(filePath, ImageFormat.Jpeg);//file with the same name will be overridden

            }
            catch (Exception ex)
            {

            }
        }
        public static void DeleteImage(string folderPath, string ImageName)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    string filePath = Path.Combine(folderPath, ImageName + ".jpg");
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static Image RetrieveImage(string folderPath, string ImageName)
        {
            try
            {
                string filePath = Path.Combine(folderPath, ImageName + ".jpg");

                if (!File.Exists(filePath))
                {
                    return null;
                }
                else
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        Image img = Image.FromStream(fs);
                        return new Bitmap(img);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Image CompressImage(Image sourceImage)
        {
            long quality = 100;
            int ByteMinCapacity = 100000;//0.1Mb
            // JPEG format allows you to specify quality level, which can reduce the final size.
            ImageCodecInfo jpegCodec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(e => e.FormatID == ImageFormat.Jpeg.Guid);
            if (jpegCodec == null) return null;//ma bet sir
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            Image compressedImage;
            MemoryStream ms1 = new MemoryStream();
            sourceImage.Save(ms1, ImageFormat.Jpeg); // Save as JPEG, you can choose a different format if needed

            if (ms1.Length < ByteMinCapacity)
            {
                compressedImage = Image.FromStream(ms1);
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                sourceImage.Save(ms, jpegCodec, encoderParams);

                while (ms.Length > ms1.Length * 0.5 && ms.Length > ByteMinCapacity && quality > 10)
                {
                    ms.SetLength(0); // Clear the memory stream
                    quality -= 5; // Adjust quality level
                    encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                    sourceImage.Save(ms, jpegCodec, encoderParams);
                }


                compressedImage = Image.FromStream(ms);
            }

            return compressedImage;

            //return sourceImage;
        }
    }
}
