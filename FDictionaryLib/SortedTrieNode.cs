using System.Collections.Generic;

namespace FDictionaryLib
{
    internal class SortedTrieNode
    {
        private SortedTrieNode[] _children;
        private SortedSet<FWord> _words;

        private static readonly FWordComparer FWordComparer = new FWordComparer();
        private static readonly SortedSet<FWord> EmptySet = new SortedSet<FWord>();
        private const int LettersAmount = 26;

        public SortedTrieNode()
        {
            _children = new SortedTrieNode[LettersAmount];
            _words = new SortedSet<FWord>(FWordComparer);
        }

        public void Add(SortedTrieNode node, FWord fWord, int pos)
        {
            while (true)
            {
                if (pos != 0)
                {
                    node._words.Add(fWord);
                }

                if (pos == fWord.Word.Length)
                {
                    return;
                }

                var firstChar = fWord.Word[pos];
                var index = (int) (firstChar - 'a');
                if (node._children[index] == null)
                {
                    node._children[index] = new SortedTrieNode();
                }

                node = node._children[index];
                pos = ++pos;
            }
        }

        public IEnumerable<FWord> Prefix(string prefix, SortedTrieNode node)
        {
            while (true)
            {
                if (prefix == "")
                {
                    return node._words;
                }

                var firstChar = prefix[0];
                var index = (int) (firstChar - 'a');
                if (node._children[index] == null)
                {
                    return EmptySet;
                }

                prefix = prefix.Substring(1);
                node = node._children[index];
            }
        }
    }
}
