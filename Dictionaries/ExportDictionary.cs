using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dictionaries
{
    public class ExportDictionary
    {
        public ExportDictionary() { }

        public void ExportKeyValueToFile(Dictionary dict, string key)
        {

            if (dict.DictionaryWords.ContainsKey(key))
            {
                using (StreamWriter sw = new StreamWriter($"{key}_translations.txt"))
                {
                    sw.WriteLine($"{key} : {string.Join(", ", dict.DictionaryWords[key])}");
                }
            }
            else
            {
                Console.WriteLine($"The word '{key}' does not exist in the dictionary.");
            }
        }
        public void ExportDictionaryToFile(Dictionary dict)
        {
            using (StreamWriter sw = new StreamWriter($"{dict.DictionaryType}_dictionary.txt"))
            {
                sw.WriteLine($"Dictionary Type: {dict.DictionaryType}");
                sw.WriteLine("Words and Translations:");
                foreach (var word in dict.DictionaryWords)
                {
                    sw.WriteLine($"- {word.Key} : {string.Join(", ", word.Value)}");
                }
            }
        }
    }
}
