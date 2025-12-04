namespace Dictionaries
{
    [Serializable]
    public class Dictionary
    {
        private readonly string dictionaryType = null!;
        private Dictionary<string, List<string>> dictionaryWords = null!;
        private ExportDictionary exportDict = new();

        public string DictionaryType
        {
            get { return dictionaryType; }
        }
        public Dictionary<string, List<string>> DictionaryWords
        {
            get { return dictionaryWords; }
        }
        public Dictionary(string type)
        {
            dictionaryType = type;
            dictionaryWords = new();
            exportDict.ExportDictionaryToFile(this);
        }

        public void DictionaryInfo()
        {
            Console.WriteLine($"Dictionary Type: {dictionaryType}");
            Console.WriteLine("Words and Translations:");
            foreach (var word in dictionaryWords)
            {
                Console.WriteLine($"- {word.Key} : {string.Join(", ", word.Value)}");
            }
        }
        public void AddWord(string key, List<string> value)
        {
            dictionaryWords.Add(key, value);
            exportDict.ExportDictionaryToFile(this);
        }
        public void EditKey(string oldKey, string newKey)
        {
            if (dictionaryWords.ContainsKey(oldKey))
            {
                var value = dictionaryWords[oldKey];
                dictionaryWords.Remove(oldKey);
                dictionaryWords.Add(newKey, value);
                exportDict.ExportDictionaryToFile(this);
            }
            else
            {
                Console.WriteLine($"The word '{oldKey}' does not exist in the dictionary.");
            }
        }
        public void EditValue(string key, List<string> newValue)
        {
            if (dictionaryWords.ContainsKey(key))
            {
                dictionaryWords[key] = newValue;
                exportDict.ExportDictionaryToFile(this);
            }
            else
            {
                Console.WriteLine($"The word '{key}' does not exist in the dictionary.");
            }      
        }
        public void RemoveKey(string keyToRemove)
        {
            if (dictionaryWords.ContainsKey(keyToRemove))
            {
                dictionaryWords.Remove(keyToRemove);
                exportDict.ExportDictionaryToFile(this);
            }
            else
            {
                Console.WriteLine($"The word '{keyToRemove}' does not exist in the dictionary.");
            }
        }
        public void RemoveValue(string key, string wordToRemove)
        {
            if (dictionaryWords.ContainsKey(key))
            {
                if (dictionaryWords[key].Contains(wordToRemove))
                {
                    if (dictionaryWords[key].Count > 1)
                    {
                        dictionaryWords[key].Remove(wordToRemove);
                        exportDict.ExportDictionaryToFile(this);
                    }
                    else
                    {
                        Console.WriteLine("Cannot remove the last translation for the word.");
                    }
                }
                else
                {
                    Console.WriteLine($"The word translation '{wordToRemove}' does not exist for the given word.");
                }
            }
            else
            {
                Console.WriteLine($"The word '{key}' does not exist in the dictionary.");
            }
        }
        public void SearchKeyTranslate(string key)
        {
            if (dictionaryWords.ContainsKey(key))
            {
                Console.WriteLine($"Translations for '{key}': {string.Join(", ", dictionaryWords[key])}");
            }
            else
            {
                Console.WriteLine($"The word '{key}' does not exist in the dictionary.");
            }
        }
    }
}
