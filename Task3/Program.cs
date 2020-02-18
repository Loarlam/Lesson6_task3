/*Используя Visual Studio, создайте проект по шаблону Console Application.  
Расширьте пример решения 005_Book, создав в классе Book, вложенный класс Notes, который позволит сохранять заметки читателя. 
*/
using System;

namespace Task3
{
    static class FindAndReplaceManager
    {
        static string _longLine;

        public static string SetText { set { _longLine = value; } }

        public static void FindNext(string str)
        {
            if (_longLine.Contains(str))
                Console.WriteLine($"Строка найдена!\nПервое включение в текст на {_longLine.IndexOf(str)} символе.\n");
            else
                Console.WriteLine("Строка отсутствует.");
        }
    }

    class Book
    {
        const string QUOTE = "Я как-то слышал анекдот. " +
                "Мужчина приходит к врачу, жалуется на депрессию, говорит, жизнь груба и жестока, что он чувствует себя одиноким в угрожающем мире. " +
                "Врач предлагает простой рецепт — великий клоун Пальячи сегодня в городе, сходите, это вас подбодрит. " +
                "Мужчина взрывается слезами. «Но доктор, — говорит он, — я и есть Пальячи».";

        public void FindNext(string str)
        {
            Console.WriteLine("Исходный текст:");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{QUOTE}\n");
            Console.ResetColor();

            Console.WriteLine("Поиск строки:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{str}\n");
            Console.ResetColor();

            FindAndReplaceManager.SetText = QUOTE;
            FindAndReplaceManager.FindNext(str);
        }

        public class Notes
        {
            int _firstWordInSerchPosition, _lastWorkdInSearchPosition;
            string _savedNotes, _firstEnteredWord, _lastEnteredWord;

            public void Method()
            {
                do
                {
                    Console.WriteLine("Начать цитату со слова:");
                    _firstEnteredWord = Console.ReadLine();

                    if (QUOTE.IndexOf(_firstEnteredWord) == -1)
                        Console.WriteLine($"Слова {_firstEnteredWord} нет в тексте. Введи корректное слово:");
                    else
                        _firstWordInSerchPosition = QUOTE.IndexOf(_firstEnteredWord);
                } while (QUOTE.IndexOf(_firstEnteredWord) == -1);

                do
                {
                    Console.WriteLine("Закончить цититату словом:");
                    _lastEnteredWord = Console.ReadLine();

                    if (QUOTE.IndexOf(_lastEnteredWord) == -1)
                        Console.WriteLine($"Слова {_lastEnteredWord} нет в тексте. Введи корректное слово:");
                    else
                        _lastWorkdInSearchPosition = QUOTE.IndexOf(_lastEnteredWord) + _lastEnteredWord.Length;
                } while (QUOTE.IndexOf(_lastEnteredWord) == -1);                

                for (int i = _firstWordInSerchPosition; i < _lastWorkdInSearchPosition; i++)
                {
                    _savedNotes += QUOTE[i];
                }

                Console.WriteLine("Заметка создана:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(_savedNotes);
                Console.ResetColor();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();
            book.FindNext("Мужчина приходит к врачу, жалуется на депрессию");

            Book.Notes notes = new Book.Notes();
            notes.Method();

            Console.ReadKey();
        }
    }
}
