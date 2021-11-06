using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public static class Show
    {
        public static string Word()
        {
            Console.WriteLine("Добавьте слово ");
            var name = Console.ReadLine();
            return name;
        }
        public static string Translation()
        {
            Console.WriteLine("Введите перевод ");
            var name = Console.ReadLine();
            return name;
        }
        public static string Failname()
        {
            Console.WriteLine("Введите имя файла - ");
            string path = Console.ReadLine();
            return path;
        }
        public static void PrintLn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void Menu()
        {
            PrintLn("Выберите тип словаря:");
            PrintLn("1. Русско-Английский");
            PrintLn("2. Англо-Русский");
        }
        public static void Submenu()
        {
            PrintLn("1. Добавить");
            PrintLn("2. Редактировать");
            PrintLn("3. Удалить");
            PrintLn("4. Найти перевод");
            PrintLn("5. Показать весь словарь");
            PrintLn("6. Сохранить в отдельный файл результата");
            PrintLn("7. Возврат в предыдущее меню");
            PrintLn("0. Выход");


        }
        public static void Smenu()
        {
            PrintLn("1. Добавьте новый перевод");            
            PrintLn("2. Возврат в подменю");
        }
    }
}
