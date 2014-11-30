using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FDictionaryLib;

namespace TestLib
{
    public static class IFDictionaryExtension
    {
        public static void LoadFromFile(this IFDictionary fDictionary, string filename)
        {
            fDictionary.Clear();

            var inputData = File.ReadAllLines(filename);

            var n = Convert.ToInt32(inputData[0]);

            var fwords = inputData.AsEnumerable()
                .Skip(1)
                .Take(n)
                .Select(o => o.Split(' ').ToArray())
                .Select(o => new FWord { Word = o[0], Freq = Convert.ToInt32(o[1]) });

            fDictionary.AddRange(fwords);
        }

        public static void LoadFromTextReader(this IFDictionary fDictionary, TextReader textReader)
        {
            fDictionary.Clear();

            var n = Convert.ToInt32(textReader.ReadLine());
            var result = new List<FWord>(n);

            for (int i = 0; i < n; i++)
            {
                var tokens = textReader.ReadLine().Split(' ');
                result.Add(
                    new FWord { Word = tokens[0], Freq = Convert.ToInt32(tokens[1]) });
            }

            fDictionary.AddRange(result);
        }
    }
}
