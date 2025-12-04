using System.Text;

namespace Dictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            DictionaryMenu menu = new DictionaryMenu();
            menu.CreateDictionaryMenu();
        }
    }
}
