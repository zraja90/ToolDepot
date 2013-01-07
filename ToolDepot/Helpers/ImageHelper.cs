using System.Drawing;
using System.Drawing.Drawing2D;

namespace ToolDepot.Helpers
{
    public static class ImageHelper
    {
        /// <summary>
        /// Creates a small image out of a larger image.
        /// </summary>
        /// <param name="original">The original image which should be cropped (will remain untouched).</param>
        /// <param name="x">The value where to start on the x axis.</param>
        /// <param name="y">The value where to start on the y axis.</param>
        /// <param name="width">The width of the final image.</param>
        /// <param name="height">The height of the final image.</param>
        /// <returns>The cropped image.</returns>
        public static Bitmap CreateImage(Bitmap original, int x, int y, int width, int height)
        {
            var img = new Bitmap(width, height);

            using (var g = Graphics.FromImage(img))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(original, new Rectangle(0, 0, width, height), x, y, width, height, GraphicsUnit.Pixel);
            }

            return img;
        }
    }
}