using System.Collections.Generic;

namespace FDictionaryLib
{
    public class FWord
    {
        /// <summary>
        /// Слово Word
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// Число раз, которое встречается это слово в текстах
        /// </summary>
        public int Freq { get; set; }
    }

    internal class FWordComparer : IComparer<FWord>
    {
        public int Compare(FWord a, FWord b)
        {
            int r = a.Freq.CompareTo(b.Freq);
            if (r != 0) return -r;

            return a.Word.CompareTo(b.Word);
        }
    }
}
