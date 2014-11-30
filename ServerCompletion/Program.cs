using System;
using TestLib;

namespace ServerCompletion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var filename = args[0];
                var port = Convert.ToInt32(args[1]);

                var fileStream = new FileStreamProvider();
                fileStream.SetInFile(filename);
                var completer = new LocalCompleter(fileStream.GetTextReader());

                var server = new Server(port, completer);
                server.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
