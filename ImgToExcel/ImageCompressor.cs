using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImgToExcel
{
    /// <summary>
    /// Класс сжатия изображений
    /// </summary>
    static class ImageCompressor
    {
        /// <summary>
        /// Изменяет размер изображения к целевому размеру
        /// </summary>
        /// <param name="image">Объект изображения</param>
        /// <param name="sm_width">Ширина в сантиметрах</param>
        /// <param name="sm_height">Высота в сантиметрах</param>
        /// <returns></returns>
        public static Image ResizeImage(Image image, int width, int height)
        {
            float k = GetScaling(image, width, height);
            float k_width = k * image.Width;
            float k_height = k * image.Height;
            float x = (width - k_width) / 2;
            x = x < 0 ? 0 : x;
            float y = (height - k_height) / 2;
            y = y < 0 ? 0 : y;

            Image r_image = new Bitmap(width, height, image.PixelFormat);
            ((Bitmap)r_image).SetResolution(96, 96);
            Graphics g = Graphics.FromImage(r_image);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.Clear(Color.White);
            g.DrawImage(image, x, y, k_width, k_height);
            g.Dispose();
            return r_image;
        }

        /// <summary>
        /// Изменяет размер изображения к целевой ширине
        /// </summary>
        /// <param name="image">Объект изображения</param>
        /// <param name="sm_width">Целевая ширина в сантиметрах</param>
        /// <returns></returns>
        public static Image ResizeImage(Image image, int width)
        {
            //int width = (int)(sm_width / 2.54 * 96);
            float k = (float)width / image.Width;
            int height = (int)(k * image.Height);

            Image r_image = new Bitmap(width, height, image.PixelFormat);
            ((Bitmap)r_image).SetResolution(96, 96);
            Graphics g = Graphics.FromImage(r_image);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.Clear(Color.White);
            g.DrawImage(image, 0, 0, width, height);
            g.Dispose();
            return r_image;
        }

        private static float GetScaling(Image image, int width, int height)
        {
            int w_diff = image.Width - width;
            int h_diff = image.Height - height;

            if (w_diff < 0 && h_diff < 0) return 1;
            else if (w_diff > h_diff) return (float)width / image.Width;
            else return (float)height / image.Height;
        }

        /// <summary>
        /// Сжимает вес изображения с потерей качества.
        /// </summary>
        /// <param name="image">Объект изображения</param>
        /// <param name="compressLevel">Уровень сжатия 0 - 100L. 100L - Максимально сильное сжатие.</param>
        /// <returns></returns>
        public static Image CompressImage(Image image, long compressLevel)
        {
            if (compressLevel < 0 || compressLevel > 100) return image;
            MemoryStream memory = new MemoryStream();

            image.Save(
                    memory,
                    ImageCodecInfo.GetImageEncoders()[1],
                    new EncoderParameters()
                    {
                        Param = new EncoderParameter[]
                        {
                            new EncoderParameter(Encoder.Quality, 100L - compressLevel)
                        }
                    });

            image = Image.FromStream(memory);
            memory.Dispose();

            return image;
        }
    }
}
