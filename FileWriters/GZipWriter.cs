using Loxifi.Interfaces;
using System.IO.Compression;

namespace Loxifi.FileWriters
{
    internal class GZipWriter : IFileWriter
    {
        private bool _disposedValue;
        private readonly StreamWriter _streamWriter;

        public GZipStream Compress { get; }

        public FileStream OutFile { get; private set; }

        public string FullName { get; private set; }

        public GZipWriter(string fullFileName)
        {
            FullName = new FileInfo(fullFileName + ".gz").FullName;
            OutFile = File.Create(FullName);
            Compress = new GZipStream(OutFile, CompressionLevel.Optimal);
            _streamWriter = new StreamWriter(Compress);
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
            Compress.Flush();
        }

        public void Write(string s) => _streamWriter.Write(s);

        public void WriteLine(string s) => _streamWriter.WriteLine(s);

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _streamWriter.Flush();
                    _streamWriter.Close();
                    _streamWriter.Dispose();
                    Compress.Dispose();
                    OutFile.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        public void Write(byte[] bytes) => Compress.Write(bytes);
        public void Write(byte b) => Compress.WriteByte(b);
    }
}
