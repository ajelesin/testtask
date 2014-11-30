using System;
using TestLib;

namespace ClientCompletion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var hostname = args[0];
                var port = Convert.ToInt32(args[1]);

                var stdStream = new StdStreamProvider();
                var completer = new NetworkCompleter(hostname, port);

                var app = new App(stdStream, completer);
                app.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
