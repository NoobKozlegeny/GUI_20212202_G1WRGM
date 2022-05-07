using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GUI_20212202_G1WRGM.Others
{
    public static class ExtensionMethods
    {
        public static void Save(this BitmapImage image, Uri filePath)
        {
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));

            using (var fileStream = new System.IO.FileStream(image.UriSource.OriginalString, System.IO.FileMode.Append))
            {
                encoder.Save(fileStream);
            }
        }
    }
}
