using System.Collections.Generic;

namespace FDictionaryLib
{
    public interface IFDictionary
    {
        /// <summary>
        /// Добавить слово Word в словарь
        /// </summary>
        void Add(FWord fWord);

        /// <summary>
        /// Добавить последовательность слов в словарь
        /// </summary>
        void AddRange(IEnumerable<FWord> fWordEnumerable);

        /// <summary>
        /// Найти все слова в словаре, начинающиеся с префикса Prefix
        /// </summary>
        IEnumerable<FWord> Prefix(string prefix);

        /// <summary>
        /// Удалить все слова из словаря
        /// </summary>
        void Clear();
    }
}
