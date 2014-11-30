using TestLib;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new StdStreamProvider();
            var completer = new LocalCompleter(provider.GetTextReader());

            var app = new App(provider, completer);
            app.Run();
        }
    }
}
