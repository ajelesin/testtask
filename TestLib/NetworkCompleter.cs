using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace TestLib
{
    public class NetworkCompleter : ICompleter
    {
        private readonly string _hostname;
        private readonly int _port;

        public NetworkCompleter(string hostname, int port)
        {
            _hostname = hostname;
            _port = port;
        }

        public IEnumerable<string> Complete(string prefix)
        {
            var result = new List<string>();

            var message = string.Format("get {0}{1}", prefix, Environment.NewLine);
            var client = new TcpClient(_hostname, _port);
            var net = new NetStreamProvider(client);
            net.GetTextWriter().Write(message);

            var responseData = string.Empty;
            while ((responseData = net.GetTextReader().ReadLine()) != null)
            {
                result.Add(responseData.Trim('\n'));
            }

            return result;
        }
    }
}
