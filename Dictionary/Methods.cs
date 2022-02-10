using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public static class Methods
    {
        public static void Add(Dictionary<string, List<string>> dictionary)
        {
            var exit = false;
            var flagAdd = false;
            var word = Show.Word();
            foreach (var element in dictionary)
            {
                if (element.Key == word)
                {
                    throw new Exception($"Слово уже существует : {element.Key}");
                    //Show.PrintLn("Слово уже существует");
                }
                //break;                
            }
            var listTranslations = new List<string>();            
            var translate = Show.Translation();
            listTranslations.Add(translate);
            //var listCopy = listTranslations;
            dictionary.Add(word, listTranslations);
            //dictionary.Add(word, translate);
            do
            {
                Show.Smenu();
                var select = Console.ReadLine();                               
                switch (select)
                {
                     case "1": // 1. Добавить перевод
                        translate = Show.Translation(); 
                        foreach (var element in dictionary)
                        {
                            foreach (var translation in element.Value)
                            {
                                if (translation == translate && element.Key == word)
                                {
                                    throw new Exception($"Слово c данным переводом уже существует : {translation}");
                                    //Show.PrintLn("Слово c данным переводом уже существует");
                                    flagAdd = true;
                                }
                            }
                        }                   
                        if (!flagAdd)
                        {
                            /*dictionary.Remove(word);
                            listCopy.Add(translate);
                            dictionary.Add(word, listCopy);*/

                            dictionary[word].Add(translate);
                        }
                        break;
                    case "2": // 2. Возврат в подменю
                        exit = true;
                        break;
                }
            } while (!exit);
        }
        
        public static void AddFile(Dictionary<string, List<string>> dictionary)
        {
            try
            {
                Add(dictionary);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            ImportToFile(dictionary);
        }
        /*public static void AddResFileRus()
        {
            var dictionary = new Dictionary<string, string>();
            AddRus(dictionary);
            ImportToFile(dictionary);
        }
        public static void AddResFileEng()
        {
            var dictionary = new Dictionary<string, string>();
            AddEng(dictionary);
            ImportToFile(dictionary);
        }
        public static void AddFileEng(Dictionary<string, string> dictionary)
        {
            AddEng(dictionary);
            ImportToFile(dictionary);
        }*/
        /*public static void EditRus(Dictionary<string, string> dictionary)
        {
            var flag = false;
            var russian = Show.WordName("Введите русское слово которое хотите заменить - ");
            foreach (var element in dictionary)
            {
                if (element.Value == russian)
                {
                    dictionary.Remove(element.Key);
                    flag = true;
                }
            }
            if (flag)
            {
                var russianNew = Show.WordName("Введите новое слово - ");
                var english = Show.WordName("Введите перевод ");
                dictionary.Add(english, russianNew);
            }
            if (!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
            ImportToFileEdit(dictionary);
        }
        public static void EditEng(Dictionary<string, string> dictionary)
        {
            var flag = false;
            var english = Show.WordName("Введите английское слово которое хотите заменить - ");
            foreach (var element in dictionary)
            {
                if (element.Value == english)
                {
                    dictionary.Remove(element.Key);
                    flag = true;
                }
            }
            if (flag)
            {
                var englishNew = Show.WordName("Введите новое слово - ");
                var russian = Show.WordName("Введите перевод ");
                dictionary.Add(russian, englishNew);
            }
            if (!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
            ImportToFileEdit(dictionary);
        }
        public static void FindRus(Dictionary<string, string> dictionary)
        {
            var flag = false;
            var russian = Show.WordName("Введите русское слово которое хотите найти - ");
            foreach (var element in dictionary)
            {
                if (element.Value == russian)
                {
                    Console.WriteLine($"{element.Value} - {element.Key}");
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
        }
        public static void FindEng(Dictionary<string, string> dictionary)
        {
            var flag = false;
            var english = Show.WordName("Введите английское слово которое хотите найти - ");
            foreach (var element in dictionary)
            {
                if (element.Value == english)
                {
                    Console.WriteLine($"{element.Value} - {element.Key}");
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
        }
        public static void DeleteRUS(Dictionary<string, string> dictionary)
        {
            var flag = false;
            var russian = Show.WordName("Введите русское слово которое хотите удалить - ");
            foreach (var element in dictionary)
            {
                if (element.Value == russian)
                {
                    dictionary.Remove(element.Key);
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
        }*/
        public static void ImportToFile(Dictionary<string, List<string>> dictionary)
        {
            //var file = new StreamWriter(Show.Failname(), true);
            var file = new StreamWriter("Rus.txt", false);
            foreach (var element in dictionary)
            {
                file.Write($"{element.Key} - ");

                foreach (var translation in element.Value)
                {
                    file.Write($"{translation}, ");
                }
            }
            file.Close();
        }
        
        /*public static void ImportToFileEdit(Dictionary<string, string> dictionary)
        {
            //var file = new StreamWriter(Show.Failname(), false);
            var file = new StreamWriter("Rus.txt", false);
            foreach (var element in dictionary)
            {
                file.WriteLine($"{element.Key} - {element.Value}");
            }
            file.Close();
        }*/
        public static void PrintDictionary(Dictionary<string, List<string>> dictionary)
        {            
            Console.WriteLine();
            foreach (var element in dictionary)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{element.Key} - ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var translation in element.Value)
                {
                    Console.Write($"{translation}, ");
                }

                Console.ResetColor();
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    
    }
}
