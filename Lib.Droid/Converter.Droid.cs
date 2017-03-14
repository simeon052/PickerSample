using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using System.IO;

namespace MediaSample.Lib.Shared
{
    public partial class Converter : IConverter
    {
        public async Task<string> Save(string filePath, string outputFolder, ImageFileType type)
        {
            var opts = new Android.Graphics.BitmapFactory.Options();
            opts.InPreferredConfig = Android.Graphics.Bitmap.Config.Argb8888;
            Android.Graphics.Bitmap bitmap = await Android.Graphics.BitmapFactory.DecodeFileAsync(filePath, opts);

            var outputpath = Path.Combine(outputFolder, Path.ChangeExtension(Path.GetFileName(filePath), type.ToString()));
            var stream = new FileStream(outputpath, FileMode.Create);
            switch (type)
            {
                case ImageFileType.PNG:
                    bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 100, stream);
                    break;
                case ImageFileType.JPG:
                    bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Jpeg, 100, stream);
                    break;
                default:
                    throw new NotImplementedException();
            }
            stream.Close();

            return outputpath;
        }
    }
}