using System.Collections.Generic;
using TestLib;

namespace ClientCompletion
{
    class App : TemplateApp
    {
        public App(IStreamProvider streamProvider, ICompleter completer)
            : base(streamProvider, completer)
        {
        }

        public new void Run()
        {
            while (true)
            {
                base.Run();
            }
        }

        protected override IEnumerable<string> ReadPrefixes()
        {
            var result = new List<string>
            {
                _streamProvider.GetTextReader().ReadLine()
            };

            return result;
        }
    }
}
