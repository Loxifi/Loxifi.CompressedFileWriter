using Loxifi.FileWriters;
using Loxifi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loxifi
{
    internal static class FileWriterFactory
    {
        public static IFileWriter GetFileWriter(string filePath, FileStreamCompression compression)
        {
            return compression switch
            {
                FileStreamCompression.None => new UncompressedFileWriter(filePath),
                FileStreamCompression.Gzip => new GZipWriter(filePath),
                FileStreamCompression.Zip => new ZipWriter(filePath),
                _ => throw new Exception($"Unhandled FileStreamCompression '{compression}'"),
            };
        }
    }
}
