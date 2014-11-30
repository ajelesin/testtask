using System;
using System.Collections.Generic;
using System.Linq;

namespace TestLib
{
    /// <summary>
    /// Класс шаблона тестового приложения
    /// Обеспечивает базовый алгоритм работы
    /// </summary>
    public abstract class TemplateApp
    {
        protected IStreamProvider _streamProvider;
        protected ICompleter _completer;

        protected TemplateApp(IStreamProvider streamProvider, ICompleter completer)
        {
            _streamProvider = streamProvider;
            _completer = completer;
        }

        public void Run()
        {
            var prefixes = ReadPrefixes();
            var completions = GetCompletions(prefixes);
            WriteCompletions(completions);
        }

        /// <summary>
        /// Из IEnumerable<string> читает строку и добавляет все завершения слов в результирующий список
        /// Блоки возможных завершений разделяются пустой строкой
        /// Возвращает результирующий список
        /// </summary>
        protected IEnumerable<string> GetCompletions(IEnumerable<string> prefixes)
        {
            var result = new List<string>();
            foreach (var prefix in prefixes)
            {
                var completions = _completer.Complete(prefix);
                if (!completions.Any()) continue;

                result.AddRange(_completer.Complete(prefix));
                result.Add(String.Empty);
            }
            return result;
        }

        /// <summary>
        /// Из IStreamProvider построчно считывает все префиксы и записывает в результирующий список
        /// Возвращает результирующий список
        /// </summary>
        protected virtual IEnumerable<string> ReadPrefixes()
        {
            var result = new List<string>();
            var textReader = _streamProvider.GetTextReader();
            string line;

            while ((line = textReader.ReadLine()) != null)
            {
                result.Add(line);
            }

            return result;
        }

        /// <summary>
        /// Записывает IEnumerable<string> в IStreamProvider построчно
        /// </summary>
        protected virtual void WriteCompletions(IEnumerable<string> completions)
        {
            var textWriter = _streamProvider.GetTextWriter();
            foreach (var complete in completions)
            {
                textWriter.WriteLine(complete);
            }
        }
    }
}
