using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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

    public class Player
    {
        public int Mistakes { get; private set; } = 0;
        public HashSet<char> GuessedLetters { get; private set; } = new HashSet<char>();

        public void AddMistakes() => Mistakes++;
        public bool AlreadyGuessed(char letter) => GuessedLetters.Contains(letter);
        public void RegisterLetter(char letter) => GuessedLetters.Add(letter);
    }

    public class Game
    {
        private string secretWord;
        private Player player;
        private WordBank wordBank;
        private const int maxMistakes = 6;

        public Game()
        {
            wordBank = new WordBank();
            secretWord = wordBank.GetRandomWord();
            player = new Player();
        }

        public void Start()
        {
            Console.WriteLine("====  Gra Wisielec  ====");
            Console.WriteLine("Zasady: Zgadnij slowo, maksymalna ilosc pomylek to 6");

        }

        private void DisplayBoard()
        {
            Console.WriteLine("\nSlowo:");
            foreach(char c in secretWord)
            {
                if(player.GuessedLetters.Contains(c))
                {
                    Console.WriteLine(c + " ");
                }
                else
                {
                    Console.WriteLine("_ ");
                }
            }
            Console.WriteLine();
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