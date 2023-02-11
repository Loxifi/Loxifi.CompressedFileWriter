using Loxifi.Interfaces;
using System.IO.Compression;

namespace Loxifi.FileWriters
{
    internal class ZipWriter : IFileWriter
    {
        private readonly ZipArchive _archive;
        private readonly ZipArchiveEntry _fileArchive;
        private readonly Stream _fileStream;
        private readonly StreamWriter _streamWriter;
        private bool _disposedValue;

        public string FullName { get; private set; }

        public ZipWriter(string fullFileName)
        {
            FullName = new FileInfo(fullFileName + ".zip").FullName;

            _archive = new ZipArchive(new FileStream(FullName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite), ZipArchiveMode.Create, false);

            _fileArchive = _archive.CreateEntry(Path.GetFileName(fullFileName), CompressionLevel.Optimal);

            _fileStream = _fileArchive.Open();

            _streamWriter = new StreamWriter(_fileStream);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void Flush()
        {
            _streamWriter.Flush();
            _fileStream.Flush();
        }

        public void Write(string s) => _streamWriter.Write(s);

        public void WriteLine(string s) => _streamWriter.WriteLine(s);

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                _disposedValue = true;

                if (disposing)
                {
                    _streamWriter.Flush();
                    _archive.Dispose();
                }
            }
        }

        public void Write(byte[] bytes) => _fileStream.Write(bytes);
        public void Write(byte b) => _fileStream.WriteByte(b);
    }
}
