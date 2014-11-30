using System.IO;

namespace TestLib
{
    public interface IStreamProvider
    {
        TextReader GetTextReader();
        TextWriter GetTextWriter();
    }
}
