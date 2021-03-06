﻿/*Используя Visual Studio, создайте проект по шаблону Console Application.  
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
            {
                Console.WriteLine($"Строка найдена!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Первое включение в текст на {_longLine.IndexOf(str)} символе.\n");
                Console.ResetColor();
            }
            else
                Console.WriteLine("Строка отсутствует.\n");
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
                    Console.Write("Начать цитировать со слова: ");
                    _firstEnteredWord = Console.ReadLine();

                    if (QUOTE.IndexOf(_firstEnteredWord) == -1)
                        Console.WriteLine($"Ошибка! Слово «{_firstEnteredWord}» отсутствует в тексте. Введи корректное слово.\n");
                    else
                        _firstWordInSerchPosition = QUOTE.IndexOf(_firstEnteredWord);
                } while (QUOTE.IndexOf(_firstEnteredWord) == -1);

                do
                {
                    do
                    {
                        Console.Write("Закончить цитировать словом: ");
                        _lastEnteredWord = Console.ReadLine();

                        /*Приведу два примера для строки ниже, поясняющие принцип её работы.
                         * Пример 1:
                         * в заданном константном тексте QUOTE, индекс самой первой буквы "Я" равен [0].
                         * Данный индекс может использовать для начала отсчёта вкрапление текста QUOTE.IndexOf(_firstEnteredWord) - предположим, цитата начнётся с "Я" и должна линейно, последовательно идти вперед.
                         * QUOTE.IndexOf(_lastEnteredWord) может  выдать 0 в двух случаях: 
                         * 1. если текст отсутствует, то выдаёт 0;
                         * 2. если текст присутствует, и это "Я" - [0] индекс в тексте.
                         * Если поставить QUOTE.IndexOf(_lastEnteredWord) > 0, то было бы непонятно: то ли пользователь ввёл букву "Я", то ли ввёл "ДД" (которые отсутствуют в тексте). 
                         * 
                         * Пример2:
                         * предположим, QUOTE.IndexOf(_firstEnteredWord) определил, что вкрапление текста имеется в заданном константном тексте QUOTE, и позиция начала вкрапления равна 25;
                         * предположим, что QUOTE.IndexOf(_lastEnteredWord) определил, что вкрапление текста имеется в заданном константном тексте QUOTE, и позиция начала вкрапления равна 15, что меньше позиции QUOTE.IndexOf(_firstEnteredWord);
                         * если позиция QUOTE.IndexOf(_lastEnteredWord) <= QUOTE.IndexOf(_firstEnteredWord), следовательно невозможно сформировать цитату, 
                         * так как цитата должна иметь линейные последовательные начало и конец, а не начало и такое же начало, или начало и предыдущее слово перед началом в конце.
                        */
                        if (QUOTE.IndexOf(_lastEnteredWord) > 0 && QUOTE.IndexOf(_lastEnteredWord) <= QUOTE.IndexOf(_firstEnteredWord))
                            Console.WriteLine($"Ошибка! Словом «{_lastEnteredWord}» невозможно закончить цитату. Слово нарушает порядок цитирования.\n");
                    } while (QUOTE.IndexOf(_lastEnteredWord) > 0 && QUOTE.IndexOf(_lastEnteredWord) <= QUOTE.IndexOf(_firstEnteredWord));

                    if (QUOTE.IndexOf(_lastEnteredWord) == -1)
                        Console.WriteLine($"Ошибка! Слово {_lastEnteredWord} отсутствует в тексте. Введи корректное слово.\n");
                    else
                        _lastWorkdInSearchPosition = QUOTE.IndexOf(_lastEnteredWord) + _lastEnteredWord.Length;
                } while (QUOTE.IndexOf(_lastEnteredWord) == -1);

                for (int i = _firstWordInSerchPosition; i < _lastWorkdInSearchPosition; i++)
                {
                    _savedNotes += QUOTE[i];
                }

                Console.WriteLine("\nЗаметка создана:");
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
