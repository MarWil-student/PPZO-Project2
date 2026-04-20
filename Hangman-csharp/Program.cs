using System;
using System.Collections.Generic;

namespace HangmanGame
{
    public class WordBank
    {
        private List<string> words = new List<string>
        {
            "algorytmy", "komputer", "uczelnia", "kura", "maksymalnie", "piosenka", "wisielec", "zaliczenie"
        };

        private Random random = new Random();

        public string GetRandomWord()
        {
            return words[random.Next(words.Count)].ToLower();
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Nic");
        }
    }

}