using Loxifi.Interfaces;

namespace Loxifi
{
    internal class UncompressedFileWriter : IFileWriter
    {
        private bool _disposedValue;
        private readonly StreamWriter _streamWriter;
        private readonly FileStream _fileStream;

        public string FullName { get; private set; }

        public UncompressedFileWriter(string fullFilePath)
        {
            FullName = new FileInfo(fullFilePath).FullName;
            _fileStream = new FileStream(FullName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            _streamWriter = new StreamWriter(_fileStream);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void Flush() => _streamWriter.Flush();

        public void Write(string s) => _streamWriter.Write(s);

        public void WriteLine(string s) => _streamWriter.WriteLine(s);

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _streamWriter.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        public void Write(byte[] bytes) => _fileStream.Write(bytes);

        public void Write(byte b) => _fileStream.WriteByte(b);
    }
}