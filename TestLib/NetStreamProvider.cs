using System.IO;
using System.Net.Sockets;

namespace TestLib
{

    public class NetStreamProvider : IStreamProvider
    {
        private readonly TcpClient _client;
        private readonly StreamReader _streamReader;
        private readonly StreamWriter _streamWriter;

        public NetStreamProvider(TcpClient client)
        {
            _client = client;
            _streamReader = new StreamReader(_client.GetStream());
            _streamWriter = new StreamWriter(_client.GetStream()) { AutoFlush = true };
        }

        public TextReader GetTextReader()
        {
            return _streamReader;
        }

        public TextWriter GetTextWriter()
        {
            return _streamWriter;
        }
    }
}
