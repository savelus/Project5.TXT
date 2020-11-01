using System;
using System.Collections.Generic;

namespace Project5.TXT
{
    class Program
    {
        public static string[] SplitText (string text)
        {
            string[] words = text.Split(' ', '.', ',', '?', '!', ':', ';');
            return words;
        }

        static int[] ConsiderPunctM(string text)
        {
            int[] mark = new int[7];
            //точка. запятая. вопрос. воскл. тире. точсзап. двоет.
            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case '.':
                        mark[0]++;
                        break;
                    case ',':
                        mark[1]++;
                        break;
                    case '?':
                        mark[2]++;
                        break;
                    case '!':
                        mark[3]++;
                        break;
                    case '-':
                        if (text[i - 1] == ' ' && text[i + 1] == ' ')
                        {
                            mark[4]++;
                        }
                        break;
                    case ';':
                        mark[5]++;
                        break;
                    case ':':
                        mark[6]++;
                        break;
                }
            }
            Console.WriteLine("Знаки препинания.");
            Console.WriteLine($"Всего знаков препинания:" +
                    $" {mark[0] + mark[1] + mark[2] + mark[3] + mark[4] + mark[5] + mark[6]}.\nТочек: {mark[0]}.\n" +
                    $"Запятых: {mark[1]}.\nВопрос. знаков: {mark[2]}.\nВоскл.знаков: {mark[3]}.\n " +
                    $"Тире: {mark[4]}.\nТочек с запятой: {mark[5]}.\nДвоеточий: {mark[6]}.");
            return mark;
        }

        static void SplitLine(string text, int[] mark)
        {
            Console.WriteLine("Разные предложения.");
            string[] lines = text.Split('.', '!', '?');
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }

        static void SearchUniqueWord (string[] words)
        {
            Dictionary<string, int> unicWord = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (unicWord.ContainsKey(word))
                {
                    unicWord[word]++;
                }
                else 
                {
                    unicWord.Add(word, 1);
                }
            }
            foreach (string word in unicWord.Keys)
            {
                if (unicWord[word] == 1)
                {
                    Console.WriteLine(word);
                }
            }
        }
        static void PrintMaxLengthWord(string text, string[] words)
        {
            
            int maxLength = 0;
            string maxLengthWord = "";
            foreach (string word in words)
            {
                if (word.Length > maxLength)
                {
                    maxLength = word.Length;
                    maxLengthWord = word;
                }
            }
            Console.Write("Самое длинное слово: ");
            Console.WriteLine(maxLengthWord);
            if (maxLengthWord.Length % 2 == 0)
            {
                Console.WriteLine(maxLengthWord.Remove(maxLength / 2)); }
            else
            {
                char[] word = maxLengthWord.ToCharArray();
                word[(maxLength - 1) / 2] = '*';
                Console.WriteLine(word);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст");
            string text = Console.ReadLine();
            int[] mark = ConsiderPunctM(text);
            SplitLine(text, mark);
            SearchUniqueWord(SplitText(text));
            PrintMaxLengthWord(text, SplitText(text));
            Console.ReadLine();

        }
    }
}
