using System;
using System.Collections.Generic;
using TestLib;

namespace ConsoleApp
{
    class App : TemplateApp
    {
        public App(IStreamProvider streamProvider, ICompleter completer)
            : base(streamProvider, completer)
        {
        }

        protected override IEnumerable<string> ReadPrefixes()
        {
            var textReader = _streamProvider.GetTextReader();
            var m = Convert.ToInt32(textReader.ReadLine());
            var result = new List<string>(m);

            for (int i = 0; i < m; i++)
            {
                result.Add(textReader.ReadLine());
            }
            return result;
        }
    }
}
