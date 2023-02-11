namespace Loxifi.Interfaces
{
    internal interface IFileWriter : IDisposable
    {
        void Flush();

        void Write(string s);

        void WriteLine(string s);

        void Write(byte[] bytes);

        void Write(byte b);

        string FullName { get; }
    }
}
