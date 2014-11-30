using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using TestLib;

namespace ServerCompletion
{
    internal class Server
    {
        private readonly TcpListener _listener;
        private readonly ICompleter _completer;

        public Server(int port, ICompleter completer)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _completer = completer;
        }

        public void Start()
        {
            _listener.Start();

            while (true)
            {
                ThreadPool.QueueUserWorkItem(
                    ClientThread, _listener.AcceptTcpClient());
            }
        }

        private void ClientThread(Object stateInfo)
        {
            var tcpClient = (TcpClient) stateInfo;

            var netStream = new NetStreamProvider(tcpClient);
            var app = new App(netStream, _completer);
            app.Run();

            tcpClient.Close();
        }
    }
}
