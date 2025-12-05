using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    internal class DictionaryMenu
    {
        private List<Dictionary> dictList = new();
        private ExportDictionary exportDict = new();
        private int selectedDictIndex = 0;

        public void CreateDictionaryMenu()
        {
            Console.Clear();
            Console.Write("Enter dictionary type(* - *): ");
            string type = Console.ReadLine() ?? "English - Ukrainian";
            dictList.Add(new Dictionary(type));
            ShowMenu();
        } 
        public void ShowMenu()
        {
            Console.Clear();
            dictList[selectedDictIndex].DictionaryInfo();
            Console.WriteLine("\n|-------------------------------------------------|");
            Console.WriteLine("MENU:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add Word");
            Console.WriteLine("2. Edit Word");
            Console.WriteLine("3. Edit Translate");
            Console.WriteLine("4. Remove Word");
            Console.WriteLine("5. Remove Translate");
            Console.WriteLine("6. Search word translate");
            Console.WriteLine("7. Export word to file");
            Console.WriteLine("8. Create new dictionary");
            Console.WriteLine("9. Select dictionary");
            Console.Write("Select an action: ");
            string choice = Console.ReadLine() ?? "0";

            ChoiceMenuOption(choice);
        }

        public void SelectDictionaryMenu()
        {
            Console.Clear();
            Console.WriteLine("Available Dictionaries:");
            for (int i = 0; i < dictList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dictList[i].DictionaryType}");
            }
            Console.Write("Select a dictionary by number: ");
            try
            {
                int sd = Convert.ToInt32(Console.ReadLine());
            
                if (sd > 0 && sd <= dictList.Count)
                {
                    selectedDictIndex = sd - 1;
                    Console.WriteLine($"Selected dictionary: {dictList[selectedDictIndex].DictionaryType}");
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }
            catch (Exception ex)
            {
                selectedDictIndex = 0;
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ChoiceMenuOption(string choice)
        {
            if (choice == "0")
            {
                Console.WriteLine("Exit...");
                return;
            }
            switch (choice)
            {
                case "1":
                    Console.Write("Enter word: ");
                    string key = Console.ReadLine() ?? "";
                    Console.Write("Enter translations(separated by commas): ");
                    string translationsWord = Console.ReadLine() ?? "";
                    List<string> translationsList = translationsWord.Split(',').Select(t => t.Trim()).ToList();
                    dictList[selectedDictIndex].AddWord(key, translationsList);
                    break;
                case "2":
                    Console.Write("Enter the word you want to change: ");
                    string oldKey = Console.ReadLine() ?? "";
                    Console.Write("Enter new word: ");
                    string newKey = Console.ReadLine() ?? "";
                    dictList[selectedDictIndex].EditKey(oldKey, newKey);
                    break;
                case "3":
                    Console.Write("Enter the word for which you want to change translations: ");
                    string editKey = Console.ReadLine() ?? "";
                    Console.Write("Enter new translations(separated by commas): ");
                    string newTranslationsWord = Console.ReadLine() ?? "";
                    List<string> newTranslationsList = newTranslationsWord.Split(',').Select(t => t.Trim()).ToList();
                    dictList[selectedDictIndex].EditValue(editKey, newTranslationsList);
                    break;
                case "4":
                    Console.Write("Enter the word you want to remove: ");
                    string keyToRemove = Console.ReadLine() ?? "";
                    dictList[selectedDictIndex].RemoveKey(keyToRemove);
                    break;
                case "5":
                    Console.Write("Enter the word from which you want to remove a translation: ");
                    string keyForValueRemove = Console.ReadLine() ?? "";
                    Console.Write("Enter the translation you want to remove: ");
                    string wordToRemove = Console.ReadLine() ?? "";
                    dictList[selectedDictIndex].RemoveValue(keyForValueRemove, wordToRemove);
                    break;
                case "6":
                    Console.Write("Enter the word you want to translate: ");
                    string searchKey = Console.ReadLine() ?? "";
                    dictList[selectedDictIndex].SearchKeyTranslate(searchKey);
                    break;
                case "7":
                    Console.Write("Enter the word you want to export: ");
                    string exportKey = Console.ReadLine() ?? "";
                    exportDict.ExportKeyValueToFile(dictList[selectedDictIndex], exportKey);
                    break;
                case "8":
                    selectedDictIndex = dictList.Count;
                    CreateDictionaryMenu();
                    return;
                case "9":
                    SelectDictionaryMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            ShowMenu();
        }
    }
}
