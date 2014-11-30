using System.Collections.Generic;

namespace TestLib
{
    public interface ICompleter
    {
        /// <summary>
        /// Получить все возможные завершения слов, начинающиеся с префикса Prefix
        /// </summary>
        IEnumerable<string> Complete(string prefix);
    }
}
