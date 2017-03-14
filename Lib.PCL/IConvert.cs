using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSample.Lib.Shared
{
        public enum ImageFileType
        {
            JPG = 0,
            PNG,
            TIFF,
            PDF,
        }

    public interface IConverter
    {
        Task<string> Save(string filePath, string outputFolder, ImageFileType type);
    }
}
