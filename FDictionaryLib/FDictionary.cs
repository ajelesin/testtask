using System.Collections.Generic;

namespace FDictionaryLib
{
    public class FDictionary : IFDictionary
    {
        private SortedTrieNode _node;

        public FDictionary()
        {
            _node = new SortedTrieNode();
        }

        /// <summary>
        /// Добавить слово Word в словарь
        /// </summary>
        public void Add(FWord word)
        {
            _node.Add(_node, word, 0);
        }

        /// <summary>
        /// Добавить последовательность слов в словарь
        /// </summary>
        public void AddRange(IEnumerable<FWord> fWordEnumerable)
        {
            foreach (var fWord in fWordEnumerable)
            {
                Add(fWord);
            }
        }

        /// <summary>
        /// Найти все слова в словаре, начинающиеся с префикса Prefix
        /// </summary>
        public IEnumerable<FWord> Prefix(string prefix)
        {
            return _node.Prefix(prefix, _node);
        }

        /// <summary>
        /// Удалить все слова из словаря
        /// </summary>
        public void Clear()
        {
            _node = new SortedTrieNode();
        }

    }
}
