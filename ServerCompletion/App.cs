using System;
using System.Collections.Generic;
using System.Linq;
using TestLib;

namespace ServerCompletion
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
            var result = new List<string>();

            var request = textReader.ReadLine();
            var tokens = request
                .Split(' ')
                .Where(s => !String.IsNullOrEmpty(s))
                .ToArray();

            if (tokens.Length != 2 || tokens[0] != "get") return result;
            var prefix = tokens[1].Trim('\n');

            result.Add(prefix);
            return result;
        }

        protected override void WriteCompletions(IEnumerable<string> completions)
        {
            var textWriter = _streamProvider.GetTextWriter();
            var response = String.Empty;
            response = completions.Aggregate(
                response, (current, word) => current + (word + "\n"));
            textWriter.Write(response.TrimEnd('\n'));
        }
    }
}
