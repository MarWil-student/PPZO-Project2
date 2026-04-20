using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;

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

            while(player.Mistakes < maxMistakes)
            {
                DisplayBoard();
                char guess = GetValidInput();

                if (player.AlreadyGuessed(guess))
                {
                    Console.WriteLine($"\n Litera '{guess}' byla juz wybrana");
                    continue;
                }

                player.RegisterLetter(guess);

                if (secretWord.Contains(guess))
                {
                    Console.WriteLine("\n Poprawna litera!");
                }
                else
                {
                    player.AddMistakes();
                    Console.WriteLine("\n Pudlo!");
                }

                if(Win() == true)
                {
                    DisplayBoard();
                    Console.WriteLine("\n====  Gratulacje wygrana!  ====");
                    return;
                }
                else
                {
                    Console.WriteLine("\n====  Przegrales  ====");
                    Console.WriteLine($"\nSlowo to: {secretWord}");
                }
            }
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

        private char GetValidInput()
        {
            while (true)
            {
                Console.WriteLine("\nPodaj jedna litere: ");
                string input = Console.ReadLine()?.ToLower();

                
                if(string.IsNullOrWhiteSpace(input) || input.Length != 1)
                {
                    Console.WriteLine("BLAD: Musisz wpisac dokladnie jedna litere");
                    continue;
                }

                char letter = input[0];

                if(!char.IsLetter(letter))
                {
                    Console.WriteLine("BLAD: Znaki inne niz litery nie sa akceptowane");
                    continue;
                }

                return letter;
            }
        }

        private bool Win()
        {
            return secretWord.All(c=> player.GuessedLetters.Contains(c));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }

}

