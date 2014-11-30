using System;
using System.IO;

namespace TestLib
{
    public class StdStreamProvider : IStreamProvider
    {
        public TextReader GetTextReader()
        {
            return Console.In;
        }

        public TextWriter GetTextWriter()
        {
            return Console.Out;
        }
    }
}
