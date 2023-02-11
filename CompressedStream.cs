using Loxifi.Interfaces;

namespace Loxifi
{
    /// <summary>
    /// An instance of a CompressedFileWriter that selects an underlying stream
    /// based on the provided compression method
    /// </summary>
    public sealed class CompressedFileWriter : IFileWriter
    {
        private readonly IFileWriter _selectedWriter;

        /// <summary>
        /// Instantiates a new CompressedFileWriter
        /// </summary>
        /// <param name="path">The path of the file being written</param>
        /// <param name="fileStreamCompression">The compression to use when writing</param>
        public CompressedFileWriter(string path, FileStreamCompression fileStreamCompression)
        {
            _selectedWriter = FileWriterFactory.GetFileWriter(path, fileStreamCompression);
        }

        /// <summary>
        /// The full path of the file being written
        /// </summary>
        public string FullName => this._selectedWriter.FullName;

        /// <summary>
        /// Flushes the underlying data stream to disk, and disposes of 
        /// it, performing any finalization actions on the archive
        /// </summary>
        public void Dispose() => this._selectedWriter.Dispose();

        /// <summary>
        /// Flushes the underlying data stream to disk
        /// </summary>
        public void Flush() => this._selectedWriter.Flush();

        /// <summary>
        /// Writes a string to the underlying data stream
        /// </summary>
        /// <param name="s">The string to write</param>
        public void Write(string s) => this._selectedWriter.Write(s);

        /// <summary>
        /// Writes a byte array to the underlying data stream
        /// </summary>
        /// <param name="bytes">The bytes to write</param>
        public void Write(byte[] bytes) => this._selectedWriter.Write(bytes);

        /// <summary>
        /// Writes a single byte to the underlying data stream
        /// </summary>
        /// <param name="b">The byte to write</param>
        public void Write(byte b) => this._selectedWriter.Write(b);

        /// <summary>
        /// Writes a string to the underlying data stream, followed by a newline
        /// </summary>
        /// <param name="s">The string to write</param>
        public void WriteLine(string s) => this._selectedWriter.WriteLine(s);
    }
}