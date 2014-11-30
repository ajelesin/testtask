using System.Collections.Generic;
using System.IO;
using System.Linq;
using FDictionaryLib;

namespace TestLib
{
    public class LocalCompleter : ICompleter
    {
        private readonly FDictionary _fDictionary;

        public LocalCompleter(IEnumerable<FWord> wordsSource)
        {
            _fDictionary = new FDictionary();
            _fDictionary.AddRange(wordsSource);
        }

        public LocalCompleter(TextReader wordsSource)
        {
            _fDictionary = new FDictionary();
            _fDictionary.LoadFromTextReader(wordsSource);
        }

        public IEnumerable<string> Complete(string prefix)
        {
            return _fDictionary.Prefix(prefix)
                .Take(10)
                .Select(o => o.Word);
        }
    }
}
